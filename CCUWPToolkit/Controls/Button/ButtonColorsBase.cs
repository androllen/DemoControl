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

        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ColorsSource
        {
            get { return (Brush)GetValue(ColorsSourceProperty); }
            set { SetValue(ColorsSourceProperty, value); }
        }

        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(ButtonColorsBase),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));


    }
}
