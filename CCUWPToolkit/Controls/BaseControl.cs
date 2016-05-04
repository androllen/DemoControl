/********************************************************************************
** 作者： androllen
** 日期： 16/4/6 11:21:24
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public abstract class BaseControl : Control ,IBaseControl
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region 背景色
        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ColorsSource
        {
            get { return (Brush)GetValue(ColorsSourceProperty); }
            set { SetValue(ColorsSourceProperty, value); }
        }

        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(BaseControl),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
        #endregion

        #region 背景圆角度
        /// <summary>
        /// 背景圆角度
        /// </summary>
        public CornerRadius CornerSource
        {
            get { return (CornerRadius)GetValue(CornerSourceProperty); }
            set { SetValue(CornerSourceProperty, value); }
        }

        public static readonly DependencyProperty CornerSourceProperty =
            DependencyProperty.Register("CornerSource", typeof(CornerRadius), typeof(BaseControl),
                new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region 背景边距
        public Thickness MarginSource
        {
            get { return (Thickness)GetValue(MarginSourceProperty); }
            set { SetValue(MarginSourceProperty, value); }
        }

        private static readonly DependencyProperty MarginSourceProperty =
            DependencyProperty.Register("MarginSource",
                typeof(Thickness),
                typeof(BaseControl),
                new PropertyMetadata(new Thickness(0)));
        #endregion
    }
}
