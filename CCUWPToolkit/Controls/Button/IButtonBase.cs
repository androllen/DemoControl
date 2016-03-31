using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public interface IButtonBase
    {
        object Label { get; set; }
        CornerRadius CornerSource { get; set; }
        Border ShapeSource { get; set; }
        Brush ColorsSource { get; set; }
    }
}
