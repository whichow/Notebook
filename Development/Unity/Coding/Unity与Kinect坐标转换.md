![](../../../Images/Unity与Kinect坐标转换_files/98c30079e77108f2c23ab0785b9f0173.png)

``` csharp
var colorSpacePoint = kinectSensor.CoordinateMapper.MapCameraPointToColorSpace(cameraSpacePoint);
//Kinect Color Space从(0, 0)到(1920, 1080)，这里按屏幕高度缩放
float ratio = (float)Screen.height / 1080f;
//Unity屏幕X轴坐标与Kinect Color Space坐标相同，Y轴一个从屏幕左上角开始，一个从屏幕左下角开始
var screenSpacePoint = new Vector3(colorSpacePoint.X * ratio, (1080f - colorSpacePoint.Y) * ratio);
screenSpacePoint.z = cameraSpacePoint.Z * 10f;
var worldPosition = camera.ScreenToWorldPoint(screenSpacePoint);
```


