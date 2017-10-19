要创建循环列表我们要使用到双向循环链表 

``` cs
public class Node
{    
    public Node previous;    
    public Node next;    
    public Userdata.Character character;    
    public GameObject characherObject;
} 
public class DoubleCircleLinkList
{    
    public Node Current 
    {        
        get;        
        private set;    
    }     
    public void Add (Node node)    
    {        
        if (Count == 0) 
        {            
            Current = node;            
            Current.previous = Current;            
            Current.next = Current;        
        } 
        else 
        {            
            Current.previous.next = node;            
            node.previous = Current.previous;            Current.previous = node;            
            node.next = Current;        
        }        
        Count++;    
    }     
    public void MoveNext()    
    {        
        Current = Current.next;    
    }     
    public void MovePrevious()    
    {        
        Current = Current.previous;    
    }     
    public int Count 
    {        
        get;        
        private set;    
    }
}
```


