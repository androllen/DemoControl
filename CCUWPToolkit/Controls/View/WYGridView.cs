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
using Windows.UI.ViewManagement;
using System.Collections;

namespace CCUWPToolkit.Controls
{
    public class WYGridView : GridView
    {
        #region DependencyProperties

        /// <summary>
        /// Minimum height for item
        /// </summary>
        public double MinItemHeight
        {
            get { return (double)GetValue(WYGridView.MinItemHeightProperty); }
            set { SetValue(WYGridView.MinItemHeightProperty, value); }
        }

        public static readonly DependencyProperty MinItemHeightProperty =
            DependencyProperty.Register(
                "MinItemHeight",
                typeof(double),
                typeof(WYGridView),
                new PropertyMetadata(1.0, (s, a) =>
                {
                    if (!double.IsNaN((double)a.NewValue))
                    {
                        ((WYGridView)s).InvalidateMeasure();
                    }
                }));

        /// <summary>
        /// Minimum width for item (must be greater than zero)
        /// </summary>
        public double MinItemWidth
        {
            get { return (double)GetValue(WYGridView.MinimumItemWidthProperty); }
            set { SetValue(WYGridView.MinimumItemWidthProperty, value); }
        }

        public static readonly DependencyProperty MinimumItemWidthProperty =
            DependencyProperty.Register(
                "MinItemWidth",
                typeof(double),
                typeof(WYGridView),
                new PropertyMetadata(1.0, (s, a) =>
                {
                    if (!Double.IsNaN((double)a.NewValue))
                    {
                        ((WYGridView)s).InvalidateMeasure();
                    }
                }));

        #endregion

        #region MaxRowsOrColumnsValue
        public static readonly DependencyProperty MaxRowsOrColumnsValueProperty =
            DependencyProperty.Register("MaxRowsOrColumnsValue",
            typeof(int),
            typeof(WYGridView),
            new PropertyMetadata(3));

        public int MaxRowsOrColumnsValue
        {
            get { return (int)GetValue(MaxRowsOrColumnsValueProperty); }
            set { SetValue(MaxRowsOrColumnsValueProperty, value); }
        }
        #endregion

        public WYGridView()
        {
            if (this.ItemContainerStyle == null)
            {
                this.ItemContainerStyle = new Style(typeof(GridViewItem));
            }

            this.LayoutUpdated += (sender, o) => AdaptLayout();

            this.ItemContainerStyle.Setters.Add(new Setter(GridViewItem.HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch));

            this.Loaded += (s, a) =>
            {
                if (this.ItemsPanelRoot != null)
                {
                    this.InvalidateMeasure();
                }
            };

        }

        private void AdaptLayout()
        {
            var currentViewState = ApplicationView.GetForCurrentView().Orientation;
            var isLandscape = currentViewState == ApplicationViewOrientation.Landscape;
            var panel = this.ItemsPanelRoot as ItemsWrapGrid;
            if (panel != null)
            {
                panel.MaximumRowsOrColumns = MaxRowsOrColumnsValue;
            }
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var panel = this.ItemsPanelRoot as ItemsWrapGrid;
            if (panel != null)
            {
                if (MinItemWidth == 0)
                    throw new DivideByZeroException("You need to have a MinItemWidth greater than zero");

                var availableWidth = availableSize.Width - (this.Padding.Right + this.Padding.Left);

                var numColumns = Math.Floor(availableWidth / MinItemWidth);

                numColumns = numColumns == 0 ? 1 : (Convert.ToInt32(numColumns) > panel.MaximumRowsOrColumns ? panel.MaximumRowsOrColumns : numColumns);

                var numRows = Math.Ceiling(this.Items.Count / numColumns);

                var itemWidth = availableWidth / numColumns;
                var aspectRatio = MinItemHeight / MinItemWidth;
                var itemHeight = itemWidth * aspectRatio;

                panel.ItemWidth = itemWidth;
                panel.ItemHeight = itemHeight;
            }

            return base.MeasureOverride(availableSize);
        }
    }

}
