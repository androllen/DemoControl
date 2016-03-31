using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CCUWPToolkit.Controls
{
    interface IColorsSource
    {
        Colors ColorsSource { get; set; }
        Border ShapeSource { get; set; }
    }
}
