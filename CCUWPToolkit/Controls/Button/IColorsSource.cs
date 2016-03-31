﻿using System;
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
    interface IColorsSource : IButtonBase
    {
        Brush ColorsSource { get; set; }
    }
}
