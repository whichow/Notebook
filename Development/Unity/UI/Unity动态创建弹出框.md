使用Action可以不用预先绑定弹出框的按钮事件，而是在需要弹出框的时候动态绑定：

``` csharp
public class PopupPanel : MonoBehaviour {  
    public Button buttonYes; 
    public Button buttonNo; 
    private Action actionYes;    
    private Action actionNo;    
    public void SetActions(Action actionYes, Action actionNo)    {        
        this.actionYes = actionYes;     
        this.actionNo = actionNo;   
    }   
    public void Yes()   {        
        if (actionYes != null) {            
            actionYes.Invoke ();      
        }    
    }   
    public void No()    {        
        if (actionNo != null) {         
            actionNo.Invoke ();       
        }    
    }
}
//In other class  
public void OpenPopupPanel()    {        
    popupPanel.gameObject.SetActive (true);       
    popupPanel.SetActions (()=>{           
        //Somthing button yes to do;     
    }, ()=>{            
        //Somthing button no to do;      
    });  
}
```


