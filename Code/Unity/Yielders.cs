using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 用于生成在协程中使用的WaitForXXX类，避免每次都new一个新的对象
/// </summary>
public static class Yielders {
 
    static Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(100);
 
    static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();
    /// <summary>
    /// 获取一个WaitForEndOfFrame对象
    /// </summary>
    /// <returns></returns>
    public static WaitForEndOfFrame EndOfFrame {
        get{ return _endOfFrame;}
    }
 
    static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();
    /// <summary>
    /// 获取一个WaitForFixedUpdate对象
    /// </summary>
    /// <returns></returns>
    public static WaitForFixedUpdate FixedUpdate{
        get{ return _fixedUpdate; }
    }
    /// <summary>
    /// 获取一个WaitForSeconds对象
    /// </summary>
    /// <param name="seconds">秒数</param>
    /// <returns></returns>
    public static WaitForSeconds Get(float seconds){
        if(!_timeInterval.ContainsKey(seconds))
            _timeInterval.Add(seconds, new WaitForSeconds(seconds));
        return _timeInterval[seconds];
    }
   
}