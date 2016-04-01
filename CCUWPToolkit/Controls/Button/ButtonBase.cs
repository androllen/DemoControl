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
    public abstract class ButtonBase : Button, IImageSource
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        /// <summary>
        /// 背景圆角度
        /// </summary>
        public CornerRadius CornerSource
        {
            get { return (CornerRadius)GetValue(CornerSourceProperty); }
            set { SetValue(CornerSourceProperty, value); }
        }

        public static readonly DependencyProperty CornerSourceProperty =
            DependencyProperty.Register("CornerSource", typeof(CornerRadius), typeof(ButtonBase),
                new PropertyMetadata(new CornerRadius(0)));

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
            typeof(ButtonBase), 
            new PropertyMetadata(string.Empty));
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
            DependencyProperty.Register("StretchSource", typeof(Stretch), typeof(ButtonBase),
                new PropertyMetadata(Stretch.None));

        /// <summary>
        /// 按钮图标
        /// </summary>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(ButtonBase),
            new PropertyMetadata(null));


        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ColorsSource
        {
            get { return (Brush)GetValue(ColorsSourceProperty); }
            set { SetValue(ColorsSourceProperty, value); }
        }

        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(ButtonBase),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
    }
}
