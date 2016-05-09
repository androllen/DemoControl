/********************************************************************************
** 作者： androllen
** 日期： 16/5/9 17:19:47
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CCUWPToolkit.Controls
{
    public class WYFlipView : FlipView
    {
        public WYFlipView()
        {
            DefaultStyleKey = typeof(WYFlipView);
            FilpViewWidth = 640;
            FilpViewHeight = 300;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.SizeChanged += WYFlipView_SizeChanged;  
        }

        private void WYFlipView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var flip = (WYFlipView)sender;
            flip.Height = e.NewSize.Width * FilpViewHeight / FilpViewWidth;
        }

        public double FilpViewWidth { get; set; }
        public double FilpViewHeight { get; set; }


    }
}
