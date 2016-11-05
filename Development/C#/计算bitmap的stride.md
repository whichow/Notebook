``` {.prettyprint .prettyprinted style="margin-top: 0px; margin-bottom: 0px; padding: 2px; border: 1px solid rgb(136, 136, 136); font-size: 14px; vertical-align: baseline; list-style-type: none; word-wrap: normal; direction: ltr; overflow-y: visible; overflow-x: auto; min-height: 70px; color: rgb(102, 102, 102); line-height: 21px; background-color: rgb(255, 255, 255);"}
int bitsPerPixel = ((int)format & 0xff00) >> 8;
int bytesPerPixel = (bitsPerPixel + 7) / 8;
int stride = 4 * ((width * bytesPerPixel + 3) / 4);
```
