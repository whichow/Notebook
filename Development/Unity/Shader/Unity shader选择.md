Unity shader选择
如果你的shader需要呈现光照和阴影效果，则最好的选择是surface shader。surface shader使得用一种紧凑的方式来写复杂的shader变得很简单。它在一个更高的抽象层次和unity光照管线进行交互。大多数surface shader自动支持forward和deferred光照。你在一对Cg/HLSL行之间写surface shader，更多的代码将会自动生成。当你不需要光照的时候不要使用surface shader，因为那样会做大量的光照计算。

当你的shader不需要和光照交互时可以使用vertex和fragment shader，或者当你需要一些surface shader无法处理的奇怪效果的时候。用这种方式来写shader是一种更加灵活的方法来创建你需要的效果（即使它们将自动转换成一堆vertex和fragment shader）。但是这样你必须些更多的代码，而且很难和光照交互。这些shader也是用Cg/HLSL写的。

固定功能shader使用传统的shader句法用来创建非常简单的效果。使用可编程的shader是明智的，因为它允许更灵活也可以在更多的平台上运行（例如，控制台程序不支持固定功能shader语法）。固定功能shader完全用一种叫做ShaderLab的语言，它非常类似于Microsofe的.FX和NVIDIA的CgFx。

不管你选择哪种方式，shader代码的内容都将包裹在ShaderLab中来组织shader的结构，就像这样：

Shader "MyShader" {   

    Properties {       

        \_MyTexture ("My Texture", 2D) = "white" { }        // other properties like colors or vectors go here as well   

    }   

    SubShader {       

        // here goes the 'meat' of your       

        // - surface shader or       

        // - vertex and fragment shader or       

        // - fixed function shader   

    }   

    SubShader {       

        // here goes a simpler version of the SubShader above that       

        // can run on older graphics cards   

    }

}


