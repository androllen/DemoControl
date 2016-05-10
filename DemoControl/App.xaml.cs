using Caliburn.Micro;
using DemoControl.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DemoControl
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App
    {
        private WinRTContainer _container;
        public App()
        {
            this.InitializeComponent();
        }


        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container
                .PerRequest<ShellViewModel>()
                .PerRequest<DeviceViewModel>();


        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Note we're using DisplayRootViewFor (which is view model first)
            // this means we're not creating a root frame and just directly
            // inserting ShellView as the Window.Content

            DisplayRootViewFor<ShellViewModel>();

        }
        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
