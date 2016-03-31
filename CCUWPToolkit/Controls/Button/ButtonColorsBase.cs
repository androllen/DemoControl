using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CCUWPToolkit.Controls
{
    public abstract class ButtonColorsBase : ButtonBase, IColorsSource
    {
        private void ApplyingTemplate()
        {
        }
        public Colors ColorsSource
        {
            get { return (Colors)GetValue(ColorsSourceProperty); }
            set { SetValue(ColorsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(Colors), typeof(ButtonColorsBase),
                new PropertyMetadata(Colors.AliceBlue));

        /// <summary>
        /// 按钮图标
        /// </summary>
        public Border ShapeSource
    {
            get { return (Border)GetValue(ShapeSourceProperty); }
            set { SetValue(ShapeSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeSourceProperty =
            DependencyProperty.Register("ShapeSource", typeof(Border), typeof(ButtonColorsBase),
            new PropertyMetadata(null));
    }
}
