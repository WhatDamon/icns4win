# Orginal code by relikd, repo: https://github.com/relikd/icnsutil/, MIT License
# Modified by: WhatDamon

#!/usr/bin/env python3
"""
Export existing icns files or compose new ones.
"""
import os  # path, makedirs
import sys  # path, stderr
import struct  # pack, unpack
from typing import (
    Iterator,
    Optional,
    Callable,
    List,
    Iterator,
    Union,
    Tuple,
    Set,
    Iterable,
    Dict,
)
from argparse import ArgumentParser, ArgumentTypeError, Namespace as ArgParams
from math import sqrt

if __name__ == "__main__":
    sys.path[0] = os.path.dirname(sys.path[0])


class CanNotDetermine(Exception):
    pass


class Media:
    KeyT = Union[str, bytes]
    __slots__ = [
        "key",
        "types",
        "size",
        "channels",
        "bits",
        "availability",
        "desc",
        "compressable",
        "retina",
        "maxsize",
        "ext_certain",
    ]

    def __init__(
        self,
        key: KeyT,
        types: List[str],
        size: Union[int, Tuple[int, int], None] = None,
        *,
        ch: Optional[int] = None,
        bits: Optional[int] = None,
        os: Optional[float] = None,
        desc: str = "",
    ) -> None:
        self.key = key
        self.types = types
        self.size = (size, size) if isinstance(size, int) else size
        self.availability = os
        self.desc = desc
        # computed properties
        self.compressable = self.is_type("argb") or self.is_type("rgb")
        self.retina = "@2x" in self.desc
        if self.is_type("rgb"):
            ch = 3
            bits = 8
        if self.is_type("argb"):
            ch = 4
            bits = 8
        self.channels = ch
        self.bits = bits
        self.maxsize = None  # type: Optional[int]
        if self.size and ch and bits:
            self.maxsize = self.size[0] * self.size[1] * ch * bits // 8
        self.ext_certain = all(
            x in ["png", "argb", "plist", "jp2", "icns"] for x in self.types
        )

    def is_type(self, typ: str) -> bool:
        return typ in self.types

    def is_binary(self) -> bool:
        return any(x in self.types for x in ["rgb", "bin"])

    def fallback_ext(self) -> str:
        if self.channels in [1, 2]:
            return self.desc  # guaranteed to be icon, mask, or iconmask
        return self.types[-1]

    def decompress(
        self, data: bytes, ext: Optional[str] = "-?-"
    ) -> Optional[List[int]]:
        """Returns None if media is not decompressable."""
        if self.compressable:
            if ext == "-?-":
                ext = determine_file_ext(data)
            if ext == "argb":
                return unpack(data[4:])  # remove ARGB header
            if ext is None or ext == "rgb":  # RGB files dont have magic number
                if self.key == "it32":
                    data = data[4:]
                return unpack(data)
        return None

    def filename(self, *, key_only: bool = False, size_only: bool = False) -> str:
        if key_only:
            if os.path.exists(__file__.upper()):  # check case senstive
                if self.key in ["sb24", "icsb"]:
                    return self.key + "-a"  # type: ignore
                elif self.key in ["SB24", "icsB"]:
                    return self.key + "-b"  # type: ignore
            return str(self.key)  # dont return directy, may be b''-str
        else:
            if self.is_type("icns"):
                return self.desc
            if not self.size:
                return str(self.key)  # dont return directy, may be b''-str
            w, h = self.size
            suffix = ""
            if self.retina:
                w //= 2
                h //= 2
                suffix = "@2x"
            if size_only:
                if self.bits == 1:
                    suffix += "-mono"
            else:
                if self.desc in ["icon", "iconmask"]:
                    suffix += "-icon{}b".format(self.bits)
                if self.desc in ["mask", "iconmask"]:
                    suffix += "-mask{}b".format(self.bits)
            return "{}x{}{}".format(w, h, suffix)

    def __repr__(self) -> str:
        return "<{}: {}, {}.{}>".format(
            type(self).__name__, str(self.key), self.filename(), self.types[0]
        )

    def __str__(self) -> str:
        T = ""
        if self.size:
            T += "{}x{}, ".format(*self.size)
            if self.maxsize:
                T += "{}ch@{}-bit={}, ".format(self.channels, self.bits, self.maxsize)
        if self.desc:
            T += self.desc + ", "
        return "{}: {}macOS {}+".format(str(self.key), T, self.availability or "?")


_TYPES = {
    x.key: x
    for x in (
        # Read support for these:
        Media("ICON", ["bin"], 32, ch=1, bits=1, os=1.0, desc="icon"),
        Media("icm4", ["bin"], (16, 12), ch=1, bits=4, os=7.0, desc="icon"),
        Media("icm8", ["bin"], (16, 12), ch=1, bits=8, os=7.0, desc="icon"),
        Media("ics#", ["bin"], 16, ch=2, bits=1, os=6.0, desc="iconmask"),
        Media("ics4", ["bin"], 16, ch=1, bits=4, os=7.0, desc="icon"),
        Media("ics8", ["bin"], 16, ch=1, bits=8, os=7.0, desc="icon"),
        Media("is32", ["rgb"], 16, os=8.5),
        Media("s8mk", ["bin"], 16, ch=1, bits=8, os=8.5, desc="mask"),
        Media("icl4", ["bin"], 32, ch=1, bits=4, os=7.0, desc="icon"),
        Media("icl8", ["bin"], 32, ch=1, bits=8, os=7.0, desc="icon"),
        Media("il32", ["rgb"], 32, os=8.5),
        Media("l8mk", ["bin"], 32, ch=1, bits=8, os=8.5, desc="mask"),
        Media("ich#", ["bin"], 48, ch=2, bits=1, os=8.5, desc="iconmask"),
        Media("ich4", ["bin"], 48, ch=1, bits=4, os=8.5, desc="icon"),
        Media("ich8", ["bin"], 48, ch=1, bits=8, os=8.5, desc="icon"),
        Media("ih32", ["rgb"], 48, os=8.5),
        Media("h8mk", ["bin"], 48, ch=1, bits=8, os=8.5, desc="mask"),
        Media("it32", ["rgb"], 128, os=10.0),
        Media("t8mk", ["bin"], 128, ch=1, bits=8, os=10.0, desc="mask"),
        # Write support for these:
        Media("icp4", ["png", "jp2", "rgb"], 16, os=10.7),
        Media("icp5", ["png", "jp2", "rgb"], 32, os=10.7),
        Media("icp6", ["png", "jp2"], 48, os=10.7),
        Media("ic07", ["png", "jp2"], 128, os=10.7),
        Media("ic08", ["png", "jp2"], 256, os=10.5),
        Media("ic09", ["png", "jp2"], 512, os=10.5),
        Media("ic10", ["png", "jp2"], 1024, os=10.7, desc="or 512x512@2x (10.8)"),
        Media("ic11", ["png", "jp2"], 32, os=10.8, desc="16x16@2x"),
        Media("ic12", ["png", "jp2"], 64, os=10.8, desc="32x32@2x"),
        Media("ic13", ["png", "jp2"], 256, os=10.8, desc="128x128@2x"),
        Media("ic14", ["png", "jp2"], 512, os=10.8, desc="256x256@2x"),
        Media("ic04", ["argb", "png", "jp2"], 16, os=11.0),  # ARGB is macOS 11+
        Media("ic05", ["argb", "png", "jp2"], 32, os=11.0),
        Media("icsb", ["argb", "png", "jp2"], 18, os=11.0),
        Media("icsB", ["png", "jp2"], 36, desc="18x18@2x"),
        Media("sb24", ["png", "jp2"], 24),
        Media("SB24", ["png", "jp2"], 48, desc="24x24@2x"),
        # ICNS media files
        Media("sbtp", ["icns"], desc="template"),
        Media("slct", ["icns"], desc="selected"),
        Media(b"\xFD\xD9\x2F\xA8", ["icns"], os=10.14, desc="dark"),
        # Meta types:
        Media("TOC ", ["bin"], os=10.7, desc="Table of Contents"),
        Media("icnV", ["bin"], desc="4-byte Icon Composer.app bundle version"),
        Media("name", ["bin"], desc="Unknown"),
        Media("info", ["plist"], desc="Info binary plist"),
    )
}


def enum_img_mask_pairs(
    available_keys: Iterable[Media.KeyT],
) -> Iterator[Tuple[Optional[str], Optional[str]]]:
    for mask_k, *imgs in [  # list probably never changes, ARGB FTW
        ("s8mk", "is32", "ics8", "ics4", "icp4"),
        ("l8mk", "il32", "icl8", "icl4", "icp5"),
        ("h8mk", "ih32", "ich8", "ich4"),
        ("t8mk", "it32"),
    ]:
        mk = mask_k if mask_k in available_keys else None
        any_img = False
        for img_k in imgs:
            if img_k in available_keys:
                any_img = True
                yield img_k, mk
        if mk and not any_img:
            yield None, mk


def enum_png_convertable(
    available_keys: Iterable[Media.KeyT],
) -> Iterator[Tuple[Media.KeyT, Optional[Media.KeyT]]]:
    """Yield (image-key, mask-key or None)"""
    for img in _TYPES.values():
        if img.key not in available_keys:
            continue
        if img.is_type("argb") or img.bits == 1:  # allow mono icons
            yield img.key, None
        elif img.is_type("rgb"):
            mask_key = None
            for mask in _TYPES.values():
                if mask.key not in available_keys:
                    continue
                if mask.desc == "mask" and mask.size == img.size:
                    mask_key = mask.key
                    break
            yield img.key, mask_key


def supported_extensions() -> Set[str]:
    return set(y for x in _TYPES.values() for y in x.types)


def get(key: Media.KeyT) -> Media:
    try:
        return _TYPES[key]
    except KeyError:
        pass
    raise NotImplementedError('Unsupported icns type "' + str(key) + '"')


def key_from_readable(key: str) -> Media.KeyT:
    key_mapping = {
        "dark": b"\xFD\xD9\x2F\xA8",
        "selected": "slct",
        "template": "sbtp",
        "toc": "TOC ",
    }
    return key_mapping.get(key.lower(), key)  # type: ignore[return-value]


def match_maxsize(total: int, typ: str) -> Media:
    assert typ == "argb" or typ == "rgb"
    ret = [x for x in _TYPES.values() if x.is_type(typ) and x.maxsize == total]
    return _best_option(ret, typ)


def guess(data: bytes, filename: Optional[str] = None) -> Media:
    """
    Guess icns media type by analyzing the raw data + file naming convention.
    Use:
    - @2x.png or @2x.jp2 for retina images
    - directly name the file with the corresponding icns-key
    - or {selected|template|dark}.icns to select the proper icns key.
    """
    # Set type directly via filename
    if filename:
        bname = os.path.splitext(os.path.basename(filename))[0]
        if bname in _TYPES:
            return _TYPES[bname]

    # Filter attributes
    desc = None
    size = None
    maxsize = None
    retina = False

    # Guess extension
    ext = determine_file_ext(data)
    if not ext and filename:
        if filename.endswith(".rgb"):
            ext = "rgb"
        elif filename.endswith(".mask"):
            maxsize = len(data)
            desc = "mask"

    # Guess image size
    if ext:
        size = determine_image_size(data, ext)

    # if filename is set, then bname is also set (see above)
    if filename:
        # Guess retina flag
        retina = bname.lower().endswith("@2x")
        # Guess icns-specific type
        if ext == "icns":
            for candidate in ["template", "selected", "dark"]:
                if bname.endswith(candidate):
                    desc = candidate
                    break

    # stupid double usage of ic10, enforce retina flag
    if size == (1024, 1024):
        retina = True

    choices = []
    for x in _TYPES.values():
        if retina != x.retina:  # png + jp2
            continue
        if desc and desc != x.desc:  # icns or rgb-mask
            continue
        if ext:
            if size != x.size or not x.is_type(ext):
                continue
        else:  # not ext
            if x.ext_certain:
                continue
            if maxsize and x.maxsize and maxsize != x.maxsize:  # mask only
                continue
        choices.append(x)

    return _best_option(choices, ext)


def _best_option(choices: List[Media], ext: Optional[str] = None) -> Media:
    """
    Get most favorable media type.
    If more than one option exists, choose based on order index of ext.
    """
    if len(choices) == 1:
        return choices[0]
    # Try get most favorable type (sort order of types)
    if ext:
        best_i = 99
        best_choice = []
        for x in choices:
            i = x.types.index(ext)
            if i < best_i:
                best_i = i
                best_choice = [x]
            elif i == best_i:
                best_choice.append(x)
        if len(best_choice) == 1:
            return best_choice[0]
        choices = best_choice

    raise CanNotDetermine(
        "Could not determine type ¨C one of {}.".format([x.key for x in choices])
    )


def pack(data: List[int]) -> bytes:
    ret = []  # type: List[int]
    buf = []  # type: List[int]
    i = 0

    def flush_buf() -> None:
        # write out non-repeating bytes
        if len(buf) > 0:
            ret.append(len(buf) - 1)
            ret.extend(buf)
            buf.clear()

    end = len(data)
    while i < end:
        arr = data[i : i + 3]
        x = arr[0]
        if len(arr) == 3 and x == arr[1] and x == arr[2]:
            flush_buf()
            # repeating
            c = 3
            while (i + c) < end and data[i + c] == x:
                c += 1
            i += c
            while c > 130:  # max number of copies encodable in compression
                ret.append(0xFF)
                ret.append(x)
                c -= 130
            if c > 2:
                ret.append(c + 0x7D)  # 0x80 - 3
                ret.append(x)
            else:
                i -= c
        else:
            buf.append(x)
            if len(buf) > 127:
                flush_buf()
            i += 1
    flush_buf()
    return bytes(ret)


def unpack(data: bytes) -> List[int]:
    ret = []  # type: List[int]
    i = 0
    end = len(data)
    while i < end:
        n = data[i]
        if n < 0x80:
            ret += data[i + 1 : i + n + 2]
            i += n + 2
        else:
            ret += [data[i + 1]] * (n - 0x7D)
            i += 2
    return ret


def get_size(data: bytes) -> int:
    count = 0
    i = 0
    end = len(data)
    while i < end:
        n = data[i]
        if n < 0x80:
            count += n + 1
            i += n + 2
        else:
            count += n - 125
            i += 2
    return count


def msb_stream(data: Union[bytes, List[int]], *, bits: int) -> Iterator[int]:
    if bits not in [1, 2, 4]:
        raise NotImplementedError("Unsupported bit-size.")
    c = 0
    byte = 0
    for x in data:  # 8-bits in, most significant n-bits out
        c += bits
        byte <<= bits
        byte |= x >> (8 - bits)
        if c == 8:
            yield byte
            c = 0
            byte = 0
    if c > 0:  # fill up missing bits
        byte <<= 8 - c
        yield byte


class ArgbImage:
    __slots__ = ["a", "r", "g", "b", "size", "channels"]

    @classmethod
    def __init__(
        self,
        *,
        data: Optional[bytes] = None,
        file: Optional[str] = None,
        image: None,
        mask: Union[bytes, str, None] = None,
    ) -> None:
        """
        Provide either a filename or raw binary data.
        - mask : Optional, may be either binary data or filename
        """
        self.size = (0, 0)
        self.channels = 0
        if file:
            self.load_file(file)
        elif data:
            self.load_data(data)
        elif image:
            self._load_pillow_image(image)
        else:
            raise AttributeError("Neither data nor file provided.")
        if mask:
            if isinstance(mask, bytes):
                self.load_mask(data=mask)
            else:
                self.load_mask(file=mask)

    def load_file(self, fname: str) -> None:
        with open(fname, "rb") as fp:
            if determine_file_ext(fp.read(8)) in ["png", "jp2"]:
                self._load_png(fname)
                return
            # else
            fp.seek(0)
            data = fp.read()
        try:
            self.load_data(data)
            return
        except Exception as e:
            tmp = e  # ignore previous exception to create a new one
        raise type(tmp)('{} File: "{}"'.format(str(tmp), fname))

    def load_data(self, data: bytes) -> None:
        """Has support for ARGB and RGB-channels files."""
        is_argb = data[:4] == b"ARGB"
        if is_argb or data[:4] == b"\x00\x00\x00\x00":
            data = data[4:]  # remove ARGB and it32 header

        uncompressed_data = unpack(data)

        self.channels = 4 if is_argb else 3
        per_channel = len(uncompressed_data) // self.channels
        w = sqrt(per_channel)
        if w != int(w):
            raise NotImplementedError(
                "Could not determine square image size. Or unknown type."
            )
        self.size = (int(w), int(w))
        if self.channels == 3:
            self.a = [255] * per_channel  # opaque alpha channel for rgb
        else:
            self.a = uncompressed_data[:per_channel]
        i = 1 if is_argb else 0
        self.r = uncompressed_data[(i + 0) * per_channel : (i + 1) * per_channel]
        self.g = uncompressed_data[(i + 1) * per_channel : (i + 2) * per_channel]
        self.b = uncompressed_data[(i + 2) * per_channel : (i + 3) * per_channel]

class ParserError(Exception):
    pass


def determine_file_ext(data: bytes) -> Optional[str]:
    """
    Data should be at least 8 bytes long.
    Returns one of: png, argb, plist, jp2, icns, None
    """
    if data[:8] == b"\x89PNG\x0d\x0a\x1a\x0a":
        return "png"
    if data[:4] == b"ARGB":
        return "argb"
    if data[:6] == b"bplist":
        return "plist"
    if data[:8] in [
        b"\x00\x00\x00\x0CjP  ",
        b"\xFF\x4F\xFF\x51\x00\x2F\x00\x00",
    ]:  # JPEG 2000
        return "jp2"
    # if data[:3] == b'\xFF\xD8\xFF':  # JPEG (not supported in icns files)
    #     return 'jpg'
    if data[:4] == b"icns" or is_icns_without_header(data):
        return "icns"  # a rather heavy calculation, postpone till end
    return None


def determine_image_size(
    data: bytes, ext: Optional[str] = None
) -> Optional[Tuple[int, int]]:
    """Supports PNG, ARGB, and Jpeg 2000 image data."""
    if not ext:
        ext = determine_file_ext(data)
    if ext == "png":
        w, h = struct.unpack(">II", data[16:24])
        return w, h
    elif ext == "argb":
        total = get_size(data[4:])  # without ARGB header
        return match_maxsize(total, "argb").size
    elif ext == "rgb":
        if data[:4] == b"\x00\x00\x00\x00":
            data = data[4:]  # without it32 header
        return match_maxsize(get_size(data), "rgb").size
    elif ext == "jp2":
        if data[:4] == b"\xFF\x4F\xFF\x51":
            w, h = struct.unpack(">II", data[8:16])
            return w, h
        len_ftype = struct.unpack(">I", data[12:16])[0]
        # file header + type box + header box (super box) + image header box
        offset = 12 + len_ftype + 8 + 8
        h, w = struct.unpack(">II", data[offset : offset + 8])
        return w, h
    return None  # icns does not support other image types except binary


def is_icns_without_header(data: bytes) -> bool:
    """Returns True even if icns header is missing."""
    offset = 0
    for i in range(2):  # test n keys if they exist
        key, size = icns_header_read(data[offset : offset + 8])
        try:
            get(key)
        except NotImplementedError:
            return False
        offset += size
        if offset > len(data) or size == 0:
            return False
        if offset == len(data):
            return True
    return True


def icns_header_read(data: bytes) -> Tuple[Media.KeyT, int]:
    """Returns icns type name and data length (incl. +8 for header)"""
    assert isinstance(data, bytes)
    if len(data) != 8:
        return "", 0
    length = struct.unpack(">I", data[4:])[0]
    try:
        return data[:4].decode("utf8"), length
    except UnicodeDecodeError:
        return data[:4], length  # Fallback to bytes-string key


def icns_header_w_len(key: Media.KeyT, length: int) -> bytes:
    """Adds +8 to length."""
    name = key.encode("utf8") if isinstance(key, str) else key
    return name + struct.pack(">I", length + 8)


def parse_icns_file(fname: str) -> Iterator[Tuple[Media.KeyT, bytes]]:
    """
    Parse file and yield media entries: (key, data)
    :raises:
        ParserError: if file is not an icns file ("icns" header missing)
    """
    with open(fname, "rb") as fp:
        # Check whether it is an actual ICNS file
        magic_num, _ = icns_header_read(fp.read(8))  # ignore total size
        if magic_num != "icns":
            raise ParserError('Not an ICNS file, missing "icns" header.')
        # Read media entries as long as there is something to read
        while True:
            key, size = icns_header_read(fp.read(8))
            if not key:
                break  # EOF
            yield key, fp.read(size - 8)  # -8 header


class IcnsFile:
    __slots__ = ["media", "infile"]

    @staticmethod
    def verify(fname: str) -> Iterator[str]:
        """
        Yields an error message for each issue.
        You can check for validity with `is_invalid = any(obj.verify())`
        """
        all_keys = set()
        bin_keys = set()
        try:
            for key, data in parse_icns_file(fname):
                all_keys.add(key)
                # Check if icns type is known
                try:
                    iType = get(key)
                except NotImplementedError:
                    yield "Unsupported icns type: " + str(key)
                    continue

                ext = determine_file_ext(data)
                if ext is None:
                    bin_keys.add(key)

                # Check whether stored type is an expected file format
                if not (iType.is_type(ext) if ext else iType.is_binary()):
                    yield "Unexpected type for key {}: {} != {}".format(
                        str(key), ext or "binary", iType.types
                    )

                if ext in ["png", "jp2", "icns", "plist"]:
                    continue

                # Check whether uncompressed size is equal to expected maxsize
                if key == "it32" and data[:4] != b"\x00\x00\x00\x00":
                    # TODO: check whether other it32 headers exist
                    yield "Unexpected it32 data header: " + str(data[:4])
                udata = iType.decompress(data, ext) or data

                # Check expected uncompressed maxsize
                if iType.maxsize and len(udata) != iType.maxsize:
                    yield "Invalid data length for {}: {} != {}".format(
                        str(key), len(udata), iType.maxsize
                    )
        # if file is not an icns file
        except ParserError as e:
            yield str(e)
            return

        # Check total size after enum. Enum may raise exception and break early
        with open(fname, "rb") as fp:
            _, header_size = icns_header_read(fp.read(8))
        actual_size = os.path.getsize(fname)
        if header_size != actual_size:
            yield "header file-size != actual size: {} != {}".format(
                header_size, actual_size
            )

        # Check key pairings
        for img, mask in enum_img_mask_pairs(bin_keys):
            if not img or not mask:
                if not img:
                    img, mask = mask, img
                yield "Missing key pair: {} found, {} missing.".format(mask, img)

        # Check duplicate image dimensions
        for x, y in [
            ("is32", "icp4"),
            ("il32", "icp5"),
            ("it32", "ic07"),
            ("ic04", "icp4"),
            ("ic05", "icp5"),
        ]:
            if x in all_keys and y in all_keys:
                yield "Redundant keys: {} and {} have identical size.".format(x, y)

    def __init__(self, file: Optional[str] = None) -> None:
        """Read .icns file and load bundled media files into memory."""
        self.media = {}  # type: Dict[Media.KeyT, bytes]
        self.infile = file
        if not file:  # create empty image
            return
        for key, data in parse_icns_file(file):
            self.media[key] = data
            try:
                get(key)
            except NotImplementedError:
                print(
                    'Warning: unknown media type: {}, {} bytes, "{}"'.format(
                        str(key), len(data), file
                    ),
                    file=sys.stderr,
                )

    def has_toc(self) -> bool:
        return "TOC " in self.media.keys()

    def export(
        self,
        outdir: Optional[str] = None,
        *,
        allowed_ext: str = "*",
        key_suffix: bool = False,
        convert_png: bool = False,
        decompress: bool = False,
        recursive: bool = False,
    ) -> Dict[Media.KeyT, Union[str, Dict]]:
        """
        Write all bundled media files to output directory.

        - outdir : If none provided, use same directory as source file.
        - allowed_ext : Export only data with matching extension(s).
        - key_suffix : If True, use icns type instead of image size filename.
        - convert_png : If True, convert rgb and argb images to png.
        - decompress : Only relevant for ARGB and 24-bit binary images.
        - recursive : Repeat export for all attached icns files.
                      Incompatible with png_only flag.
        """
        if not outdir:  # aka, determine by input file
            # Determine filename and prepare output directory
            outdir = (self.infile or "in-memory.icns") + ".export"
            os.makedirs(outdir, exist_ok=True)
        elif not os.path.isdir(outdir):
            raise OSError('"{}" is not a directory. Abort.'.format(outdir))

        export_files = {}  # type: Dict[Media.KeyT, Union[str, Dict]]
        if self.infile:
            export_files["_"] = self.infile
        keys = list(self.media.keys())
        # Convert to PNG
        if convert_png:
            for imgk, maskk in enum_png_convertable(keys):
                fname = self._export_to_png(outdir, imgk, maskk, key_suffix)
                if not fname:
                    continue
                export_files[imgk] = fname
                if maskk:
                    export_files[maskk] = fname
                    if maskk in keys:
                        keys.remove(maskk)
                keys.remove(imgk)

        # prepare filter
        allowed = [] if allowed_ext == "*" else allowed_ext.split(",")
        if recursive:
            cleanup = allowed and "icns" not in allowed
            if cleanup:
                allowed.append("icns")

        # Export remaining
        for key in keys:
            fname = self._export_single(outdir, key, key_suffix, decompress, allowed)
            if fname:
                export_files[key] = fname

        # repeat for all icns
        if recursive:
            for old_key, old_name in export_files.items():
                assert isinstance(old_name, str)
                if not old_name.endswith(".icns") or old_key == "_":
                    continue
                export_files[old_key] = IcnsFile(old_name).export(
                    allowed_ext=allowed_ext,
                    key_suffix=key_suffix,
                    convert_png=convert_png,
                    decompress=decompress,
                    recursive=True,
                )
                if cleanup:
                    os.remove(old_name)
        return export_files

    def _export_single(
        self,
        outdir: str,
        key: Media.KeyT,
        key_suffix: bool,
        decompress: bool,
        allowed: List[str],
    ) -> Optional[str]:
        """You must ensure that keys exist in self.media"""
        data = self.media[key]
        ext = determine_file_ext(data)
        if ext == "icns" and data[:4] != b"icns":
            header = icns_header_w_len(b"icns", len(data))
            data = header + data  # Add missing icns header
        try:
            iType = get(key)
            fname = iType.filename(key_only=key_suffix)
            if decompress:
                data = iType.decompress(data, ext) or data  # type: ignore
            if not ext:  # overwrite ext after (decompress requires None)
                ext = "rgb" if iType.compressable else "bin"
        except NotImplementedError:  # If key unkown, export anyway
            fname = str(key)  # str() because key may be binary-str
            if not ext:
                ext = "unknown"

        if allowed and ext not in allowed:
            return None
        fname = os.path.join(outdir, fname + "." + ext)
        with open(fname, "wb") as fp:
            fp.write(data)
        return fname

    def _export_to_png(
        self,
        outdir: str,
        img_key: Media.KeyT,
        mask_key: Optional[Media.KeyT],
        key_suffix: bool,
    ) -> Optional[str]:
        """You must ensure key and mask_key exists!"""
        data = self.media[img_key]
        if determine_file_ext(data) not in ["argb", None]:
            return None  # icp4 and icp5 can have png or jp2 data
        iType = get(img_key)
        fname = iType.filename(key_only=key_suffix, size_only=True)
        fname = os.path.join(outdir, fname + ".png")
        if iType.bits == 1:
            ArgbImage.from_mono(data, iType).write_png(fname)
        else:
            mask_data = self.media[mask_key] if mask_key else None
            ArgbImage(data=data, mask=mask_data).write_png(fname)
        return fname

    def __repr__(self) -> str:
        lst = ", ".join(str(k) for k in self.media.keys())
        return "<{}: file={}, [{}]>".format(type(self).__name__, self.infile, lst)

    def __str__(self) -> str:
        return (
            "File: "
            + (self.infile or "-mem-")
            + os.linesep
            + IcnsFile._description(self.media.items(), indent=2)
        )


def cli_extract(args: ArgParams) -> None:
    """Read and extract contents of icns file(s)."""
    multiple = len(args.file) > 1 or "-" in args.file
    for i, fname in enumerate(enum_with_stdin(args.file)):
        # PathExist ensures that all files and directories exist
        out = args.export_dir
        if out and multiple:
            out = os.path.join(out, str(i))
            os.makedirs(out, exist_ok=True)

        IcnsFile(fname).export(
            out,
            allowed_ext="png" if args.png_only else "*",
            recursive=args.recursive,
            convert_png=args.convert,
            key_suffix=args.keys,
        )

def enum_with_stdin(file_arg: List[str]) -> Iterator[str]:
    for x in file_arg:
        if x == "-":
            for line in sys.stdin.readlines():
                yield line.strip()
        elif x.lower().endswith(".iconset"):  # enum directory content
            allowed_ext = supported_extensions()
            for fname in os.listdir(x):
                if os.path.splitext(fname)[1][1:].lower() in allowed_ext:
                    yield os.path.join(x, fname)
        else:
            yield x


def main() -> None:
    class PathExist:
        def __init__(self, kind: str, *, stdin: bool = False):
            self.kind, *self.allowed_ext = kind.split("|")
            self.stdin = stdin

        def __call__(self, path: str) -> str:
            if self.stdin and path == "-":
                return "-"
            if (
                not os.path.exists(path)
                or self.kind == "f"
                and not os.path.isfile(path)
                or self.kind == "d"
                and not os.path.isdir(path)
            ):
                if os.path.splitext(path)[1].lower() in self.allowed_ext:
                    return path
                raise ArgumentTypeError('Does not exist "{}"'.format(path))
            return path

    # Args Parser
    parser = ArgumentParser(description=__doc__)
    parser.set_defaults(func=lambda _: parser.print_help(sys.stdout))
    sub_parser = parser.add_subparsers(metavar="command", dest="command")

    # helper method
    def add_command(
        name: str, aliases: List[str], fn: Callable[[ArgParams], None]
    ) -> ArgumentParser:
        desc = fn.__doc__ or ""
        cmd = sub_parser.add_parser(
            name, aliases=aliases, help=desc, description=desc.strip()
        )
        cmd.set_defaults(func=fn)
        return cmd

    # Extract
    cmd = add_command("extract", ["e"], cli_extract)
    cmd.add_argument(
        "-r",
        "--recursive",
        action="store_true",
        help="extract nested icns files as well",
    )
    cmd.add_argument(
        "-o",
        "--export-dir",
        type=PathExist("d"),
        metavar="DIR",
        help="set custom export directory",
    )
    cmd.add_argument(
        "-k", "--keys", action="store_true", help="use icns key as filename"
    )
    cmd.add_argument(
        "-c",
        "--convert",
        action="store_true",
        help="convert ARGB and RGB images to PNG",
    )
    cmd.add_argument(
        "--png-only",
        action="store_true",
        help="do not extract ARGB, binary, and meta files",
    )
    cmd.add_argument(
        "file",
        type=PathExist("f", stdin=True),
        nargs="+",
        metavar="FILE",
        help="One or more .icns files",
    )

    args = parser.parse_args()
    args.func(args)


if __name__ == "__main__":
    main()
