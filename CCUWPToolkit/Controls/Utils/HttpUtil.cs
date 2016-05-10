/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 14:48:21
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CCUWPToolkit.Controls.Utils
{
    public class HttpUtil
    {
        public static async Task<Uri> CacheFileForUri(string url, string fileName, bool loadNew = false, bool autoRedirect = false)
        {
            bool exists = await FileUtil.IsFileExists(fileName);

            if (!exists || loadNew)
            {
                //不存在，则下载
                try
                {
                    var client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = autoRedirect });
                    var bytes = await client.GetByteArrayAsync(url);
                    StorageFile file = await FileUtil.MakeFile(fileName);
                    await FileUtil.WriteBytes(file, bytes);
                }
                catch (HttpRequestException e)
                {
                    //网络问题
                    Debug.WriteLine("请求失败:{0}", e);
                }
                catch (WebException e)
                {
                    //网络问题
                    Debug.WriteLine("请求失败:{0}", e);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("请求失败:{0}", e);
                }
            }

            return new Uri(string.Format("ms-appdata:///local/{0}", fileName.Replace("\\", @"/")));
        }

    }
}
