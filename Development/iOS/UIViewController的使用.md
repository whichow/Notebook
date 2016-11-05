UIViewController类定义了方法和属性来<span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif;">管理你的视图</span>，事件处理，从一个视图跳转到另一视图，和你的app的其他部分协调。你可以继承UIViewController<span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif;">(或者它的子类)</span>并且增加自定义的代码来实现你的app的行为。

有两种类型的view controller：

-   内容视图控制器(Content view
    controllers)管理你的app的内容的各个部分，是你创建视图控制器的主要类型。

-   容器视图控制器(Contanier view
    controllers)从其他视图控制器中收集信息(称为子视图控制器)并且使用一种便于导航的方式呈现或者用不同的方式呈现这些视图控制器的内容。

\

一个视图控制器最重要的任务是管理视图的层次。每个视图控制器都有一个根视图来包含所有的视图控制器的内容。你添加你需要显示的内容到根视图。图1-1显示了视图控制器和它的视图的内置关系。视图控制器始终有一个到它的根视图的引用，每个视图都有一个到它的子视图的强引用。

<span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif; line-height: 1.6;">Figure
1-1</span><span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif; line-height: 1.6;">Relationship
between a view controller and its views</span>

![image:
../Art/VCPG\_ControllerHierarchy\_fig\_1-1\_2x.png](UIViewController的使用_files/b4a69d8f-85c0-463e-8e2f-f08b874422bf.png){width="475"
height="327"}

<span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif;">内容视图控制器自己管理它</span><span
style="font-family: Helvetica, 'Hiragino Sans GB', 'Microsoft Yahei', SimSun, SimHei, arial, sans-serif;">的所有视图。容器视图控制器通过它的子视图控制器管理它的视图和根视图。容器不管理它的子视图控制器的内容。它只管理根视图，根据容器的设计确定它的大小和位置。图1-2显示了一个拆分的视图控制器和它的子视图。拆分的视图控制器管理它的子视图的整体大小和位置，但是子视图控制器管理这些视图实际的内容。</span>

Figure 1-2View controllers can manage content from other view
controllers

![image:
../Art/VCPG\_ContainerViewController\_fig\_1-2\_2x.png](UIViewController的使用_files/f30f366e-b995-44bc-9881-d07f004be577.png){width="536"
height="540"}

一个视图控制器的行为就像它管理的视图和你的app的数据之间的一个中介。UIViewController类的属性和方法使你能够管理你的app的视觉呈现。当你继承自UIViewController时，你可以在你的子类中增加任何你需要来管理你的数据的变量。增加自定义的变量建立了一个图1-3显示的关系，在视图控制器有引用到你的数据到视图用来呈现数据时。

Figure 1-3A view controller mediates between data objects and views

![image:
../Art/VCPG\_CustomSubclasses\_fig\_1-3\_2x.png](UIViewController的使用_files/990e71e4-9c2f-4f3b-8cc0-c899cabf1ef7.png){width="325"
height="215"}

你应该自始至终保持你的视图控制器和数据对象的分离。

\

