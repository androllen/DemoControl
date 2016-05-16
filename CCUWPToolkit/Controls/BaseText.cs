/********************************************************************************
** 作者： androllen
** 日期： 16/5/4 18:16:45
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public class BaseText : BaseControl, IBaseLabel
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        #region 按钮图标
        /// <summary>
        /// 按钮图标
        /// </summary>
        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSourceProperty =
                DependencyProperty.Register(
                "IconSource",
                typeof(ImageSource),
                typeof(BaseText),
                new PropertyMetadata(null));
        #endregion

        #region 按钮文字
        /// <summary>
        /// 按钮文字
        /// </summary>
        public object Label
        {
            get { return GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
            "Label",
            typeof(object),
            typeof(BaseText),
            new PropertyMetadata(string.Empty));
        #endregion

    }
}
