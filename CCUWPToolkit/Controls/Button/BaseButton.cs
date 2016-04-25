using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CCUWPToolkit.Controls
{
    public abstract class BaseButton : Button, IBaseButton
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
                typeof(BaseButton),
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
            typeof(BaseButton),
            new PropertyMetadata(string.Empty));
        #endregion

        #region 图片的扩展
        /// <summary>
        /// 图片的扩展
        /// </summary>
        public Stretch StretchSource
        {
            get { return (Stretch)GetValue(StretchSourceProperty); }
            set { SetValue(StretchSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StretchSourceProperty =
            DependencyProperty.Register("StretchSource", typeof(Stretch), typeof(BaseButton),
                new PropertyMetadata(Stretch.None));
        #endregion

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
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(BaseButton),
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
            DependencyProperty.Register("CornerSource", typeof(CornerRadius), typeof(BaseButton),
                new PropertyMetadata(new CornerRadius(0)));
        #endregion

        public Thickness MarginSource
        {
            get { return (Thickness)GetValue(MarginSourceProperty); }
            set { SetValue(MarginSourceProperty, value); }
        }

        private static readonly DependencyProperty MarginSourceProperty =
            DependencyProperty.Register("MarginSource",
                typeof(Thickness),
                typeof(BaseButton),
                new PropertyMetadata(new Thickness(0)));
    }
}
