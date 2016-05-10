/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 11:09:41
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using CCUWPToolkit.Controls;
using DemoControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DemoControl.ViewModels
{
    public class ShellViewModel: Screen
    {
        private readonly WinRTContainer _container;
        private Frame _navigationService;
        private SystemNavigationManager systemNavigationManager;

   
        public BindableCollection<CharacterViewModel> Characters
        {
            get;
            private set;
        }

        public ShellViewModel(WinRTContainer container)
        {
            _container = container;
            systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += FrameManager_BackRequested;

            Characters = new BindableCollection<CharacterViewModel>
            {
                new CharacterViewModel("Arya Stark", "ms-appx:///Assets/arya.jpg"),
                new CharacterViewModel("Catelyn Stark", "ms-appx:///Assets/catelyn.jpg"),
                new CharacterViewModel("Cercei Lannister", "ms-appx:///Assets/cercei.jpg"),
                new CharacterViewModel("Jamie Lannister", "ms-appx:///Assets/jamie.jpg"),
                new CharacterViewModel("Jon Snow", "ms-appx:///Assets/jon.jpg"),
                new CharacterViewModel("Rob Stark", "ms-appx:///Assets/rob.jpg"),
                new CharacterViewModel("Sandor Clegane", "ms-appx:///Assets/sandor.jpg"),
                new CharacterViewModel("Sansa Stark", "ms-appx:///Assets/sansa.jpg"),
                new CharacterViewModel("Tyrion Lannister", "ms-appx:///Assets/tyrion.jpg")
            };
        }

        private void FrameManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }
        public void SetupNavigationService(Frame frame)
        {
            _navigationService = frame;
            _navigationService.Navigated += (e, s) => UpdatePhoneBackButton();

        }
        private void UpdatePhoneBackButton()
        {
            systemNavigationManager.AppViewBackButtonVisibility =
         this._navigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }
        public void ShowDevices()
        {
            //_navigationService.Navigate(typeof(DeviceView));
        }
        public void ShowToastDialog()
        {
            var toast = new WYToastDialog();
            toast.CornerSource = new CornerRadius(5);
            toast.ShowAsync("你 是 我 的 黄 油 小 伙 伴 对 吗？");
        }
        public async void ShowPhoneNumber()
        {
            var dialog = new WYDialog();
            dialog.CornerSource = new CornerRadius(5);
            var result = await dialog.ShowAsync("黄油小伙伴", "快来注册和TA一起互动!", "取消", "确定");
            var content = string.Format("Text: {0}", result);
            System.Diagnostics.Debug.WriteLine(content);
        }
        public async void ShowInputToastDialog()
        {
            var dialog = new WYInputDialog();
            dialog.CornerSource = new CornerRadius(5);
            var result = await dialog.ShowAsync("黄油小伙伴", "快来注册和TA一起互动!", "取消", "确定");
            var content = string.Format("Text: {0}", result);
            System.Diagnostics.Debug.WriteLine(content);
        }
        public void WYHeaderTitleBar_LeftClick()
        {
            var toast = new WYToastDialog();
            toast.CornerSource = new CornerRadius(5);
            toast.ShowAsync("WYHeaderTitleBar_LeftClick");
        }

        public void WYHeaderTitleBar_RightClick()
        {
            var toast = new WYToastDialog();
            toast.CornerSource = new CornerRadius(5);
            toast.ShowAsync("WYHeaderTitleBar_RightClick");
        }
    }
}
