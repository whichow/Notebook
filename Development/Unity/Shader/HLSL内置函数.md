abs                         计算输入值的绝对值。

acos                        返回输入值反余弦值。

all                           测试非0值。

any                         测试输入值中的任何非零值。

asin                         返回输入值的反正弦值。

atan                        返回输入值的反正切值。

atan2                       返回y/x的反正切值。

ceil                         返回大于或等于输入值的最小整数。

clamp                      把输入值限制在[min, max]范围内。

clip                         如果输入向量中的任何元素小于0，则丢弃当前像素。

cos                         返回输入值的余弦。

cosh                       返回输入值的双曲余弦。

cross                      返回两个3D向量的叉积。

ddx                         返回关于屏幕坐标x轴的偏导数。

ddy                         返回关于屏幕坐标y轴的偏导数。

degrees                   弧度到角度的转换

determinant              返回输入矩阵的值。

distance                   返回两个输入点间的距离。

dot                          返回两个向量的点积。

exp                         返回以e为底数，输入值为指数的指数函数值。

exp2                       返回以2为底数，输入值为指数的指数函数值。

faceforward             检测多边形是否位于正面。

floor                       返回小于等于x的最大整数。

fmod                       返回a / b的浮点余数。

frac                        返回输入值的小数部分。

frexp                       返回输入值的尾数和指数

fwidth                     返回 abs ( ddx (x) + abs ( ddy(x))。

isfinite                     如果输入值为有限值则返回true，否则返回false。

isinf                        如何输入值为无限的则返回true。

isnan                       如果输入值为NAN或QNAN则返回true。

ldexp                       frexp的逆运算，返回 x * 2 ^ exp。

len / lenth                返回输入向量的长度。

lerp                         对输入值进行插值计算。

lit                            返回光照向量（环境光，漫反射光，镜面高光，1）。

log                          返回以e为底的对数。

log10                      返回以10为底的对数。

log2                        返回以2为底的对数。

max                        返回两个输入值中较大的一个。

min                         返回两个输入值中较小的一个。

modf                       把输入值分解为整数和小数部分。

mul                         返回输入矩阵相乘的积。

normalize                 返回规范化的向量，定义为 x / length(x)。

pow                        返回输入值的指定次幂。

radians                    角度到弧度的转换。

reflect                     返回入射光线i对表面法线n的反射光线。

refract                     返回在入射光线i，表面法线n，折射率为eta下的折射光线v。

round                      返回最接近于输入值的整数。

rsqrt                       返回输入值平方根的倒数。

saturate                   把输入值限制到[0, 1]之间。

sign                        计算输入值的符号。

sin                          计算输入值的正弦值。

sincos                     返回输入值的正弦和余弦值。

sinh                        返回x的双曲正弦。

smoothstep              返回一个在输入值之间平稳变化的插值。

sqrt                         返回输入值的平方根。

step                        返回（x >= a）? 1 : 0。

tan                          返回输入值的正切值。

fanh                        返回输入值的双曲线切线。

transpose                 返回输入矩阵的转置。

tex1D*                    1D纹理查询。

tex2D*                    2D纹理查询。

tex3D*                    3D纹理查询。

texCUBE*                立方纹理查询。