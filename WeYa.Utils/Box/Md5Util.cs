/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 14:12:47
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;

namespace WeYa.Utils
{
    public class Md5Util
    {
        private static readonly HashAlgorithmProvider MD5;

        static Md5Util()
        {
            MD5 = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
        }

        public static string HashMD5(string input)
        {
            var buff = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);
            var hashed = MD5.HashData(buff);
            var hash = CryptographicBuffer.EncodeToHexString(hashed).ToUpper();
            return hash;
        }

        public static string HashMD5(byte[] buffer)
        {
            var buff = CryptographicBuffer.CreateFromByteArray(buffer);
            var hashed = MD5.HashData(buff);
            var hash = CryptographicBuffer.EncodeToHexString(hashed).ToUpper();
            return hash;
        }

    }
}
