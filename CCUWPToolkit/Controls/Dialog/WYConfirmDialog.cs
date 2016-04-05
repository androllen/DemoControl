/********************************************************************************
** 作者： androllen
** 日期： 16/4/5 15:30:03
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = LayoutRootPanelName, Type = typeof(Panel))]
    [TemplatePart(Name = ContentBorderName, Type = typeof(Border))]
    [TemplatePart(Name = InputTextBoxName, Type = typeof(TextBox))]
    [TemplatePart(Name = TitleTextBlockName, Type = typeof(TextBlock))]
    [TemplatePart(Name = TextTextBlockName, Type = typeof(TextBlock))]
    [TemplatePart(Name = ButtonsPanelName, Type = typeof(Panel))]
    [TemplateVisualState(GroupName = PopupStatesGroupName, Name = OpenPopupStateName)]
    [TemplateVisualState(GroupName = PopupStatesGroupName, Name = ClosedPopupStateName)]
    public class WYConfirmDialog : Control
    {
        #region Template Part Names
        private const string PopupStatesGroupName = "PopupStates";
        private const string OpenPopupStateName = "OpenPopupState";
        private const string ClosedPopupStateName = "ClosedPopupState";

        private const string LayoutRootPanelName = "LayoutRoot";
        private const string ContentBorderName = "ContentBorder";
        private const string InputTextBoxName = "InputTextBox";
        private const string TitleTextBlockName = "TitleTextBlock";
        private const string TextTextBlockName = "TextTextBlock";
        private const string ButtonsPanelName = "ButtonsPanel";
        #endregion

        #region Template Part Fields
        private Popup _dialogPopup;
        private Panel _layoutRoot;
        private Border _contentBorder;
        private TextBox _inputTextBox;
        private TextBlock _titleTextBlock;
        private TextBlock _textTextBlock;
        private Panel _buttonsPanel;
        #endregion
        public WYConfirmDialog()
        {
            DefaultStyleKey = typeof(WYConfirmDialog);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        /// <summary>
        /// BackgroundScreenBrush Dependency Property
        /// </summary>
        public static readonly DependencyProperty BackgroundScreenBrushProperty =
            DependencyProperty.Register(
                "BackgroundScreenBrush",
                typeof(Brush),
                typeof(WYConfirmDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the BackgroundScreenBrush property. This dependency property 
        /// indicates the brush to use for the screen behind the dialog window.
        /// </summary>
        public Brush BackgroundScreenBrush
        {
            get { return (Brush)GetValue(BackgroundScreenBrushProperty); }
            set { SetValue(BackgroundScreenBrushProperty, value); }
        }
    }
}
