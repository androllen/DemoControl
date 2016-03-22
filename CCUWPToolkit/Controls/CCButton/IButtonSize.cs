using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CCUWPToolkit.Controls.CCButton
{
    interface IButtonSize
    {
        double ButtonWidth { get; set; }
        double ButtonHeight { get; set; }
        Orientation Orientation { get; set; }

    }
}
