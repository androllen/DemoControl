/********************************************************************************
** 作者： androllen
** 日期： 16/5/4 14:37:48
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace WeYa.Utils
{
    public class StringUtil
    {
        public static StringUtil Instance
        {
            get
            {
                return instance;
            }
        }
        private static StringUtil instance = new StringUtil();
        public StringUtil()
        {

        }

        public string GetString(string data)
        {
            ResourceLoader loader = ResourceLoader.GetForCurrentView();
            var str = loader.GetString(data);
            return str;
        }
    }
}
