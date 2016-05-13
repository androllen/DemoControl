/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 11:09:41
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Caliburn.Micro;
using DemoControl.Model;
using DemoControl.Views;
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
        private INotifyFrameChanged _service;

        //public BindableCollection<CharacterViewModel> Characters
        //{
        //    get;
        //    private set;
        //}
        public ShellViewModel(WinRTContainer container, INotifyFrameChanged frame)
        {
            _container = container;
            _service = frame;
        }
        public void ShowDevice()
        {
            _service.MainService.For<DeviceViewModel>().Navigate();
        }
        public void ShowGrid()
        {
            _service.MainService.For<WYGridViewModel>().Navigate();
        }

        //public ShellViewModel(WinRTContainer container, INotifyFrameChanged navigate)
        //{
        //    _frame = navigate;

        //    //Characters = new BindableCollection<CharacterViewModel>
        //    //{
        //    //    new CharacterViewModel("Arya Stark", "ms-appx:///Assets/arya.jpg"),
        //    //    new CharacterViewModel("Catelyn Stark", "ms-appx:///Assets/catelyn.jpg"),
        //    //    new CharacterViewModel("Cercei Lannister", "ms-appx:///Assets/cercei.jpg"),
        //    //    new CharacterViewModel("Jamie Lannister", "ms-appx:///Assets/jamie.jpg"),
        //    //    new CharacterViewModel("Jon Snow", "ms-appx:///Assets/jon.jpg"),
        //    //    new CharacterViewModel("Rob Stark", "ms-appx:///Assets/rob.jpg"),
        //    //    new CharacterViewModel("Sandor Clegane", "ms-appx:///Assets/sandor.jpg"),
        //    //    new CharacterViewModel("Sansa Stark", "ms-appx:///Assets/sansa.jpg"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREgNPMVcojMU6/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREgJPMVdHzFoK/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREv5OMVdY3JQd/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREvxOMVdYz8op/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREvpOMVc*AswL/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREvlOMVdID58E/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREvdOMVdopw4o/800"),
        //    //    new CharacterViewModel("Sansa Stark", "http://group.store.qq.com/qun/V108nu362ue0TN/V3tzaAREvZOMVcwmAcr/800"),
        //    //    new CharacterViewModel("Tyrion Lannister", "ms-appx:///Assets/tyrion.jpg")
        //    //};
        //}

        public void SetupNavigationService(Frame frame)
        {
            _service.MainService = _container.RegisterNavigationService(frame);
            _service.MainFrame = frame;
            _service.MainService.For<MainViewModel>().Navigate();

        }
    }
}
