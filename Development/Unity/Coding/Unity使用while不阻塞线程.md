<div>

``` {.prettyprint .linenums .prettyprinted}
IEnumerator DownloadAndCache () {      // Wait for the Caching system to be ready           while (!Caching.ready)              yield return null;}
```

</div>

<div>

\

</div>
