/********************************************************************************
** 作者： androllen
** 日期： 16/5/13 14:28:00
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Utils
{
    public class TimeUtil
    {
        /// <summary>
        /// c# to unix
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimestamp()
        {
            DateTime timeStamp = new DateTime(1970, 1, 1); //得到1970年的时间戳
            long a = (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000; //注意这里有时区问题，用now就要减掉8个小时
            return a;
        }
        /// <summary>
        /// unix to c#
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = new DateTime(1970, 1, 1); //得到1970年的时间戳
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime temp = dtStart.Add(toNow);
            TimeSpan duration = new TimeSpan(0, 8, 0, 0);
            DateTime answer = temp.Add(duration);
            return answer;
        }
    }
}
