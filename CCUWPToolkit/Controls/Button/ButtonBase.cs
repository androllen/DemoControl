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

    }
}
