using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public interface IBaseControl
    {
        CornerRadius CornerSource { get; set; }
        Brush ColorsSource { get; set; }
    }
}
