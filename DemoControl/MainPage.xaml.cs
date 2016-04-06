﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CCUWPToolkit.Controls;
using Windows.UI;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace DemoControl
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new WYDialog();
            dialog.Background = new SolidColorBrush(Colors.Orange);
            var result = await dialog.ShowAsync("This is the title", "This is the content/message", "取消", "确定");
            var content =
                string.Format(
                    "Text: {0}, Button: {1}",
                    dialog.InputText ?? "",
                    result ?? "");
            System.Diagnostics.Debug.WriteLine(content);
        }
    }
}
