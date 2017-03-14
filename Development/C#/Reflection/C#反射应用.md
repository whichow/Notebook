我们都知道C#中有反射机制，但是一般很少使用，也不清楚该用在什么地方，下面我们来举个常用到反射情况的例子

比如说有一个类，是一个其他继承自同一个类的类型的集合，但是并没有用将它们放到数组等集合中，这时候如果想要遍历这些内容就需要用到反射了。
```csharp
public class DevInfoSet

{
    public SinaWeiboDevInfo sinaweibo;
    public TencentWeiboDevInfo tencentweibo;
    public Facebook facebook;
    public Twitter twitter;
    public Email email;
    public ShortMessage shortMessage;
    public Douban douban;
    public Renren renren;
    public GooglePlus googlePlus;
    public KaiXin kaiXin;
    public Pocket pocket;
    public Instagram instagram;
    public LinkedIn linkedIn;
    public Tumblr tumblr;
    public YouDao youDao;
    public Flickr flickr;
    public Evernote evernote;
    public WhatsApp whatsApp;
    public Line line;
    public Dropbox dropbox;
    public VKontakte vkontakte;
    public Pinterest pinterest;
    public Mingdao mingdao;
    public KakaoTalk kakaoTalk;
    public KakaoStory kakaoStory;
    public QQ qq;
    public QZone qzone;
    public WeChat wechat;
    public WeChatMoments wechatMoments; 
    public WeChatFavorites wechatFavorites;
    public Yixin yixin;
    public YixinMoments yixinMoments;
    public FacebookMessenger facebookMessenger;
    public Instapaper instapaper;
    public Alipay alipay;
    public AlipayMoments alipayMoments;
    public Dingding dingTalk;
    public Youtube youtube;
    public MeiPai meiPai;

    #if UNITY_ANDROID
    public FourSquare fourSquare;
    #elif UNITY_IPHONE		
    public Copy copy;
    public YixinFavorites yixinFavorites;					//易信收藏，仅iOS端支持							[仅支持iOS端]
    public YixinSeries yixinSeries;							//iOS端易信系列, 可直接配置易信三个子平台			[仅支持iOS端]
    public WechatSeries wechatSeries;						//iOS端微信系列, 可直接配置微信三个子平台 		[仅支持iOS端]
    public QQSeries qqSeries;								//iOS端QQ系列,  可直接配置QQ系列两个子平台		[仅支持iOS端]
    public KakaoSeries kakaoSeries;							//iOS端Kakao系列, 可直接配置Kakao系列两个子平台	[仅支持iOS端]
    public EvernoteInternational evernoteInternational;		//iOS配置印象笔记国内版在Evernote中配置;国际版在EvernoteInternational中配置												 
    //安卓配置印象笔记国内与国际版直接在Evernote中配置														
    #endif

}
```
以下是基类和这些类型的定义
```csharp
public class DevInfo 
{	
    public bool Enable = true;
}

[Serializable]
public class SinaWeiboDevInfo : DevInfo 
{
    #if UNITY_ANDROID
    public const int type = (int) PlatformType.SinaWeibo;
    public string SortId = "4";
    public string AppKey = "568898243";
    public string AppSecret = "38a4f8204cc784f81f9f0daaf31e02e3";
    public string RedirectUrl = "http://www.sharesdk.cn";
    public bool ShareByAppClient = false;
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.SinaWeibo;
    public string app_key = "568898243";
    public string app_secret = "38a4f8204cc784f81f9f0daaf31e02e3";
    public string redirect_uri = "http://www.sharesdk.cn";
    public string auth_type = "both";	//can pass "both","sso",or "web"  
    #endif
}

[Serializable]
public class TencentWeiboDevInfo : DevInfo 
{
    #if UNITY_ANDROID
    public const int type = (int) PlatformType.TencentWeibo;
    public string SortId = "3";
    public string AppKey = "801307650";
    public string AppSecret = "ae36f4ee3946e1cbb98d6965b0b2ff5c";
    public string RedirectUri = "http://sharesdk.cn";
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.TencentWeibo;
    public string app_key = "801307650";
    public string app_secret = "ae36f4ee3946e1cbb98d6965b0b2ff5c";
    public string redirect_uri = "http://sharesdk.cn";
    #endif
}

[Serializable]
public class QQ : DevInfo 
{
    #if UNITY_ANDROID
    public const int type = (int) PlatformType.QQ;
    public string SortId = "2";
    public string AppId = "100371282";
    public string AppKey = "aed9b0303e3ed1e27bae87c33761161d";
    public bool ShareByAppClient = true;
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.QQ;
    public string app_id = "100371282";
    public string app_key = "aed9b0303e3ed1e27bae87c33761161d";
    public string auth_type = "both";  //can pass "both","sso",or "web" 
    #endif
}

[Serializable]
public class QZone : DevInfo 
{
    #if UNITY_ANDROID
    public string SortId = "1";
    public const int type = (int) PlatformType.QZone;
    public string AppId = "100371282";
    public string AppKey = "ae36f4ee3946e1cbb98d6965b0b2ff5c";
    public bool ShareByAppClient = true;
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.QZone;
    public string app_id = "100371282";
    public string app_key = "aed9b0303e3ed1e27bae87c33761161d";
    public string auth_type = "both";  //can pass "both","sso",or "web" 
    #endif
}



[Serializable]
public class WeChat : DevInfo 
{	
    #if UNITY_ANDROID
    public string SortId = "5";
    public const int type = (int) PlatformType.WeChat;
    public string AppId = "wx4868b35061f87885";
    public string AppSecret = "64020361b8ec4c99936c0e3999a9f249";
    public bool BypassApproval = true;
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.WeChat;
    public string app_id = "wx4868b35061f87885";
    public string app_secret = "64020361b8ec4c99936c0e3999a9f249";
    #endif
}

[Serializable]
public class WeChatMoments : DevInfo 
{
    #if UNITY_ANDROID
    public string SortId = "6";
    public const int type = (int) PlatformType.WeChatMoments;
    public string AppId = "wx4868b35061f87885";
    public string AppSecret = "64020361b8ec4c99936c0e3999a9f249";
    public bool BypassApproval = false;
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.WeChatMoments;
    public string app_id = "wx4868b35061f87885";
    public string app_secret = "64020361b8ec4c99936c0e3999a9f249";
    #endif
}

[Serializable]
public class WeChatFavorites : DevInfo 
{
    #if UNITY_ANDROID
    public string SortId = "7";
    public const int type = (int) PlatformType.WeChatFavorites;
    public string AppId = "wx4868b35061f87885";
    public string AppSecret = "64020361b8ec4c99936c0e3999a9f249";
    #elif UNITY_IPHONE
    public const int type = (int) PlatformType.WeChatFavorites;
    public string app_id = "wx4868b35061f87885";
    public string app_secret = "64020361b8ec4c99936c0e3999a9f249";
    #endif
}
...
```
使用反射遍历
```csharp
void Awake()
{				
    print("ShareSDK Awake");
    Type type = devInfo.GetType();
    Hashtable platformConfigs = new Hashtable();
    FieldInfo[] devInfoFields = type.GetFields();
    foreach (FieldInfo devInfoField in devInfoFields) 
    {	
        DevInfo info = (DevInfo) devInfoField.GetValue(devInfo);
        int platformId = (int) info.GetType().GetField("type").GetValue(info);
        FieldInfo[] fields = info.GetType().GetFields();
        Hashtable table = new Hashtable();
        foreach (FieldInfo field in fields) 
        {
            if ("type".EndsWith(field.Name)) {
                continue;
            } else if ("Enable".EndsWith(field.Name) || "ShareByAppClient".EndsWith(field.Name) || "BypassApproval".EndsWith(field.Name)) {
                table.Add(field.Name, Convert.ToString(field.GetValue(info)).ToLower());
            } else {
                table.Add(field.Name, Convert.ToString(field.GetValue(info)));
            }
        }
        platformConfigs.Add(platformId, table);
    }
}
```