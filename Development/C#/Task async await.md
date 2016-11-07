``` prettyprint
public static class FileExtensions {   public static Task DeleteAsync(this FileInfo fi) {      return Task.Factory.StartNew(() => fi.Delete() );   }}FileInfo fi = new FileInfo(fileName);await fi.DeleteAsync(); // C# 5fi.DeleteAsync().Wait(); // C# 4
```

task.Wait()，等待改线程执行完

``` prettyprint
class Program{    static Random rand = new Random();    static void Main()    {        // Wait on a single task with no timeout specified.        Task taskA = Task.Run( () => Thread.Sleep(2000));        Console.WriteLine("taskA Status: {0}", taskA.Status);        try {          taskA.Wait();          Console.WriteLine("taskA Status: {0}", taskA.Status);       }        catch (AggregateException) {          Console.WriteLine("Exception in taskA.");       }       }    }
```

Task.WaitAny()，等待任意一个线程完成

``` prettyprint
public class Example{   public static void Main()   {      var tasks = new Task[3];      var rnd = new Random();      for (int ctr = 0; ctr <= 2; ctr++)         tasks[ctr] = Task.Run( () => Thread.Sleep(rnd.Next(500, 3000)));      try {         int index = Task.WaitAny(tasks);         Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);         Console.WriteLine("Status of all tasks:");         foreach (var t in tasks)            Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);      }      catch (AggregateException) {         Console.WriteLine("An exception occurred.");      }   }}
```

Task.WaitAll()，等待所有线程执行完毕

``` prettyprint
public class Example{   public static void Main()   {      // Wait for all tasks to complete.      Task[] tasks = new Task[10];      for (int i = 0; i < 10; i++)      {          tasks[i] = Task.Run(() => Thread.Sleep(2000));      }      try {         Task.WaitAll(tasks);      }      catch (AggregateException ae) {         Console.WriteLine("One or more exceptions occurred: ");         foreach (var ex in ae.Flatten().InnerExceptions)            Console.WriteLine("   {0}", ex.Message);      }         Console.WriteLine("Status of completed tasks:");      foreach (var t in tasks)         Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);   }}
```

使用async和await关键字

``` prettyprint
async Task<int> ProcessURLAsync(string url, HttpClient client){    var byteArray = await client.GetByteArrayAsync(url);    DisplayResults(url, byteArray);    return byteArray.Length;}private void DisplayResults(string url, byte[] content){    // Display the length of each website. The string format     // is designed to be used with a monospaced font, such as    // Lucida Console or Global Monospace.    var bytes = content.Length;    // Strip off the "http://".    var displayURL = url.Replace("http://", "");    resultsTextBox.Text += string.Format("\n{0,-58} {1,8}", displayURL, bytes);}private async Task CreateMultipleTasksAsync(){    // Declare an HttpClient object, and increase the buffer size. The    // default buffer size is 65,536.    HttpClient client =        new HttpClient() { MaxResponseContentBufferSize = 1000000 };    // Create and start the tasks. As each task finishes, DisplayResults     // displays its length.    Task<int> download1 =         ProcessURLAsync("http://msdn.microsoft.com", client);    Task<int> download2 =         ProcessURLAsync("http://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx", client);    Task<int> download3 =         ProcessURLAsync("http://msdn.microsoft.com/en-us/library/67w7t67f.aspx", client);    // Await each task.    int length1 = await download1;    int length2 = await download2;    int length3 = await download3;    int total = length1 + length2 + length3;    // Display the total count for the downloaded websites.    resultsTextBox.Text +=        string.Format("\r\n\r\nTotal bytes returned:  {0}\r\n", total);}
```


