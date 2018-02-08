有四张UI贴图，按照如下的方式摆放

![](/Images/TIM截图20180208102714.png)
![](/Images/TIM截图20180208102727.png)

在不打图集的情况下,DrawCall为4，没有自动合并DrawCall

如果换成同一张UI贴图，则DrwaCall为1，Unity自动合并了相同图片的DrawCall

![](/Images/TIM截图20180208103402.png)

如果中间插了一张并且是重叠在一起的，DrawCall为3，因为中间插入的不同贴图导致上下的贴图无法合并DrawCall

![](/Images/TIM截图20180208103724.png)
![](/Images/TIM截图20180208104348.png)

如果中间插了一张贴图，但是没有重叠，上下贴图的DrwaCall可以合并，DrawCall为2

![](/Images/TIM截图20180208105023.png)

将所有贴图打成一个图集，无论如何摆放，在中间没有插入其他贴图的情况下，DrawCall始终为1

将贴图打成图集，如果中间插入了未在图集中的贴图或其他图集中的贴图，如果有重叠，则插入贴图的上下贴图无法合并DrawCall，但是上下的贴图可以分别合并DrawCall，如下面的情况DrawCall为3

![](/Images/TIM截图20180208110501.png)
![](/Images/TIM截图20180208110944.png)

如果其他贴图未重叠，则可以合并DrawCall，下面的DrawCall为2

![](/Images/TIM截图20180208110756.png)

在下面的例子中DrawCall为4

![](/Images/TIM截图20180208111737.png)
![](/Images/TIM截图20180208111750.png)

但是经过处理后，DrawCall只有2

![](/Images/TIM截图20180208112024.png)

渲染过程如下

![](/Images/TIM截图20180208112701.png)
![](/Images/TIM截图20180208112731.png)

可以发现Unity会对处于同一层的图集自动合并DrawCall，上面的例子中虽然右边下面有三层，但是被Unity合并了，所以可以认为只有一层。