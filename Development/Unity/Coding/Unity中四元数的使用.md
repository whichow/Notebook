Unity的transform的rotation等于从根节点到该节点的所有父节点的localRotation四元数相乘，如一个有两级父节点的transform：
<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
Debug.Log(transform.rotation);//等于Debug.Log(transform.parent.parent.localRotation * transform.parent.localRotation * transform.localRotation);
```

</div>

<div>

\

</div>

</div>
