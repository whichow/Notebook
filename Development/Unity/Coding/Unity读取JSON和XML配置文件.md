### 一. 读取JSON配置文件

JSON格式文件
``` json
{
    "scenes": [
        {
            "name":"存款类产品",
            "type":"Images",
            "images":[
                {"path":"存款类产品/img1.png"},
                {"path":"存款类产品/img2.png"},
                {"path":"存款类产品/img3.png"},
                {"path":"存款类产品/img4.png"},
                {"path":"存款类产品/img5.png"},
                {"path":"存款类产品/img6.png"}
            ]
        },
        {
            "name":"理财类产品",
            "type":"Videos",
            "videos":[
                {"coverPath":"理财类产品/Covers/img1.png", "path":"理财类产品/mv1.mp4"},
                {"coverPath":"理财类产品/Covers/img2.png", "path":"理财类产品/mv2.mp4"},
                {"coverPath":"理财类产品/Covers/img3.png", "path":"理财类产品/mv3.mp4"},
                {"coverPath":"理财类产品/Covers/img4.png", "path":"理财类产品/mv4.mp4"},
                {"coverPath":"理财类产品/Covers/img5.png", "path":"理财类产品/mv5.mp4"},
                {"coverPath":"理财类产品/Covers/img6.png", "path":"理财类产品/mv6.mp4"}
            ]
        },
        {
            "name":"信贷类产品",
            "type":"Images",
            "images":[
                {"path":"信贷类产品/img1.png"},
                {"path":"信贷类产品/img2.png"},
                {"path":"信贷类产品/img3.png"},
                {"path":"信贷类产品/img4.png"},
                {"path":"信贷类产品/img5.png"},
                {"path":"信贷类产品/img6.png"}
            ]
        },
        {
            "name":"跨境类产品",
            "type":"Videos",
            "videos":[
                {"coverPath":"跨境类产品/Covers/img1.png", "path":"跨境类产品/mv1.mp4"},
                {"coverPath":"跨境类产品/Covers/img2.png", "path":"跨境类产品/mv2.mp4"},
                {"coverPath":"跨境类产品/Covers/img3.png", "path":"跨境类产品/mv3.mp4"},
                {"coverPath":"跨境类产品/Covers/img4.png", "path":"跨境类产品/mv4.mp4"},
                {"coverPath":"跨境类产品/Covers/img5.png", "path":"跨境类产品/mv5.mp4"},
                {"coverPath":"跨境类产品/Covers/img6.png", "path":"跨境类产品/mv6.mp4"}
            ]
        },
        { "name": "趣味拍照", "type": "Camera" },
        { "name": "互动游戏", "type": "Game" }
    ]
}
```
对应的C#类和读取
``` csharp
using UnityEngine;
using System.Collections;
using System;
using System.IO;

[Serializable]
public class AppData {
	public const string appDataFile = "AppData.json";

	public Scene[] scenes;

	public int tipsCloseTime;

	private static AppData _appData;

	public static AppData LoadAppData () {
		if (_appData == null) {
			string appDataJson = File.ReadAllText (appDataFile);
			_appData = JsonUtility.FromJson<AppData> (appDataJson);
		}
		return _appData;
	}
		
	#region inner classes

	[Serializable]
	public class Image {
		public string path;
	}
	[Serializable]
	public class Video {
		public string coverPath;
		public string path;
	}
	[Serializable]
	public class Scene {
		public string name;
		public string type;
		public Image[] images;
		public Video[] videos;
	}
	#endregion
}

```
### 二. 读取XML配置文件

XML格式文件
``` xml
<?xml version="1.0" encoding="UTF-8"?>
<userdata xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
    <actVideos>
        <actVideo id="0" path="Movies/HJJC/01开场.mp4"/>
        <actVideo id="1" path="Movies/HJJC/02音乐屋.mp4"/>
        <actVideo id="2" path="Movies/HJJC/03+04遇见朋友+女巫复仇.mp4"/>
        <actVideo id="3" path="Movies/HJJC/05奥兹国.mp4"/>
        <actVideo id="4" path="Movies/HJJC/06女巫堡.mp4"/>
        <actVideo id="5" path="Movies/HJJC/07胜利颁奖.mp4"/>
    </actVideos>
    <characters>
        <character id="1" name="桃乐丝" imagePath="Images/QSMX/Characters/桃乐丝.png" videoPath="Movies/QSMX/Characters/桃乐丝带声音.mp4">
            <compInfo originalPath="Movies/QSMX/桃乐丝有声音.mp4" undubbedPath="Movies/QSMX/桃乐丝无声音.mp4" animFilePath="AnimFiles/桃乐丝.anim" duration="29.12" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="0" end="5080" subtitle="温暖的阳光，照在快乐的农场"/>
                <snippet start="5280" end="10320" subtitle="小牛哞哞叫，小鸡蹦蹦跳，陪我度过美好时光"/>
                <snippet start="10520" end="14840" subtitle="美丽的梦想，住在快乐的农场"/>
                <snippet start="15040" end="19560" subtitle="每天都很忙，牛仔也很忙，陪我一起迎着太阳"/>
                <snippet start="19760" end="23640" subtitle="跟着我歌唱，快乐的农场"/>
                <snippet start="24640" end="28700" subtitle="跳着踢踢踏踏我爱我的家乡"/>
            </snippets>
        </character>
        <character id="2" name="坏女巫" imagePath="Images/QSMX/Characters/坏女巫.png" videoPath="Movies/QSMX/Characters/女巫带声音.mp4">
            <compInfo originalPath="Movies/QSMX/坏女巫有声音.mp4" undubbedPath="Movies/QSMX/坏女巫无声音.mp4" animFilePath="AnimFiles/坏女巫.anim" duration="34.76" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="720" end="7480" subtitle="除非桃乐丝死了，可是，我怎么才能让桃乐丝死呢"/>
                <snippet start="10600" end="16560" subtitle="我的姐姐怕光，我最讨厌水，你也害怕水，不是吗"/>
                <snippet start="18800" end="23030" subtitle="除非那是一瓶毒药水，让桃乐丝喝下去"/>
                <snippet start="23800" end="25720" subtitle="加上乌鸦的羽毛"/>
                <snippet start="26040" end="29000" subtitle="再放一点腐烂的老鼠尾巴"/>
                <snippet start="29520" end="32080" subtitle="最后还有蜘蛛的唾液"/>
                <snippet start="32360" end="34570" subtitle="成了，啊哈哈哈哈"/>
            </snippets>
        </character>
        <character id="3" name="狮子" imagePath="Images/QSMX/Characters/狮子.png" videoPath="Movies/QSMX/Characters/狮子带声音.mp4">
            <compInfo originalPath="Movies/QSMX/狮子有声音.mp4" undubbedPath="Movies/QSMX/狮子无声音.mp4" animFilePath="AnimFiles/狮子.anim" duration="31.96" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="0" end="6400" subtitle="找回世界之王应有的骄傲"/>
                <snippet start="19080" end="21360" subtitle="谁能让我不再胆小"/>
                <snippet start="21560" end="24440" subtitle="让勇敢之火熊熊燃烧"/>
                <snippet start="24640" end="27600" subtitle="我的内心，正在咆哮"/>
                <snippet start="27800" end="30040" subtitle="找回世界之王的骄傲"/>
            </snippets>
        </character>
        <character id="4" name="铁皮人" imagePath="Images/QSMX/Characters/铁皮人.png" videoPath="Movies/QSMX/Characters/铁皮人带声音.mp4">
            <compInfo originalPath="Movies/QSMX/铁皮人有声音.mp4" undubbedPath="Movies/QSMX/铁皮人无声音.mp4" animFilePath="AnimFiles/铁皮人.anim" duration="32.96" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="3000" end="7200" subtitle="金色的阳光照在金色的路上"/>
                <snippet start="7400" end="9660" subtitle="我不会害怕，目标是前方"/>
                <snippet start="9960" end="12240" subtitle="向着天空许下愿望"/>
                <snippet start="12440" end="16720" subtitle="金色的梦想走在金色的路上"/>
                <snippet start="16920" end="19140" subtitle="我不会彷徨 勇敢向前闯"/>
                <snippet start="19440" end="21440" subtitle="现在跟我一起出发"/>
                <snippet start="21640" end="25600" subtitle="跟着我出发，金色的路上"/>
                <snippet start="25800" end="30600" subtitle="一路踢踢踏踏我要踩出光芒"/>
            </snippets>
        </character>
        <character id="5" name="好女巫" imagePath="Images/QSMX/Characters/好女巫.png" videoPath="Movies/QSMX/Characters/好女巫带声音.mp4">
            <compInfo originalPath="Movies/QSMX/好女巫有声音.mp4" undubbedPath="Movies/QSMX/好女巫无声音.mp4" animFilePath="AnimFiles/好女巫.anim" duration="30.96" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="0" end="1440" subtitle="我亲爱的孩子"/>
                <snippet start="1640" end="3880" subtitle="如果你想要回到家乡"/>
                <snippet start="4080" end="6920" subtitle="必须沿着这条长长的路走下去"/>
                <snippet start="7120" end="9680" subtitle="这条路有时是光明快乐的"/>
                <snippet start="9880" end="12320" subtitle="有时是黑暗可怕的"/>
                <snippet start="12520" end="15280" subtitle="但无论如何你必须变得勇敢"/>
                <snippet start="15480" end="19800" subtitle="我相信你在路上，也会遇到更多帮助你的朋友"/>
                <snippet start="25880" end="30554" subtitle="记住桃乐丝，到翡翠城的路全部是用金黄色的砖铺成的"/>
            </snippets>
        </character>
        <character id="6" name="稻草人" imagePath="Images/QSMX/Characters/稻草人.png" videoPath="Movies/QSMX/Characters/稻草人带声音.mp4">
            <compInfo originalPath="Movies/QSMX/稻草人有声音.mp4" undubbedPath="Movies/QSMX/稻草人无声音.mp4" animFilePath="AnimFiles/稻草人.anim" duration="29" coverPath="Images/QSMX/封面1.png"/>
            <snippets>
                <snippet start="1000" end="3000" subtitle="这是女巫第二次念咒"/>
                <snippet start="9200" end="12190" subtitle="我是稻草人，我可不怕马蜂"/>
                <snippet start="16000" end="18830" subtitle="怎么办怎么办，打火石呢"/>
                <snippet start="21060" end="26240" subtitle="我不害怕，因为我会点燃一条光明之路"/>
            </snippets>
        </character>
    </characters>
    <mapVideo path="Movies/DQGC/地图.mp4">
        <passes>
            <pass id="0" start="0" end="5000" loop="true"/>
            <pass id="1" start="6000" end="19000" loop="false"/>
            <pass id="2" start="20000" end="33000" loop="false"/>
            <pass id="3" start="36000" end="48000" loop="false"/>
        </passes>
    </mapVideo>
    <finalVideo path="Movies/DQGC/胜利.mp4">
    </finalVideo>
    <gameVideos>
        <gameVideo id="1" path="Movies/DQGC/第一关.mp4">
            <stages>
                <stage name="" start="0" end="14800" loop="true" loopTime="13000"/>
                <stage name="音符1" start="14800" end="20800" loop="true" loopTime="19000"/>
                <stage name="音符2" start="20800" end="26400" loop="true" loopTime="24600"/>
                <stage name="音符3" start="26400" end="36800" loop="false"/>
            </stages>
        </gameVideo>
        <gameVideo id="2" path="Movies/DQGC/第二关.mp4">
            <stages>
                <stage name="" start="0" end="8100" loop="true" loopTime="5700"/>
                <stage name="水壶" start="8100" end="29900" loop="true" loopTime="28100"/>
                <stage name="风扇" start="29900" end="47300" loop="true" loopTime="45500"/>
                <stage name="太阳" start="47300" end="65800" loop="false"/>
            </stages>
        </gameVideo>
        <gameVideo id="3" path="Movies/DQGC/第三关.mp4">
            <stages>
                <stage name="" start="0" end="11000" loop="true" loopTime="9000"/>
                <stage name="爱心" start="11000" end="23000" loop="true" loopTime="22000"/>
                <stage name="脑子" start="23000" end="37000" loop="true" loopTime="36000"/>
                <stage name="勇气" start="37000" end="48000" loop="false"/>
            </stages>
        </gameVideo>
    </gameVideos>
    <paths>
        <faceImagePath>Images/face.jpg</faceImagePath>
        <maskImagePath>Images/mask.png</maskImagePath>
    </paths>
</userdata>
```
对应的C#类
``` csharp
using System.Collections;
using System;
using System.Xml.Serialization;

[XmlRoot("userdata")]
public class Userdata
{
	public Userdata() { }

	[Serializable]
	public class Character 
	{
		public Character() { }

		[Serializable]
		public class AssetsPath
		{
			[XmlAttribute]
			public string originalPath;
			[XmlAttribute]
			public string undubbedPath;
			[XmlAttribute]
			public string animFilePath;
			[XmlAttribute]
			public float duration;
			[XmlAttribute]
			public string coverPath;
		}

		[Serializable]
		public class Snippet
		{
			public Snippet() { }

			[XmlAttribute]
			public float start;
			[XmlAttribute]
			public float end;
			[XmlAttribute]
			public string subtitle;
		}

		[XmlAttribute]
		public int id;
		[XmlAttribute]
		public string name;

		private string imagePath;

		[XmlAttribute("imagePath")]
		public string ImagePath
		{
			get { return Application.streamingAssetsPath + "/" + imagePath; }
			set { imagePath = value; }
		}

		[XmlAttribute]
		public string videoPath;
		[XmlElement("compInfo")]
		public AssetsPath compInfo;
		[XmlArray("snippets"), XmlArrayItem("snippet", typeof(Snippet))]
		public Snippet[] snippets;
	}

	[Serializable]
	public class MapVideo
	{
		public MapVideo() { }

		[Serializable]
		public class Pass
		{
			public Pass() { }

			[XmlAttribute]
			public int id;
			[XmlAttribute]
			public float start;
			[XmlAttribute]
			public float end;
			[XmlAttribute]
			public bool loop;
		}

		[XmlAttribute("path")]
		public string path;
		[XmlArray("passes"), XmlArrayItem("pass", typeof(Pass))]
		public Pass[] passes;
	}

	[Serializable]
	public class FinalVideo
	{
		public FinalVideo() { }
		[XmlAttribute("path")]
		public string path;
	}

	[Serializable]
	public class GameVideo
	{
		public GameVideo() { }

		[Serializable]
		public class Stage
		{
			public Stage() { }

			[XmlAttribute]
			public string name;
			[XmlAttribute]
			public float start;
			[XmlAttribute]
			public float end;
			[XmlAttribute]
			public bool loop;
			[XmlAttribute]
			public float loopTime;
		}

		[XmlAttribute]
		public int id;
		[XmlAttribute]
		public string path;
		[XmlArray("stages"), XmlArrayItem("stage", typeof(Stage))]
		public Stage[] stages;
	}

	[Serializable]
	public class ActVideo
	{
		public ActVideo() { }
		[XmlAttribute]
		public int id;
		[XmlAttribute]
		public string path;
	}

	[Serializable]
	public class Paths
	{
		public Paths() { }

		[XmlElement("faceImagePath")]
		public string FaceImagePath 
		{
			get { return Application.persistentDataPath + "/" + faceImagePath; }
			set { faceImagePath = value; }
		}
		private string faceImagePath;

		[XmlElement("maskImagePath")]
		public string MaskImagePath
		{
			get { return Application.streamingAssetsPath + "/" + maskImagePath; }
			set { maskImagePath = value; }
		}
		private string maskImagePath;
	}

	[XmlArray("characters"), XmlArrayItem("character", typeof(Character))]
	public Character[] characters;
	[XmlArray("gameVideos"), XmlArrayItem("gameVideo", typeof(GameVideo))]
	public GameVideo[] gameVideos;
	[XmlArray("actVideos"), XmlArrayItem("actVideo", typeof(ActVideo))]
	public ActVideo[] actVideos;
	[XmlElement("mapVideo")]
	public MapVideo mapVideo;
	[XmlElement("finalVideo")]
	public FinalVideo finalVideo;
	[XmlElement("paths")]
	public Paths paths;
}
```
读取类
``` csharp
using System.IO;
using System;
using System.Collections;
using System.Xml.Serialization;

public class UserdataManager 
{
	private static UserdataManager instance;
	private Userdata userdata;

	private UserdataManager() 
    {
		string configPath = Application.streamingAssetsPath + "/userdata.xml";
		if(File.Exists(configPath))
		{
			FileStream stream = new FileStream (configPath, FileMode.Open, FileAccess.Read);
			XmlSerializer serializer = new XmlSerializer (typeof(Userdata));
			userdata = (Userdata)serializer.Deserialize (stream);
		}
    }

	public static UserdataManager GetInstance()
	{
		if(instance == null)
		{
			instance = new UserdataManager();
		}
		return instance;
	}

	public Userdata GetUserdata()
	{
		return userdata;
	}
}

```