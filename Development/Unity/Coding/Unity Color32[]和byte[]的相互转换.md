**1.**

``` csharp
public static byte[] ColorsToBytes(Color32[] colors)
{    
    if (colors == null && colors.Length == 0)    
    {        
        return null;    
    }    
    int size = Marshal.SizeOf(typeof (Color32));    
    int length = size * colors.Length;    
    byte[] bytes = new byte[length];    
    GCHandle handle = GCHandle.Alloc(colors, GCHandleType.Pinned);    
    IntPtr ptr = handle.AddrOfPinnedObject();    
    Marshal.Copy(ptr, bytes, 0, length);    
    handle.Free();    
    return bytes;
}
public static Color32[] BytesToColors(byte[] bytes)
{    
    if (bytes == null && bytes.Length == 0)    
    {        
        return null;    
    }    
    int length = bytes.Length;    
    int size = Marshal.SizeOf(typeof (Color32));    
    Color32[] colors = new Color32[length / size];    
    GCHandle handle = GCHandle.Alloc(colors, GCHandleType.Pinned);    
    IntPtr ptr = handle.AddrOfPinnedObject();    
    Marshal.Copy(bytes, 0, ptr, length);    
    handle.Free();    
    return colors;
}
```

**2.**

``` csharp
public static Color[] BytesToColors(byte[] bytes)
{    
    Color[] colors = new Color[bytes.Length / 4];    
    for (int i = 0; i < colors.Length; i++)    
    {        
        Color color = new Color(bytes[i * 4 + 0], bytes[i * 4 + 1], bytes[i * 4 + 2], bytes[i * 4 + 3]);        
        colors[i] = color;    
    }    
    return colors;
}
public static byte[] ColorsToBytes(Color[] colors)
{    
    byte[] bytes = new byte[colors.Length * 4];    
    for (int i = 0; i < colors.Length; i++)    
    {        
        bytes[i * 4] = colors[i].r;        
        bytes[i * 4 + 1] = colors[i].g;        
        bytes[i * 4 + 2] = colors[i].b;        
        bytes[i * 4 + 3] = colors[i].a;    
    }    
    return bytes;
}
```

**3.**

``` csharp
unsafe {    
    byte *ptr = (byte *)buffer.ToPointer();    
    int offset = 0;    
    for (int i=0; i<height; i++)    
    {        
        for (int j=0; j<width; j++)        
        {            
            float b = (float)ptr[offset+0] / 255.0f;            
            float g = (float)ptr[offset+1] / 255.0f;            
            float r = (float)ptr[offset+2] / 255.0f;            
            float a = (float)ptr[offset+3] / 255.0f;            
            offset += 4;            
            Color color = new Color(r, g, b, a);            
            texture.SetPixel(j, height-i, color);        
        }    
    }
}
```


