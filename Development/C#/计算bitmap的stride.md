``` prettyprint
int bitsPerPixel = ((int)format & 0xff00) >> 8;
int bytesPerPixel = (bitsPerPixel + 7) / 8;
int stride = 4 * ((width * bytesPerPixel + 3) / 4);
```
