# C\# HTTP GET and POST requests
There are several ways to perform GET and POST requests:

---

**Method 1: Legacy**

```csharp
using System.Net;
using System.Text;  // for class Encoding
```

*POST*

```csharp
var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");

var postData = "thing1=hello";
    postData += "&thing2=world";var data = Encoding.ASCII.GetBytes(postData);

request.Method = "POST";
request.ContentType = "application/x-www-form-urlencoded";
request.ContentLength = data.Length;

using (var stream = request.GetRequestStream()){
    stream.Write(data, 0, data.Length);}

var response = (HttpWebResponse)request.GetResponse();

var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
```

*GET*

```csharp
var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");

var response = (HttpWebResponse)request.GetResponse();

var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
```

------------------------------------------------------------------------

**Method 2: WebClient (Also now legacy)**

```csharp
using System.Net;
using System.Collections.Specialized;
```

*POST*

```csharp
using (var client = new WebClient()){
    var values = new NameValueCollection();
    values["thing1"] = "hello";
    values["thing2"] = "world";

    var response = client.UploadValues("http://www.example.com/recepticle.aspx", values);

    var responseString = Encoding.Default.GetString(response);}
```

*GET*

```csharp
using (var client = new WebClient()){
    var responseString = client.DownloadString("http://www.example.com/recepticle.aspx");}
```

------------------------------------------------------------------------

**Method 3: HttpClient**

Currently the preferred approach. Asynchronous. Ships with .NET 4.5; portable version for other platforms available via [NuGet](https://www.nuget.org/packages/Microsoft.Net.Http).

```csharp
using System.Net.Http;
```

*POST*

```csharp
using (var client = new HttpClient()){
    var values = new Dictionary<string, string>
    {
       { "thing1", "hello" },
       { "thing2", "world" }
    };

    var content = new FormUrlEncodedContent(values);

    var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

    var responseString = await response.Content.ReadAsStringAsync();}
```

*GET*

```csharp
using (var client = new HttpClient()){
    var responseString = client.GetStringAsync("http://www.example.com/recepticle.aspx");}
```

------------------------------------------------------------------------

**Method 4: 3rd-Party Libraries**

***[RestSharp](https://github.com/restsharp/RestSharp)***

Tried and tested library for interacting with REST APIs. Portable. Available via [NuGet](https://www.nuget.org/packages/RestSharp).

***[Flurl.Http](http://tmenier.github.io/Flurl/)***

Newer library sporting a fluent API and testing helpers. HttpClient under the hood. Portable. Available via [NuGet](https://www.nuget.org/packages/Flurl.Http).

```csharp
using Flurl.Http;
```

*POST*

```csharp
var responseString = await "http://www.example.com/recepticle.aspx"
    .PostUrlEncodedAsync(new { thing1 = "hello", thing2 = "world" })
    .ReceiveString();
```

*GET*

```csharp
var responseString = await "http://www.example.com/recepticle.aspx"
    .GetStringAsync();
```

