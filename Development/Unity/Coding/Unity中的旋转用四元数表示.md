<div>

<div>

用四元数(x, y, z, w)=(**v**, w)用来表示一个点绕向量**v**=(x, y,
z)旋转θ角：(**v**\*sin(θ/2) , cos(θ/2))=(vx\*sin(θ/2), vy\*sin(θ/2),
vz\*sin(θ/2), cos(θ/2))

</div>

<div>

\

</div>

<div>

<span style="line-height: 1.6;">绕Y轴(0, 1, 0)旋转90°</span>

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
float theta = 90;transform.localRotation = new Quaternion(0, Mathf .Sin(theta/2 * Mathf .Deg2Rad), 0, Mathf.Cos(theta/2 * Mathf .Deg2Rad));//等同于transform.eulerAngles = new Vector3(0, 90, 0);//等同于transform.localRotation = Quaternion.Euler(0, 90, 0);//等同于transform.localRotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
```

</div>

<div>

<span style="line-height: 1.6;">绕(1, 1, 1)旋转30°</span>

</div>

<div>

``` {.prettyprint .linenums .prettyprinted}
float theta = 30;//需要归一化Vector3 normalized = new Vector3(1, 1, 1).normalized;transform.localRotation = new Quaternion(Mathf.Sin(theta/2 * Mathf.Deg2Rad) * normalized.x, Mathf .Sin(theta/2 * Mathf .Deg2Rad) * normalized.y, Mathf.Sin(theta/2 * Mathf.Deg2Rad) * normalized.z, Mathf.Cos(theta/2 * Mathf .Deg2Rad));//等同于transform.localRotation = Quaternion.AngleAxis(30, new Vector3(1, 1, 1));
```

</div>

<div>

\

</div>

</div>
