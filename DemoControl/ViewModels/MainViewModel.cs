/********************************************************************************
** 作者： androllen
** 日期： 16/5/12 17:38:55
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CCUWPToolkit.Controls;
using Caliburn.Micro;
using Windows.UI.Xaml;
using DemoControl.Model;

namespace DemoControl.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly INotifyFrameChanged _frame;

        public MainViewModel(WinRTContainer container, INotifyFrameChanged navigate)
        {
            _frame = navigate;
        }
        public void NavigatoGridView()
        {
            _frame.MainNavigationService.For<WYGridViewModel>().Navigate();
        }
        public void ShowToastDialog()
        {
            var toast = new WYToastDialog();
            toast.CornerSource = new CornerRadius(5);
            toast.ShowAsync("你 是 我 的 黄 油 小 伙 伴 对 吗？");
        }
        public async void ShowDialog()
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
