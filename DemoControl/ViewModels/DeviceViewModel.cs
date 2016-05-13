/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 12:14:07
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using DemoControl.Model;


namespace DemoControl.ViewModels
{
    public class DeviceViewModel : Screen
    {
        private readonly INotifyFrameChanged _frame;
        public DeviceViewModel(INotifyFrameChanged navigate)
        {
            _frame = navigate;
        }

    }
}
