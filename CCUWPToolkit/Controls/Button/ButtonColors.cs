using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = NormalStateImageName, Type = typeof(Rectangle))]
    [TemplatePart(Name = HoverStateImageName, Type = typeof(Colors))]
    [TemplatePart(Name = HoverStateRecycledNormalStateImageName, Type = typeof(Image))]
    [TemplatePart(Name = HoverStateRecycledPressedStateImageName, Type = typeof(Image))]
    [TemplatePart(Name = PressedStateImageName, Type = typeof(Image))]
    [TemplatePart(Name = DisabledStateImageName, Type = typeof(Image))]
    public class ButtonColors : Button
    {
        private const string NormalStateImageName = "PART_NormalStateImage";
        private const string HoverStateImageName = "PART_HoverStateImage";
        private const string HoverStateRecycledNormalStateImageName = "PART_HoverStateRecycledNormalStateImage";
        private const string HoverStateRecycledPressedStateImageName = "PART_HoverStateRecycledPressedStateImage";
        private const string PressedStateImageName = "PART_PressedStateImage";
        private const string DisabledStateImageName = "PART_DisabledStateImage";

        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);

        private Image _normalStateImage;
        private Image _hoverStateImage;
        private Image _hoverStateRecycledNormalStateImage;
        private Image _hoverStateRecycledPressedStateImage;
        private Image _pressedStateImage;
        private Image _disabledStateImage;
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


        }
    }
}
