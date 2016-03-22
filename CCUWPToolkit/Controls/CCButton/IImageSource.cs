using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls.CCButton
{
    interface IImageSource : IButtonSize
    {
        Stretch Stretch { get; set; }
        ImageSource ImageSource { get; set; }
    }
}
