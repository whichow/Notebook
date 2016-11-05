Unity shader选择
<div>

<div>

如果你的shader需要呈现光照和阴影效果，则最好的选择是surface
shader。surface
shader使得用一种紧凑的方式来写复杂的shader变得很简单。它在<span
style="font-family:">一个更高的抽象层次</span>和unity光照管线进行交互。大多数surface
shader自动支持forward和deferred光照。你在一对Cg/HLSL行之间写surface
shader，更多的代码将会自动生成。当你不需要光照的时候不要使用surface
shader，因为那样会做大量的光照计算。

</div>

<div>

\

</div>

<div>

当你的shader不需要和光照交互时可以使用vertex和fragment
shader，或者当你需要一些surface
shader无法处理的奇怪效果的时候。用这种方式来写shader是一种更加灵活的方法来创建你需要的效果（即使它们将自动转换成一堆vertex和fragment
shader）。但是这样你必须些更多的代码，而且很难和光照交互。这些shader也是用Cg/HLSL写的。

</div>

<div>

\

</div>

<div>

固定功能shader使用传统的shader句法用来创建非常简单的效果。使用可编程的shader是明智的，因为它允许更灵活也可以在更多的平台上运行（例如，控制台程序不支持固定功能shader语法）。固定功能shader完全用一种叫做ShaderLab的语言，它非常类似于Microsofe的.FX和NVIDIA的CgFx。

</div>

<div>

\

</div>

<div>

不管你选择哪种方式，shader代码的内容都将包裹在ShaderLab中来组织shader的结构，就像这样：

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

Shader "MyShader" {   

</div>

<div>

    Properties {       

</div>

<div>

        \_MyTexture ("My Texture", 2D) = "white" { }       
// other properties like colors or vectors go here as well   

</div>

<div>

    }   

</div>

<div>

    SubShader {       

</div>

<div>

        // here goes the 'meat' of your       

</div>

<div>

        // - surface shader or       

</div>

<div>

        // - vertex and fragment shader or       

</div>

<div>

        // - fixed function shader   

</div>

<div>

    }   

</div>

<div>

    SubShader {       

</div>

<div>

        // here goes a simpler version of the SubShader above that    
  

</div>

<div>

        // can run on older graphics cards   

</div>

<div>

    }

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

<span style="font-size: 15px;"><span
style="font-family: monospace;"><span
style="background-color: rgb(240, 240, 240);">\
</span></span></span>

</div>

</div>
