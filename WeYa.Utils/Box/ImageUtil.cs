/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 14:08:38
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Utils
{
    public class ImageUtil
    {
        private static string CacheImageFolder => @"cacheImage\";

        public ImageUtil()
        {

        }


        public static async Task<Uri> LoadImage(string url, bool loadNew)
        {
            url = url?.Trim();
            if (!string.IsNullOrEmpty(url) && url.StartsWith("http"))
            {
                var fileName = string.Format("{0}{1}", CacheImageFolder, Md5Util.HashMD5(url));
                return await HttpUtil.CacheFileForUri(url, fileName, loadNew);
            }
            return null;
        }

    }
}
