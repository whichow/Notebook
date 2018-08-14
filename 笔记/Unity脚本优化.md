- **能不放在循环里执行的尽量不要放在循环内**，如：

```
void Update()
{
    for (int i = 0; i < myArray.Length; i++)
    {
        if (exampleBool)
        {
            ExampleFunction(myArray[i]);
        }
    }
}
```

修改后：

```
void Update()
{
    if (exampleBool)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            ExampleFunction(myArray[i]);
        }
    }
}
```

- **采用事件而不是在Update里每帧执行**，如：

```
private int score;

public void IncrementScore(int incrementBy)
{
    score += incrementBy;
}

void Update()
{
    DisplayScore(score);
}
```

修改后：

```
private int score;

public void IncrementScore(int incrementBy)
{
    score += incrementBy;
    DisplayScore(score);
}
```

- **分帧执行，将几个任务分在不同帧执行**，如：

```
void Update()
{
    ExampleExpensiveFunction();
    AnotherExampleExpensiveFunction();
}
```

修改后：

```
private int interval = 3;

void Update()
{
    if (Time.frameCount % interval == 0)
    {
        ExampleExpensiveFunction();
    }
    else if (Time.frameCount % interval == 1)
    {
        AnotherExampleExpensiveFunction();
    }
}
```

- **不要每帧获取组件，而应该缓存起来**，如：

```
void Update()
{
    Renderer myRenderer = GetComponent<Renderer>();
    ExampleFunction(myRenderer);
}
```

修改后：

```
private Renderer myRenderer;

void Start()
{
    myRenderer = GetComponent<Renderer>();
}

void Update()
{
    ExampleFunction(myRenderer);
}
```



[Optimizing scripts in Unity games](https://unity3d.com/cn/learn/tutorials/topics/performance-optimization/optimizing-scripts-unity-games)