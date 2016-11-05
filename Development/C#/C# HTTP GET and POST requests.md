C\# HTTP GET and POST requests
<div>

<div
style="margin:0px;padding:0px;border:0px;font-size:15px;width:660px;margin-bottom:5px;word-wrap:break-word;">

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">There are several ways to perform GET
and POST requests:</span></span>

------------------------------------------------------------------------

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">**Method 1: Legacy**</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using System.Net;
using System.Text;  // for class Encoding
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*POST*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
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

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*GET*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
var request = (HttpWebRequest)WebRequest.Create("http://www.example.com/recepticle.aspx");

var response = (HttpWebResponse)request.GetResponse();

var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
```

------------------------------------------------------------------------

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">**Method 2: WebClient (Also now
legacy)**</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using System.Net;
using System.Collections.Specialized;
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*POST*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using (var client = new WebClient()){
    var values = new NameValueCollection();
    values["thing1"] = "hello";
    values["thing2"] = "world";

    var response = client.UploadValues("http://www.example.com/recepticle.aspx", values);

    var responseString = Encoding.Default.GetString(response);}
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*GET*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using (var client = new WebClient()){
    var responseString = client.DownloadString("http://www.example.com/recepticle.aspx");}
```

------------------------------------------------------------------------

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">**Method 3: HttpClient**</span></span>

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">Currently the preferred approach.
Asynchronous. Ships with .NET 4.5; portable version for other platforms
available via</span>
[NuGet](https://www.nuget.org/packages/Microsoft.Net.Http)<span
style="color: rgb(34, 36, 38);">.</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using System.Net.Http;
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*POST*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
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

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*GET*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using (var client = new HttpClient()){
    var responseString = client.GetStringAsync("http://www.example.com/recepticle.aspx");}
```

------------------------------------------------------------------------

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">**Method 4: 3rd-Party
Libraries**</span></span>

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">***[RestSharp](https://github.com/restsharp/RestSharp)***</span></span>

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">Tried and tested library for interacting
with REST APIs. Portable. Available via</span>
[NuGet](https://www.nuget.org/packages/RestSharp)<span
style="color: rgb(34, 36, 38);">.</span></span>

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">***[Flurl.Http](http://tmenier.github.io/Flurl/)***</span></span>

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">Newer library sporting a fluent API and
testing helpers. HttpClient under the hood. Portable. Available
via</span> [NuGet](https://www.nuget.org/packages/Flurl.Http)<span
style="color: rgb(34, 36, 38);">.</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
using Flurl.Http;
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*POST*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
var responseString = await "http://www.example.com/recepticle.aspx"
    .PostUrlEncodedAsync(new { thing1 = "hello", thing2 = "world" })
    .ReceiveString();
```

<span
style="font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;"><span
style="color: rgb(34, 36, 38);">*GET*</span></span>

``` {style="max-height:600px;margin:0px;border:0px;font-size:13px;overflow:auto;width:auto;padding:5px;margin-bottom:1em;font-family:Consolas, Menlo, Monaco, 'Lucida Console', 'Liberation Mono', 'DejaVu Sans Mono', 'Bitstream Vera Sans Mono', 'Courier New', monospace, sans-serif;background-color:rgb(238, 238, 238);display:block;color:rgb(57, 51, 24);word-wrap:normal;"}
var responseString = await "http://www.example.com/recepticle.aspx"
    .GetStringAsync();
```

</div>

+--------------------------------------------------------------------------+
| <div                                                                     |
| style="margin:0px;padding:0px;border:0px;font-size:100%;padding-top:2px; |
| ">                                                                       |
|                                                                          |
| <div>                                                                    |
|                                                                          |
| \                                                                        |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

</div>
