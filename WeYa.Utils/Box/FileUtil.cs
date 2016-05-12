/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 15:01:45
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace WeYa.Utils
{
    public class FileUtil
    {
        public static StorageFolder LocalFolder => ApplicationData.Current.LocalFolder;

        public async static Task<StorageFile> MakeFile(string fileName)
        {
            return await LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        }

        public async static Task<StorageFile> GetFile(string fileName)
        {
            return await LocalFolder.GetFileAsync(fileName);
        }

        public static async Task WriteText(StorageFile file, string text)
        {
            try
            {
                await FileIO.WriteTextAsync(file, text);
                Debug.WriteLine("writeFile");
            }
            catch (Exception e)
            {
                Debug.WriteLine("FileManager.WriteText faild:{0}", e);
            }
        }
        public static async Task WriteBytes(StorageFile file, byte[] bytes)
        {
            try
            {
                await FileIO.WriteBytesAsync(file, bytes);
                Debug.WriteLine("writeFile");
            }
            catch (Exception e)
            {
                Debug.WriteLine("FileManager.WriteBytes faild:{0}", e);
            }
        }

        public static async Task<bool> IsFileExists(string fileName)
        {
            try
            {
                var item = await LocalFolder.TryGetItemAsync(fileName);
                return item != null;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
