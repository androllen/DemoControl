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
    public interface IBaseDialog
    {
        string AcceptButton { get; set; }
        string CancelButton { get; set; }
        Style ButtonStyle { get; set; }
        Style TitleStyle { get; set; }
        Style InputTextStyle { get; set; }
        Style TextStyle { get; set; }
        Orientation ButtonsPanelOrientation { get; set; }
    }
}
