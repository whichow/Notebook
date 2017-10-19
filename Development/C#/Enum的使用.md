```cs
public enum UILayer
{
    Background,
    Normal,
    Popup,
    Mask
}
```
转成字符串
```cs
UILayer.Normal.ToString();  //"Normal"
```
获取enum所有值
```cs
System.Enum.GetValues(typeof(UILayer));  //[0, 1, 2, 3]
(UILayer[])System.Enum.GetValues(typeof(UILayer));  //[UILayer.Background, UILayer.Normal, UILayer.Popup, UILayer.Mask]
```
获取enum所有值的字符串
```cs
Enum.GetNames(typeof(UILayer)); //["Background", "Normal", "Popup", "Mask"]
```
解析字符串到enum
```cs
Enum.Parse(typeof(UILayer), "Popup")    //UILayer.Popup
```