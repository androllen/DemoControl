/********************************************************************************
** 作者： androllen
** 日期： 16/4/14 15:49:41
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CCUWPToolkit.Controls.Extensions;

namespace CCUWPToolkit.Controls
{
    public class WYGridView : GridView
    {
  
        public WYGridView()
        {
            if (this.ItemContainerStyle == null)
            {
                this.ItemContainerStyle = new Style(typeof(GridViewItem));
            }

            this.ItemContainerStyle.Setters.Add(new Setter(GridViewItem.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch));

            this.Loaded += (s, a) =>
            {
                Grid framework = Window.Current.Content.GetFirstDescendantOfType<Grid>();
                framework.SizeChanged += Framework_SizeChanged;
                var panel = this.ItemsPanelRoot as ItemsWrapGrid;
                if (panel != null)
                {
                    if (framework.ActualWidth >= 500 && framework.ActualWidth <= 600)
                    {
                        var itemSize = framework.ActualWidth / 2;
                        panel.ItemWidth = itemSize;
                        panel.ItemHeight = itemSize;
                    }
                    else if (framework.ActualWidth >= 600 && framework.ActualWidth <= 700)
                    {
                        var itemSize = framework.ActualWidth / 3;
                        panel.ItemWidth = itemSize;
                        panel.ItemHeight = itemSize;
                    }
                    else if (framework.ActualWidth >= 700 && framework.ActualWidth <= 1000)
                    {
                        var itemSize = framework.ActualWidth / 4;
                        panel.ItemWidth = itemSize;
                        panel.ItemHeight = itemSize;
                    }
                    else if (framework.ActualWidth >= 1000)
                    {
                        var itemSize = framework.ActualWidth / 5;
                        panel.ItemWidth = itemSize;
                        panel.ItemHeight = itemSize;
                    }
                }
            };
        }
        private FrameworkElement framework
        {
            get
            {
                return (FrameworkElement)Window.Current.Content;
            }
        }
        private void Framework_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var panel = this.ItemsPanelRoot as ItemsWrapGrid;

            if (e.NewSize.Width >= 500 && e.NewSize.Width <= 600)
            {
                var itemSize = e.NewSize.Width / 2;
                panel.ItemWidth = itemSize;
                panel.ItemHeight = itemSize;
            }
            else if (e.NewSize.Width >= 600 && e.NewSize.Width <= 700)
            {
                var itemSize = e.NewSize.Width / 3;
                panel.ItemWidth = itemSize;
                panel.ItemHeight = itemSize;
            }
            else if (e.NewSize.Width >= 700 && e.NewSize.Width <= 1000)
            {
                var itemSize = e.NewSize.Width / 4;
                panel.ItemWidth = itemSize;
                panel.ItemHeight = itemSize;
            }
            else if (e.NewSize.Width >= 1000)
            {
                var itemSize = e.NewSize.Width / 5;
                panel.ItemWidth = itemSize;
                panel.ItemHeight = itemSize;
            }
        }
  
    }
}
