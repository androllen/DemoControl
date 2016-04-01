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
    interface IImageSource : IButtonBase
    {
        Stretch StretchSource { get; set; }
        ImageSource ImageSource { get; set; }
    }
}
