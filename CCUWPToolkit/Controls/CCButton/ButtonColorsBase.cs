using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls.CCButton
{
    public abstract class ButtonColorsBase : ButtonBase, IColorsSource
    {
        public abstract double ButtonHeight { get; set; }
        public abstract double ButtonWidth { get; set; }
        public abstract Colors ColorsSource { get; set; }

        public Orientation Orientation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private void ApplyingTemplate()
        {
    
        }


    }
}
