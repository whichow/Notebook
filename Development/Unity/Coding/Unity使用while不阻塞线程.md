``` prettyprint
IEnumerator DownloadAndCache () {      // Wait for the Caching system to be ready           while (!Caching.ready)              yield return null;}
```


