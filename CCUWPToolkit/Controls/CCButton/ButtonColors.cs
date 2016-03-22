using CCUWPToolkit.Controls.CCButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{

    public class ButtonColors : ButtonColorsBase
    {
        /// <summary>
        /// 正常
        /// </summary>
        private const string NormalStateImageName = "PART_NormalStateImage";
        /// <summary>
        /// 悬停
        /// </summary>
        private const string HoverStateImageName = "PART_HoverStateImage";
        private const string HoverStateRecycledNormalStateImageName = "PART_HoverStateRecycledNormalStateImage";
        private const string HoverStateRecycledPressedStateImageName = "PART_HoverStateRecycledPressedStateImage";
        /// <summary>
        /// 按下
        /// </summary>
        private const string PressedStateImageName = "PART_PressedStateImage";
        private const string DisabledStateImageName = "PART_DisabledStateImage";

        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);

        private Image _normalStateImage;
        private Image _hoverStateImage;
        private Image _hoverStateRecycledNormalStateImage;
        private Image _hoverStateRecycledPressedStateImage;
        private Image _pressedStateImage;
        private Image _disabledStateImage;

        public override double ButtonHeight
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

        public override double ButtonWidth
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

        public override Colors ColorsSource
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

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


        }
    }
}
