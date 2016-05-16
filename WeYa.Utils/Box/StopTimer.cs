/********************************************************************************
** 作者： androllen
** 日期： 16/5/13 14:29:03
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Utils
{
    public class StopTimer
    {
        private static StopTimer stop = new StopTimer();
        public static StopTimer Instance { get { return stop; } }
        Stopwatch time = null;
        public StopTimer()
        {
            time = new Stopwatch();
        }
        public void RunTime(string str)
        {
            TimeSpan ts = time.Elapsed;
            string elapsedTime = String.Format("\t {0}====\t{1}", DateTime.Now.ToString(), str);
            Debug.WriteLine(elapsedTime);
        }
        public void RunTime(string str, string pam1)
        {
            TimeSpan ts = time.Elapsed;
            string elapsedTime = String.Format("\t {0}====\t{1}", DateTime.Now.ToString(), str);
            Debug.WriteLine(elapsedTime);
        }
        public void StopRunTime()
        {
            time.Stop();
        }
        public void StartRunTime()
        {
            time.Start();
        }

    }
}
