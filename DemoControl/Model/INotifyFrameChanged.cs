/********************************************************************************
** 作者： androllen
** 日期： 16/5/12 18:18:23
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DemoControl.Model
{
    public interface INotifyFrameChanged
    {
        INavigationService MainNavigationService { get; }
        Frame MainFrame { get; set; }

    }
}
