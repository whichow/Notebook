```csharp
IEnumerator DownloadImg ()
{
    string url = "https://... Your url (Internet url)";
    Texture2D texture = new Texture2D(1,1);
    WWW www = new WWW(url);
    yield return www;
    www.LoadImageIntoTexture(texture);
    StartCoroutine(UploadImg(texture));
}
     
IEnumerator UploadImg(Texture2D texture)
{
    string screenShotURL = "file:///... Your Url to upload ( Device url)";
    byte[] bytes = texture.EncodeToPNG();
    Destroy( texture );
    
    // Create a Web Form
    WWWForm form = new WWWForm();
    form.AddField("frameCount", Time.frameCount.ToString());
    form.AddBinaryData("file", bytes, "Image.png", "image/png");
    
    // Upload to a cgi script
    WWW w = WWW(screenShotURL, form);
    yield return w;
    if (w.error != null){
        print(w.error);
        Application.ExternalCall( "debug", w.error);
        //print(screenShotURL);
    }
    else{
        print("Finished Uploading Screenshot");
        //print(screenShotURL);
        Application.ExternalCall( "debug", "Finished Uploading Screenshot");
    }
}
```