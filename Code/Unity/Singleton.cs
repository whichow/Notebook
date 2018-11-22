using System;

public class Singleton<T> where T : Singleton<T>, new()
{
    private static T instance = null;
    protected static readonly object lockObject = new object();

    protected Singleton()
    {
    }
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance<T>();
                    }
                }
            }
            return instance;
        }
    }
}