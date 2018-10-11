编译并设置着色器程序
```js
// ShaderUtils.js
var ShaderUtils = {
    shaderPrograms: {},

    setShader: function(sprite, shaderName) {
        var glProgram = this.shaderPrograms[shaderName];
        if (!glProgram) {
            glProgram = new cc.GLProgram();
            var vert = require(cc.js.formatStr("%s.vert", shaderName));
            var frag = require(cc.js.formatStr("%s.frag", shaderName));
            glProgram.initWithString(vert, frag);
            if (!cc.sys.isNative) {  
                glProgram.initWithVertexShaderByteArray(vert, frag);
                glProgram.addAttribute(cc.macro.ATTRIBUTE_NAME_POSITION, cc.macro.VERTEX_ATTRIB_POSITION);  
                glProgram.addAttribute(cc.macro.ATTRIBUTE_NAME_COLOR, cc.macro.VERTEX_ATTRIB_COLOR);  
                glProgram.addAttribute(cc.macro.ATTRIBUTE_NAME_TEX_COORD, cc.macro.VERTEX_ATTRIB_TEX_COORDS);  
            }
            glProgram.link();  
            glProgram.updateUniforms();
            this.shaderPrograms[shaderName] = glProgram;
        }
        sprite._sgNode.setShaderProgram(glProgram);
        return glProgram;
    },
};

module.exports = ShaderUtils;
```
顶点着色器
```glsl
// gray.vert.js
module.exports =
`
attribute vec4 a_position;
attribute vec2 a_texCoord;
attribute vec4 a_color;
varying vec4 v_fragmentColor; 
varying vec2 v_texCoord; 
void main() 
{ 
    gl_Position = CC_PMatrix * a_position;
    v_fragmentColor = a_color; 
    v_texCoord = a_texCoord; 
}
`
```
片段着色器
```glsl
// gray.frag.js
module.exports =
`
#ifdef GL_ES
precision lowp float;
#endif

varying vec4 v_fragmentColor;
varying vec2 v_texCoord;
void main()
{
    vec4 c = v_fragmentColor * texture2D(CC_Texture0, v_texCoord);
    gl_FragColor.xyz = vec3(0.2126*c.r + 0.7152*c.g + 0.0722*c.b);
    gl_FragColor.w = c.w;
}
`
```
使用方法
```js
ShaderUtils.setShader(sprite, "gray");
```

[cocos creator 中使用自定义shader](https://blog.csdn.net/xufeng0991/article/details/72973664)