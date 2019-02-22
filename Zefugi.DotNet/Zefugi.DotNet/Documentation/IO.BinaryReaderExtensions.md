# Markdown file

## Overview
Addes a TryRead*(out value) method for each normal Read* method.

### Example code:
```C#
var reader = new System.IO.BinaryReader(myMemoryStream);
if(reader.TryReadBoolean(out bool b))
	Debug.Log("The bool read: " + b);
else
	Debug.Log("There was no bool to be read.");
```

## Wishlist
- Compressed mode (possibly in a new class) where i.e.:
- UInt16 is written as 1 byte if it is lower than 128.
- UInt32 is written as 1 byte if it is lower than 128, 2 bytes if it is lower than 32 768 and 3 bytes if it is lower than 8 388 608.
- Up to 8 booleans are packed into a single byte.
