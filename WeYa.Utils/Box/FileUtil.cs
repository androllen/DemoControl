/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 15:01:45
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WeYa.Utils
{
    public class FileUtil
    {
        public static StorageFolder LocalFolder => ApplicationData.Current.LocalFolder;

        public async static Task<StorageFile> CreateFileAsync(string name)
        {
            return await LocalFolder.CreateFileAsync(name, CreationCollisionOption.ReplaceExisting);
        }
        public async static Task<StorageFolder> GetFolderAsync(string name)
        {
            return await LocalFolder.GetFolderAsync(name);
        }
        public async static Task<StorageFile> GetFileAsync(string name)
        {
            return await LocalFolder.GetFileAsync(name);
        }
        /// <summary>
        /// no test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async static Task<bool> DeleteFile(string name)
        {
            bool ok = await IsFileExists(name);
            StorageFile file = await CreateFileAsync(name);
            if (file != null)
            {
               await file.DeleteAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// no test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async static Task DeleteDirectory(string name)
        {
            var item = await LocalFolder.GetFolderAsync(name);
            var items = await item.GetFoldersAsync();
            foreach(StorageFolder folder in items)
            {
                var files = await folder.GetFilesAsync();
                foreach (IStorageFile file in files)
                {
                    await file.DeleteAsync();
                }
            }
        }

        public async static Task<string> ReadText(StorageFile file, string name)
        {
            bool ok = await IsFileExists(name);
            if (ok)
                return await FileIO.ReadTextAsync(file);

            return string.Empty;
        }
        public async static Task<Stream> ReadStream(StorageFile file, string name)
        {
            bool ok = await IsFileExists(name);

            var buffer = await FileIO.ReadBufferAsync(file);

            var stream =  buffer.AsStream();

            return stream;
        }
        public static async Task WriteText(StorageFile file, string text)
        {
            try
            {
                await FileIO.WriteTextAsync(file, text);
                Debug.WriteLine("WriteText");
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
                Debug.WriteLine("WriteBytes");
            }
            catch (Exception e)
            {
                Debug.WriteLine("FileManager.WriteBytes faild:{0}", e);
            }
        }

        public static async Task<bool> isFolderExists(string name)
        {
            var item = await LocalFolder.GetFolderAsync(name);
            return item != null ? true : false;
        }
        public static async Task<bool> IsFileExists(string name)
        {
            var item = await LocalFolder.TryGetItemAsync(name);
            return item != null ? true : false;
        }
    }
}
