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
using WeYa.Utils;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    public class WYGridView : GridView
    {
        private const string GridStateName = "PART_GridStateName";
        private Grid _gridStateName;

        protected override void OnApplyTemplate()
        {
            if(_gridStateName!=null)
                _gridStateName.SizeChanged -= WYGridView_SizeChanged;

            _gridStateName = GetTemplateChild(GridStateName) as Grid;

            if (_gridStateName != null)
                _gridStateName.SizeChanged += WYGridView_SizeChanged;

            base.OnApplyTemplate();
        }
        public WYGridView()
        {
            DefaultStyleKey = typeof(WYGridView);
        }

        private void WYGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ItemsSource == null | this.ItemsPanelRoot==null)
                return;

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
