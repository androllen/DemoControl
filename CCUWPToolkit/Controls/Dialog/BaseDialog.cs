/********************************************************************************
** 作者： androllen
** 日期： 16/4/5 16:43:38
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public abstract class BaseDialog :BaseControl, IBaseDialog
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region TextStyle
        /// <summary>
        /// TextStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty TextStyleProperty =
            DependencyProperty.Register(
                "TextStyle",
                typeof(Style),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the TextStyle property. This dependency property 
        /// indicates the style to use for the text section TextBlock.
        /// </summary>
        public Style TextStyle
        {
            get { return (Style)GetValue(TextStyleProperty); }
            set { SetValue(TextStyleProperty, value); }
        }

        #endregion

        #region ButtonStyle
        /// <summary>
        /// ButtonStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.Register(
                "ButtonStyle",
                typeof(Style),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the ButtonStyle property. This dependency property 
        /// indicates the Style to use for the buttons.
        /// </summary>
        public Style ButtonStyle
        {
            get { return (Style)GetValue(ButtonStyleProperty); }
            set { SetValue(ButtonStyleProperty, value); }
        }
        #endregion

        #region InputTextStyle
        /// <summary>
        /// InputTextStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty InputTextStyleProperty =
            DependencyProperty.Register(
                "InputTextStyle",
                typeof(Style),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the InputTextStyle property. This dependency property 
        /// indicates the style of the input TextBox.
        /// </summary>
        public Style InputTextStyle
        {
            get { return (Style)GetValue(InputTextStyleProperty); }
            set { SetValue(InputTextStyleProperty, value); }
        }
        #endregion

        #region TitleStyle
        /// <summary>
        /// TitleStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register(
                "TitleStyle",
                typeof(Style),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the TitleStyle property. This dependency property 
        /// indicates the style to use for the title TextBlock.
        /// </summary>
        public Style TitleStyle
        {
            get { return (Style)GetValue(TitleStyleProperty); }
            set { SetValue(TitleStyleProperty, value); }
        }
        #endregion

        #region AcceptButton
        /// <summary>
        /// AcceptButton Dependency Property
        /// </summary>
        public static readonly DependencyProperty AcceptButtonProperty =
            DependencyProperty.Register(
                "AcceptButton",
                typeof(string),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the AcceptButton property. This dependency property 
        /// indicates the result to return when user hits the Enter key while the input text box has focus.
        /// </summary>
        public string AcceptButton
        {
            get { return (string)GetValue(AcceptButtonProperty); }
            set { SetValue(AcceptButtonProperty, value); }
        }
        #endregion

        #region CancelButton
        /// <summary>
        /// CancelButton Dependency Property
        /// </summary>
        public static readonly DependencyProperty CancelButtonProperty =
            DependencyProperty.Register(
                "CancelButton",
                typeof(string),
                typeof(BaseDialog),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the CancelButton property. This dependency property 
        /// indicates the result to return when user hits the Escape key or taps out of the dialog.
        /// </summary>
        public string CancelButton
        {
            get { return (string)GetValue(CancelButtonProperty); }
            set { SetValue(CancelButtonProperty, value); }
        }
        #endregion

        #region ButtonsPanelOrientation
        /// <summary>
        /// ButtonsPanelOrientation Dependency Property
        /// </summary>
        public static readonly DependencyProperty ButtonsPanelOrientationProperty =
            DependencyProperty.Register(
                "ButtonsPanelOrientation",
                typeof(Orientation),
                typeof(BaseDialog),
                new PropertyMetadata(Orientation.Horizontal));

        /// <summary>
        /// Gets or sets the ButtonsPanelOrientation property. This dependency property 
        /// indicates the orientation of the buttons panel.
        /// </summary>
        public Orientation ButtonsPanelOrientation
        {
            get { return (Orientation)GetValue(ButtonsPanelOrientationProperty); }
            set { SetValue(ButtonsPanelOrientationProperty, value); }
        }
        #endregion
    }
}
