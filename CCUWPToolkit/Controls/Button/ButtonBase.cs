using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CCUWPToolkit.Controls
{
    public abstract class ButtonBase : Button, IButtonBase
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
            DependencyProperty.Register("CornerSource", typeof(CornerRadius), typeof(ButtonColorsBase),
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
        /// 背景图形
        /// </summary>
        public Border ShapeSource
        {
            get { return (Border)GetValue(ShapeSourceProperty); }
            set { SetValue(ShapeSourceProperty, value); }
        }
        public static readonly DependencyProperty ShapeSourceProperty =
            DependencyProperty.Register("ShapeSource", typeof(Border), typeof(ButtonColorsBase),
            new PropertyMetadata(null));
    }
}
