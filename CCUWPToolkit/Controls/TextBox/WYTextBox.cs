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
    [TemplatePart(Name = BorderElementStateName,Type =typeof(Border))]
    public class WYTextBox : TextBox
    {
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        /// <summary>
        /// Grid
        /// </summary>
        private const string GridStateName = "PART_GridRootStateName";
        private const string PlaceholderTextStateName = "PART_PlaceholderTextContentPresenter";
        private const string BorderElementStateName = "PART_BorderElement";

        private Grid _gridStateName;
        private ContentControl _placeholderTextContentPresenter;
        private Border _borderElementStateName;
        public WYTextBox()
        {
            DefaultStyleKey = typeof(WYTextBox);
        }

        protected override void OnApplyTemplate()
        {
            _waitForApplyTemplateTaskSource.SetResult(true);
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _placeholderTextContentPresenter = (ContentControl)GetTemplateChild(PlaceholderTextStateName);
            _borderElementStateName = (Border)GetTemplateChild(BorderElementStateName);
            this.TextChanging += WYTextBox_TextChanging;

            base.OnApplyTemplate();
        }

        private void WYTextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (string.IsNullOrEmpty(sender.Text))
                _placeholderTextContentPresenter.Visibility = Visibility.Visible;
            else
                _placeholderTextContentPresenter.Visibility = Visibility.Collapsed;
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


         public HorizontalAlignment DelHorAligStretch
        {
            get { return (HorizontalAlignment)GetValue(DelHorAligStretchProperty); }
            set { SetValue(DelHorAligStretchProperty, value); }
        }

        private static readonly DependencyProperty DelHorAligStretchProperty =
            DependencyProperty.Register("DelHorAligStretch",
                typeof(HorizontalAlignment),
                typeof(WYTextBox),
                new PropertyMetadata(HorizontalAlignment.Left));

        public VerticalAlignment DelVerAligStretch
        {
            get { return (VerticalAlignment)GetValue(DelVerAligStretchProperty); }
            set { SetValue(DelVerAligStretchProperty, value); }
        }

        private static readonly DependencyProperty DelVerAligStretchProperty =
            DependencyProperty.Register("DelVerAligStretch",
                typeof(VerticalAlignment),
                typeof(WYTextBox),
                new PropertyMetadata(VerticalAlignment.Center));

        public Thickness DelBorderThicknessPadding
        {
            get { return (Thickness)GetValue(DelBorderThicknessPaddingProperty); }
            set { SetValue(DelBorderThicknessPaddingProperty, value); }
        }

        private static readonly DependencyProperty DelBorderThicknessPaddingProperty =
            DependencyProperty.Register("DelBorderThicknessPadding",
                typeof(Thickness),
                typeof(WYTextBox),
                new PropertyMetadata(new Thickness(1)));

        //
        public Thickness AlignmentThicknessPadding
        {
            get { return (Thickness)GetValue(AlignmentThicknessPaddingProperty); }
            set { SetValue(AlignmentThicknessPaddingProperty, value); }
        }

        private static readonly DependencyProperty AlignmentThicknessPaddingProperty =
            DependencyProperty.Register("AlignmentThicknessPadding",
                typeof(Thickness),
                typeof(WYTextBox),
                new PropertyMetadata(new Thickness(10,5,5,5)));

        #region IsEnableColorsStretch
        /// <summary>
        /// 是否启用2种状态
        /// 不可用时使用系统 Foreground
        /// </summary>
        public bool IsEnableColorsStretch
        {
            get { return (bool)GetValue(IsEnableColorsStretchProperty); }
            set { SetValue(IsEnableColorsStretchProperty, value); }
        }
        public static readonly DependencyProperty IsEnableColorsStretchProperty =
            DependencyProperty.Register(
            "IsEnableColorsStretch",
            typeof(bool),
            typeof(WYTextBox),
            new PropertyMetadata(false, OnIsEnableColorsStretchChanged));

        private static void OnIsEnableColorsStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYTextBox)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsEnableColorsStretch;
            target.OnIsEnableColorsChanged(oldtarget, newTarget);
        }
        private async void OnIsEnableColorsChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget && _gridStateName != null)
            {
                _gridStateName.PointerEntered += OnPointerEntered;
                _gridStateName.PointerExited += OnPointerExited;
                _gridStateName.PointerPressed += OnPointerPressed;
                _gridStateName.PointerReleased += OnPointerReleased;
            }
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            VisualStateManager.GoToState(this, "Normal", true);
            if (_placeholderTextContentPresenter != null)
            {
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(NormalStateColors);
                _placeholderTextContentPresenter.Opacity = 1;
            }
        }
        private void OnPointerPressed(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
            {
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(PressedStateColors);
                _placeholderTextContentPresenter.Opacity = 0.6;
            }
        }
        private void OnPointerReleased(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
            {
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(NormalStateColors);
                _placeholderTextContentPresenter.Opacity = 0.6;
            }
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_placeholderTextContentPresenter != null)
            {
                _placeholderTextContentPresenter.Foreground = new SolidColorBrush(PressedStateColors);
                _placeholderTextContentPresenter.Opacity = 0.6;
            }
        }
        #endregion
    }
}
