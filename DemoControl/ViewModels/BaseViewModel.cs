/********************************************************************************
** 作者： androllen
** 日期： 16/5/12 18:06:41
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DemoControl.Model;

namespace DemoControl.ViewModels
{
    public class BaseViewModel : Screen
    {
        public INotifyFrameChanged _navigationService;
        public BaseViewModel(INotifyFrameChanged navigate)
        {
            _navigationService = navigate;
        }

    }
}
