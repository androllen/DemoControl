/********************************************************************************
** 作者： androllen
** 日期： 16/3/30 13:06:04
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = PlaceholderTextStateName, Type = typeof(ContentControl))]
    public class WYTextBox : TextBox
    {
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        /// <summary>
        /// Grid
        /// </summary>
        private const string GridStateName = "PART_GridRootStateName";
        private const string PlaceholderTextStateName = "PART_PlaceholderTextContentPresenter";

        private Grid _gridStateName;
        private ContentControl _placeholderTextContentPresenter;
        public WYTextBox()
        {
            DefaultStyleKey = typeof(WYTextBox);
        }

        protected override void OnApplyTemplate()
        {
            _waitForApplyTemplateTaskSource.SetResult(true);
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _placeholderTextContentPresenter = (ContentControl)GetTemplateChild(PlaceholderTextStateName);
            if (_gridStateName != null)
            {
                this.TextChanging += WYTextBox_TextChanging;
                _gridStateName.PointerEntered += OnPointerEntered;
                _gridStateName.PointerExited += OnPointerExited;
                _gridStateName.PointerPressed += OnPointerPressed;
                _gridStateName.PointerReleased += OnPointerReleased;
            }
            base.OnApplyTemplate();
        }

        private void WYTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (string.IsNullOrEmpty(sender.Text))
                _placeholderTextContentPresenter.Visibility = Visibility.Visible;
            else
                _placeholderTextContentPresenter.Visibility = Visibility.Collapsed;
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            VisualStateManager.GoToState(this, "Normal", true);
            if (_placeholderTextContentPresenter != null)
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(NormalStateColors);
        }
        private void OnPointerPressed(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(PressedStateColors);
        }
        private void OnPointerReleased(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(NormalStateColors);
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(PressedStateColors);
        }
        #region NormalStateColors
        /// <summary>
        /// 正常
        /// </summary>
        public Color NormalStateColors
        {
            get { return (Color)GetValue(NormalStateColorsProperty); }
            set { SetValue(NormalStateColorsProperty, value); }
        }
        public static readonly DependencyProperty NormalStateColorsProperty =
            DependencyProperty.Register(
            "NormalStateColors",
            typeof(Color),
            typeof(WYTextBox),
            new PropertyMetadata(Colors.Transparent, OnNormalStateColorsChanged));

        private static void OnNormalStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYTextBox)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);

        }
        #endregion
        #region PressedStateColors
        /// <summary>
        /// 按下
        /// </summary>
        public Color PressedStateColors
        {
            get { return (Color)GetValue(PressedStateColorsProperty); }
            set { SetValue(PressedStateColorsProperty, value); }
        }
        public static readonly DependencyProperty PressedStateColorsProperty =
            DependencyProperty.Register(
            "PressedStateColors",
            typeof(Color),
            typeof(WYTextBox),
            new PropertyMetadata(Colors.Transparent, OnPressedStateColorsChanged));

        private static void OnPressedStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYTextBox)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);

        }
        #endregion
        private async void UpdateRectangleState(Color oldtarget, Color newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            //if (_rectangleStateName != null)
            //    _rectangleStateName.Fill = new SolidColorBrush(newTarget);
        }
    }
}
