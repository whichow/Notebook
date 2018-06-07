> Unity在过去几年已经在无数高质量的2D游戏中使用。这篇文章是基于我在韩国日本和中国的三次地区性的Unite开发者会议上所做的演讲，提供了深入的指导，以获得可靠的实际2D制作工作流程。我希望这篇文章可以对我们的任何在使用Unity创建2D游戏和交互内容的读者有所帮助。由于这篇教程的长度限制，我将它分成了两篇博客文章。今天你可以读到关于创作和导出的内容，明天我将发布关于导入的章节。你在文章的最后可以找到链接来下载所有文件。

**一个好的2D内容工作流程的好处**

本教程将指导你完成实际的生产工作流程。当我们讨论工作流程时，它意味着从初始创作到内容实际在游戏中运行的所有步骤和流程。无论在这个链中从开始到结束所需的程序数量，在一个高层次的工作流程中由3个主要步骤组成：创作，导出和导入。

对于某些人来说，由于像Unity这样的工具能够直接导入数据，因此我们既需要导出程序又需要导入程序。我们需要这两者的原因是因为我们基本上创建了我们自己的中间文件格式，作为工作流中任何两个应用程序之间的粘合剂，在这种情况下，在Photoshop和Unity之间。这消除了外部应用程序能够读取和解析应用程序的本机文件格式的需要，并允许应用程序链接，以便在内容从一个应用程序移动到另一个应用程序时处理内容。 

**创作**

这一切都始于优秀的内容，我们要看的第一个工作流程是使用行业标准主力Photoshop。 Photoshop的优点之一就是简单入门。创建和编辑图像和图形是无痛和轻松的，随着您的需求增长，您可以使用一系列工具和技术。问题在于，图像文件本身并没有太多的能力以3D模型能够做到的相同方式表达有用的游戏元数据。更重要的是，2D本身需要更多的元数据，因为它只是像素的有限性质 

因此我们想要做的就是给图像灌输有用的信息以便我们知道怎样在游戏中使用图像。为此，我们可以使用组和层次来组织和标记它们为我们所需要的。

我们还需要一个2D内容的例子，这个例子很有用并且呈现了实际的使用。 我在加入Unity之前工作的最后一个游戏是一个简单的2D的隐藏对象游戏，叫做[Goddess Chronicles](http://www.bigfishgames.com/download-games/9242/goddess-chronicles/index.html)，因此我们将以此来作为一个例子。在一个隐藏物体游戏中，总的想法是找出在场景中隐藏在某个场景中的某些物品，例如下面所示的示例。 

![img](https://blogs.unity3d.com/wp-content/uploads/2013/05/Greek-Hall1.jpg) 

根据你所做的游戏，你需要捕获的元数据是不同的。对于这款游戏，该设计需要两种基本类型的图像：“scenery ”和“items ”。

**层的重要性**

场景是非交互内容，提供大部分的可见内容，通过提供一个物品可以隐藏的环境来传达主题和提供游戏玩法。因此场景将被放置在一个名为“scenery ”的组中，并且我们不需要关心在其中的图层，因为它们是不可交互的。物品是你将在场景中实际搜索的东西并且构成了游戏的核心玩法。这些被放置在名为“item”的组中，不像场景，这些图层很重要并且它们中的每个可以有至多四个唯一的层与它们关联。

**“整体”**层被所有物品所需要。通常情况下一个物品被发现，它将有一些效果，像放大它们，或者将它们放置到玩家的仓库中，并且我们需要整个图像使其看起来是正确的。

**“遮挡”**层被用来当你想要创建物品被东西遮挡的效果当实际上它是浮在它前面的时候。通过擦除应该被隐藏的像素来让人误以为他实际上是在后面的东西。理论上，我们可以使用完整的图像来显示所有东西，但是有许多情况下，艺术家为了隐藏物品而将所有东西都作为独立的部分绘制是乏味的，并且在游戏中使用最少量的图像会提高运行时性能。 

**“阴影”** 层用于帮助将物品直观地放置到场景中，并且看起来像属于那里。阴影与整个图像或模糊图像分开保存，这样如果整个图像放大或移动，它就不会有跟随它的奇怪外观的阴影，相反，只要找到该项目，我们就可以将阴影隐藏在场景中。 

**“热点”** 层用于增加或减少物品可以与之互动的面积。例如，如果你在场景中隐藏高尔夫球杆，则可能很难点击或点按。通过使用热点，您可以使交互区域更大，更易于使用。 

因此，将所有这些放在一起，我们可以使用组来指定场景中的某些内容是场景还是物品，并且我们可以使用图层来保存项目的整个图像，并且可以包含遮挡，阴影和热点图像。下图显示了一些场景和物品的图层。项目组标记为“项目：珠子”，并包含2个称为“整体”和“热点”的图层。场景组被标记为“场景：柱子”，并且它包含任何数量的可以命名为任何东西的图层，因为场景图层并不特殊，我们不需要跟踪它们。 

![Greek-Hall-Layers](https://blogs.unity3d.com/wp-content/uploads/2013/05/Greek-Hall-Layers.jpg)

最终的结果是，我们有一个很好的组合场景，在这个场景中，组和层的名字被编码，我们需要给它们赋予它们在我们的游戏中的意义。您可以在文章末尾下载该软件包并自己寻找。下一步是现在获取所有这些导出。 

**导出**

一旦我们有了一些内容，我们需要一些方法将它全部用于我们工作流程中的下一个应用程序，在这种情况下是Unity。我们想要导出的是用于构建场景的图像以及描述位置，顺序和其他信息的元数据。为了做到这一点，我们需要一种方式来与低层应用程序进行交互，并了解如何实现这一点。对我们来说幸运的是，Photoshop使用JavaScript编写脚本，这将完全符合我们的需求。 

实际上，不少Adobe应用程序都可以编写脚本，包括Fireworks，Illustrator，Flash等。我们可以使用这种功能编写我们自己的导出器，可以准备在Unity中使用的图像，并捕获我们需要的元数据以使其具有意义。 Adobe提供了有用的文档和免费的[ExtendScript](http://www.adobe.com/devnet/scripting.html)的脚本编辑器和调试器。

如果您有Creative Suite，它可能已经安装在您的系统上。在Mac上，可以在Utilities/Adobe Utilities - CS6/ExtendScript Toolkit CS6文件夹中找到最新的Creative Suite。在Windows上，您应该能够在C:\Documents and Settings\\Application Data\Adobe\ExtendScript Toolkit\3.8中找到它。 

在Photoshop中您可以执行的任何操作都可以编写脚本，如果没有针对您要执行的特定事件的API，则可以记录操作并将其转换为可粘贴到脚本中的命令代码（alpha通道操作， 我在看着你！）。 

对于我们的目的，我们需要一个简单的脚本，基本上：

- 检查我们是否有打开的文档，
- 确保文档具有要导出的图层，
- 提示用户应该在哪里放置导出的文件，
- 从后到前循环图层，修剪掉空白空间，将图像保存到磁盘并以XML格式的字符串捕获位置和文件名，
- 最后将XML数据保存到文件中。

最终的导出器脚本在教程包中。要使用该脚本，请将其放置在Photoshop应用程序目录中的Presets/Scripts子目录中。该脚本包含解释它做什么的注释，所以我不会把它全部过一遍，但我会包含一些更重要的部分。 

首先，脚本是用JavaScript编写的，这使得它易于学习和使用。 Adobe使用的JavaScript引擎速度不是很快，但它的工作原理和ExtendScript编辑器可以调试，这使得它非常有用。 

由于元数据实际上是赋予数据含义的部分，因此我们需要花费大量时间精确计算出我们需要的元数据以及如何对其进行格式化。我使用XML作为指定元数据的方式，因为这样可以很容易地在Unity中解析。基于游戏设计，我们知道我们有一些游戏需要的数据。该数据的摘录如下所示： 

```
<?xml version="1.0" encoding="utf-8"?>
<HogScene xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        <layers>
                <Layer>
                        <type>Scenery</type>
                        <name>Scenery 01-4 background</name>
                        <images>
                                <Image>
                                        <type>Whole</type>
                                        <name>Scenery Tree.png</name>
                                        <x>25</x>
                                        <y>63</y>
                                </Image>
                        </images>
                </Layer>
                ...
        </layers>
</HogScene>
```

因此，我们的导出脚本将在导出过程中捕获这些简单的XML元素，并在完成时将其写入文件。 

在我们的导出脚本中，我们首先创建一些我们需要的文件范围变量，然后调用在此之后定义的“main”函数。这个工作的基本方式是，当你运行你的脚本时，它会从上到下进行评估和执行。你可以在互联网上找到一些例子，其中一些代码包含在函数中，有些则不是，我觉得这有点令人困惑。因此，我将所有内容都放入函数中，并根据约定明确地调用入口点。 

在主函数里面，有一些有趣的部分。第一个是这行： 

```
duppedPsd = app.activeDocument.duplicate();
```

强烈建议复制活动文档有两个原因。首先，在Photoshop中，如果触摸文档中的任何内容，即使是展开或折叠组，也会导致文档被标记为脏。所以如果我们没有复制活动文档，导出过程总是会导致它被标记为脏。当艺术家退出Photoshop或关闭文档时，系统会提示他们保存，并且他们可能不记得他们是否对文档进行了更改，并且可能会保存该文档。这将导致文件的时间戳比导出的文件更新，并且一旦检入到版本控制中将会令人困惑，因为设计者，制作者或程序员不知道他们是否需要重新导出文件。这会创建一个无限循环，因为该文件将始终比导出更新。通过复制它会将原始文档保留在原始状态，这仍然可能会导致问题，但那是一个生产过程问题，而不是我们造成的。 

复制文档的第二个原因很简单，就是在创建自己的导出器时出现错误，出错时会使文档处于未知状态。所以通过复制它，我们总是有我们未经修改的主副本。 

在主函数中下一个感兴趣的是： 

```
removeAllTopLevelArtLayers(duppedPsd);
```

由于我们使用组作为我们感兴趣的事物的容器，因此我们可以让艺术家或设计师添加不在任何组中的艺术图层（“顶级”）。他们可以将其用于概念或照片参考，屏幕布局指南或放置游戏HUD等占位符元素。所以我们通过在处理之前删除这些图像来清理重复的文件。 

除此之外，主函数调用导出函数，然后创建并写入包含元数据的XML文件。 

导出函数exportLayerSets是一个递归函数。递归函数意味着如果需要“钻取”到我们的组中以查找场景中最深的最低级别组，则它会自行调用它。 

```
function exportLayerSets(obj)
{
        for(var i = obj.layerSets.length-1; 0 &lt; = i; i--)
        {
                exportLayerSets(obj.layerSets[i]);
        }
        ...
}
```

它通过在组列表中向后循环来完成，如果其中一个组内有一个组，那么它将递归并再次与该组一起再次调用，等等。我们向后循环，因为在Photoshop中，列表中最底层是第一层，列表中较高层的组和层位于较低层之上。所以我们处理所有事情。 

一旦我们有了一个实际的图层，我们就可以查看组名，看它是以“item：”，“custom：”（我们用于HUD元素）开头还是假定为场景。 

```
if(obj.name.search("item:") >= 0)
{
        ...
}
else if(obj.name.search("custom:") >= 0)
{
        ...
}
else // must be a scenery group
{
        ...
}
```

对于项目，我们然后遍历图层，切换图层并导出我们支持的任何已知类型。 

```
// process layers
for(var layerIndex = 0; layerIndex < obj.artLayers.length; layerIndex++)
{
        sceneData += "<Image>";
        obj.artLayers[layerIndex].visible = true;
        switch(obj.artLayers[layerIndex].name)
        {
                case "hotspot":
                        saveScenePng(...);
                break;
                case "obscured":
                        saveScenePng(...);
                break;
                case "shadow":
                        saveScenePng(...);
                break;
                case "whole":
                        saveScenePng(...);
                break;
        }
        obj.artLayers[layerIndex].visible = false;
        sceneData += "</Image>";
}
```

当我们找到想要保存的内容时，我们调用该函数将图像保存为PNG文件。此功能折叠图像并修剪左侧和上侧以确定图像的X和Y坐标。然后我们修剪右下角并保存，并将元数据捕获到XML字符串中。 

```
function saveScenePng(psd, imageType, fileName)
{
        // we should now have a single art layer if all went well
        psd.mergeVisibleLayers();
        // figure out where the top-left corner is so it can be exported
        // into the scene file for placement in game
        // capture current size
        var height = psd.height.value;
        var width = psd.width.value;
        var top = psd.height.value;
        var left = psd.width.value;
        // trim off the top and left
        psd.trim(TrimType.TRANSPARENT, true, true, false, false);
        // the difference between original and trimmed is the amount of offset
        top -= psd.height.value;
        left -= psd.width.value;
        // trim the right and bottom
        psd.trim(TrimType.TRANSPARENT);
        // find center
        top += (psd.height.value / 2)
        left += (psd.width.value / 2)
        // unity needs center of image, not top left
        top = -(top - (height/2));
        left -= (width/2);
        // save the image
        var pngFile = new File(destinationFolder + "/" + fileName + ".png");
        var pngSaveOptions = new PNGSaveOptions();
        psd.saveAs(pngFile, pngSaveOptions, true, Extension.LOWERCASE);
        psd.close(SaveOptions.DONOTSAVECHANGES);

        // save the scene data
        sceneData += ("<type>" + imageType + "</type>
                                <name>" + fileName + ".png</name>
                                <x>" + left + "</x><y>" + top + "</y>");
}
```

当我们在文件上运行导出器时，我们最终应该直接裁剪出PNG文件，再加上与原始文档具有相同基本文件名的XML文件，如下所示。 

![Finder-Exported-Files-cropped](https://blogs.unity3d.com/wp-content/uploads/2013/05/Finder-Exported-Files-cropped1.jpg)

既然我们成功导出了所有的图像和元数据，我们将转到Unity工作流程中的下一个应用程序并导入文件。我将在我的下一篇博客文章中介绍这一点。谢谢！ 

[你可以下载一个包含这篇文章中所有文件的包](https://dl.dropboxusercontent.com/u/46030326/Unity%20Talks/HOG%20Tutorial.unitypackage)