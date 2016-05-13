/********************************************************************************
** 作者： androllen
** 日期： 16/5/12 18:19:25
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DemoControl.Model
{
    public class BaseFrame : INotifyFrameChanged
    {
        public INavigationService MainService { get; set; }
        private SystemNavigationManager systemNavigationManager;
        protected readonly WinRTContainer _container;

        public BaseFrame(WinRTContainer container)
        {
            _container = container;

            systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += FrameManager_BackRequested;
        }

        private void FrameManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (MainService.CanGoBack)
            {
                MainService.GoBack();
            }
        }

        private void UpdateMainBackButton()
        {
            systemNavigationManager.AppViewBackButtonVisibility =
                this.MainService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }
        private Frame _mainFrame;
        public Frame MainFrame
        {
            get { return _mainFrame; }
            set
            {
                if (MainService != null)
                    MainService.Navigated += (s, e) => UpdateMainBackButton();

                _mainFrame = value;

            }
        }
    }
}
