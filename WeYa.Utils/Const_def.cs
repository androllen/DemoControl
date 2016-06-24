/********************************************************************************
** 作者： androllen
** 日期： 16/5/13 14:49:34
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Utils
{
    public class Const_def
    {
        public const bool IsDebug = true;
        public const string AppKey4Umeng = "550b9a69fd98c545a700088f";
        //wechat
        public const string APPID = "wxd4e6b06e55277224";

        public const string AppKey4Sina = "3216414220";
        public const string AppSecret4Sina = "0f63e70d1492c9cd291c4a12af3b0076";

        public const string AppKey4JPush = "1a89ca98feef52009a1e9968";

        public const string Setting = "Setting";
        public const string WeiboSdk = "WeiboSdk";
        public const string WeiboSet = "WeiboSet";

        public const string WinPhone = "Windows Phone";

        public const string Hot320Url = "thumb320";
        public const string Hot240Url = "thumb160";
        public const string Hot60Url = "!thumb60";


        public const string UID = "uid";
        public const string ID = "id";
        public const string Parent_id = "parent_id";
        public const string Type = "type";
        public const string Feature = "feature";
        public const string Page = "page";
        public const string Language = "language";
        public const string Client_id = "client_id";
        public const string Device_id = "device_id";
        public const string Version = "version";
        public const string Channel = "channel";
        public const string Maxid = "maxid";
        public const string Source = "source";
        public const string Square_category = "square_category";

        public const string Section = "section";
        public const string Topic = "topic";
        public const string Count = "count";
        public const string Q = "q";
        public const string CacheDir = "ImageCache";

        public const string userProfilePageUrl = "/View/UserProfilePage.xaml?idUser={0}";
        public const string typeBool = "typebool";
        public const string ImageCache = "ImageCache";
        public const string Category = "Category";

      
        public const string API_Category = "https://newapi.meipai.com/medias/topics_timeline.json?";
        public const string API_Common = "https://newapi.meipai.com/common/square_medias_categories.json?";
        public const string API_square = "https://newapi.meipai.com/square/show_category.json?";
        public const string API_show = "https://newapi.meipai.com/medias/show.json?";
        public const string API_comments = "https://newapi.meipai.com/comments/show.json?";
        public const string API_nearby = "https://newapi.meipai.com/nearby/medias_timeline.json?";

        public const string db_CacheDir = "cachedata\\favorite\\favorite.db";
        public const string db_CacheMainDir = "cachedata\\main\\favorite.tmp";

        //热门 https://newapi.meipai.com/medias/topics_timeline.json?id=1&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=180&channel=oppo"
        //GET 广场 https://newapi.meipai.com/common/square_medias_categories.json?section=3&topic=1&filter=0&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET 搞笑 头 https://newapi.meipai.com/square/show_category.json?id=13&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET 搞笑 https://newapi.meipai.com/medias/topics_timeline.json?id=13&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET 明星 https://newapi.meipai.com/square/show_category.json?id=16&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=16&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET girl https://newapi.meipai.com/square/show_category.json?id=19&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=19&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/show.json?id=521031734&square_category=19&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET 评论 https://newapi.meipai.com/comments/show.json?id=521031734&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET 附近 https://newapi.meipai.com/nearby/medias_timeline.json?lat=40.035471&lon=116.417599&page=1&count=20&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET 男神 https://newapi.meipai.com/square/show_category.json?id=31&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=31&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET 美妆 https://newapi.meipai.com/square/show_category.json?id=27&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=27&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET baby https://newapi.meipai.com/square/show_category.json?id=18&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=18&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET create https://newapi.meipai.com/square/show_category.json?id=5&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5&type=1&feature=new&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //

        //GET 热点 头 https://newapi.meipai.com/square/show_category.json?id=414&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET 热点 https://newapi.meipai.com/medias/topics_timeline.json?id=6136827007916124576&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET 美食 https://newapi.meipai.com/square/show_category.json?id=59&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5870490265939297486&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET pet https://newapi.meipai.com/square/show_category.json?id=6&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5864549574576746574&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET music https://newapi.meipai.com/square/show_category.json?id=62&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5871155236525660080&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET traver https://newapi.meipai.com/square/show_category.json?id=3&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5866185182888386743&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET dance https://newapi.meipai.com/square/show_category.json?id=63&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=5872239354896137479&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1

        //GET 活动精选 https://newapi.meipai.com/common/square_medias_categories.json?parent_id=33&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/square/show_category.json?id=403&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1
        //GET https://newapi.meipai.com/medias/topics_timeline.json?id=6120934638444953903&type=2&feature=hot&page=1&language=zh-Hans&client_id=1089857302&device_id=865773028434070&version=300&channel=bao360&model=N918St HTTP/1.1








    }
}
