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
using Windows.System.Profile;
using Windows.UI.Xaml.Input;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = ContentPresenterName, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = ImageStateName, Type = typeof(Image))]
    public class ButtonColors : ButtonBase
    {
        #region Property
        /// <summary>
        /// 矩形控件名字
        /// </summary>
        private const string RectangleStateName = "PART_RectangleStateName";
        private const string ContentPresenterName = "PART_ContentPresenter";
        /// <summary>
        /// Grid
        /// </summary>
        private const string GridStateName = "PART_GridStateName";
        /// <summary>
        /// 图片控件名字
        /// </summary>
        private const string ImageStateName = "PART_ImageStateName";
        /// <summary>
        /// 图片控件
        /// </summary>
        private Image _imageStateName;
        private ContentPresenter _contentPresenter;
        /// <summary>
        /// 矩形控件
        /// </summary>
        private Rectangle _rectangleStateName;

        private Grid _gridStateName;

        #endregion

        public ButtonColors()
        {
            DefaultStyleKey = typeof(ButtonColors);
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
            typeof(ButtonColors),
            new PropertyMetadata(Colors.Transparent, OnNormalStateColorsChanged));

        private static void OnNormalStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);

        }
        #endregion

        #region HoverStateColors
        /// <summary>
        /// 悬停
        /// </summary>
        public Color HoverStateColors
        {
            get { return (Color)GetValue(HoverStateColorsProperty); }
            set { SetValue(HoverStateColorsProperty, value); }
        }
        public static readonly DependencyProperty HoverStateColorsProperty =
            DependencyProperty.Register(
            "HoverStateColors",
            typeof(Color),
            typeof(ButtonColors),
            new PropertyMetadata(Colors.Transparent, OnHoverStateColorsChanged));

        private static void OnHoverStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
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
            typeof(ButtonColors),
            new PropertyMetadata(Colors.Transparent, OnPressedStateColorsChanged));

        private static void OnPressedStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);

        }
        #endregion

        #region DisabledStateColors
        /// <summary>
        /// 禁用
        /// </summary>
        private Color DisabledStateColors
        {
            get { return (Color)GetValue(DisabledStateColorsProperty); }
            set { SetValue(DisabledStateColorsProperty, value); }
        }
        public static readonly DependencyProperty DisabledStateColorsProperty =
            DependencyProperty.Register(
            "DisabledStateColors",
            typeof(Color),
            typeof(ButtonColors),
            new PropertyMetadata(Colors.Transparent, OnDisabledStateColorsChanged));

        private static void OnDisabledStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);
        }
        #endregion
        private async void UpdateRectangleState(Color oldtarget, Color newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(newTarget);
        }
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);


        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _imageStateName = (Image)GetTemplateChild(ImageStateName);
            _rectangleStateName = (Rectangle)GetTemplateChild(RectangleStateName);
            _contentPresenter = (ContentPresenter)GetTemplateChild(ContentPresenterName);
            _waitForApplyTemplateTaskSource.SetResult(true);

        }

        public enum DeviceFamily
        {
            /// <summary>
            ///     Unknown
            /// </summary>
            Unknown,

            /// <summary>
            ///     Desktop
            /// </summary>
            Desktop,

            /// <summary>
            ///     Mobile
            /// </summary>
            Mobile,

            /// <summary>
            ///     Team
            /// </summary>
            Team,

            /// <summary>
            ///     Windows IoT
            /// </summary>
            IoT,

            /// <summary>
            ///     Xbox
            /// </summary>
            Xbox
        }
        public static bool IsType(DeviceFamily family)
        {
            return $"Windows.{family}" == AnalyticsInfo.VersionInfo.DeviceFamily;
        }


        #region GeneratedImageHorizontalStretch
        public HorizontalAlignment GeneratedImageHorizontalStretch
        {
            get { return (HorizontalAlignment)GetValue(GeneratedImageHorizontalStretchProperty); }
            set { SetValue(GeneratedImageHorizontalStretchProperty, value); }
        }
        public static readonly DependencyProperty GeneratedImageHorizontalStretchProperty =
            DependencyProperty.Register(
            "GeneratedImageHorizontalStretch",
            typeof(HorizontalAlignment),
            typeof(ButtonColors),
            new PropertyMetadata(HorizontalAlignment.Center));

        #endregion

        #region GeneratedImageVerticalStretch
        public VerticalAlignment GeneratedImageVerticalStretch
        {
            get { return (VerticalAlignment)GetValue(GeneratedImageVerticalStretchProperty); }
            set { SetValue(GeneratedImageVerticalStretchProperty, value); }
        }
        public static readonly DependencyProperty GeneratedImageVerticalStretchProperty =
            DependencyProperty.Register(
            "GeneratedImageVerticalStretch",
            typeof(VerticalAlignment),
            typeof(ButtonColors),
            new PropertyMetadata(VerticalAlignment.Center));
        #endregion

        #region GeneratedContentHorizontalStretch
        public HorizontalAlignment GeneratedContentHorizontalStretch
        {
            get { return (HorizontalAlignment)GetValue(GeneratedContentHorizontalStretchProperty); }
            set { SetValue(GeneratedContentHorizontalStretchProperty, value); }
        }
        public static readonly DependencyProperty GeneratedContentHorizontalStretchProperty =
            DependencyProperty.Register(
            "GeneratedContentHorizontalStretch",
            typeof(HorizontalAlignment),
            typeof(ButtonColors),
            new PropertyMetadata(HorizontalAlignment.Center));

        #endregion

        #region GeneratedContentVerticalStretch
        public VerticalAlignment GeneratedContentVerticalStretch
        {
            get { return (VerticalAlignment)GetValue(GeneratedContentVerticalStretchProperty); }
            set { SetValue(GeneratedContentVerticalStretchProperty, value); }
        }
        public static readonly DependencyProperty GeneratedContentVerticalStretchProperty =
            DependencyProperty.Register(
            "GeneratedContentVerticalStretch",
            typeof(VerticalAlignment),
            typeof(ButtonColors),
            new PropertyMetadata(VerticalAlignment.Center));
        #endregion

        #region IsGeneratedImageStretch
        /// <summary>
        /// 是否显示图片
        /// </summary>
        public bool IsGeneratedImageStretch
        {
            get { return (bool)GetValue(IsGeneratedImageStretchProperty); }
            set { SetValue(IsGeneratedImageStretchProperty, value); }
        }
        public static readonly DependencyProperty IsGeneratedImageStretchProperty =
            DependencyProperty.Register(
            "IsGeneratedImageStretch",
            typeof(bool),
            typeof(ButtonColors),
            new PropertyMetadata(false, OnIsGeneratedImageStretchChanged));

        private static void OnIsGeneratedImageStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsGeneratedImageStretch;
            target.OnIsGeneratedImageChanged(oldtarget, newTarget);
        }
        private async void OnIsGeneratedImageChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget)
            {
                _imageStateName.Visibility = Visibility.Visible;
                _contentPresenter.Visibility = Visibility.Collapsed;

            }
            else
            {
                _imageStateName.Visibility = Visibility.Collapsed;
                _contentPresenter.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region IsEnableComponentStretch
        public bool IsEnableComponentStretch
        {
            get { return (bool)GetValue(IsEnableComponentStretchProperty); }
            set { SetValue(IsEnableComponentStretchProperty, value); }
        }
        public static readonly DependencyProperty IsEnableComponentStretchProperty =
            DependencyProperty.Register(
            "IsEnableComponentStretch",
            typeof(bool),
            typeof(ButtonColors),
            new PropertyMetadata(false, OnIsEnableComponentStretchChanged));

        private static void OnIsEnableComponentStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsEnableComponentStretch;
            target.OnIsEnableComponentChanged(oldtarget, newTarget);
        }
        private async void OnIsEnableComponentChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget)
            {
                _imageStateName.Visibility = Visibility.Visible;
                _contentPresenter.Visibility = Visibility.Visible;

            }
            else
            {
                _imageStateName.Visibility = Visibility.Collapsed;
                _contentPresenter.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

        #region IsEnableColorsStretch
        /// <summary>
        /// 是否启用三种状态
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
            typeof(ButtonColors),
            new PropertyMetadata(false, OnIsEnableColorsStretchChanged));

        private static void OnIsEnableColorsStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonColors)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsEnableColorsStretch;
            target.OnIsEnableColorsChanged(oldtarget, newTarget);
        }

        private async void OnIsEnableColorsChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget && _gridStateName != null)
            {
                if (IsType(DeviceFamily.Mobile)) return;

                _gridStateName.PointerEntered += OnPointerEntered;
                _gridStateName.PointerExited += OnPointerExited;
                _gridStateName.PointerPressed += OnPointerPressed;
                _gridStateName.PointerReleased += OnPointerReleased;
            }

        }
        private void OnPointerExited(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            VisualStateManager.GoToState(this, "Normal", true);
            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(NormalStateColors);
        }
        private void OnPointerPressed(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(PressedStateColors);
        }
        private void OnPointerReleased(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(HoverStateColors);
        }
        private void OnPointerEntered(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            //VisualStateManager.GoToState(this, "PointerOver", true);

            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(HoverStateColors);
        }
        #endregion

    }
}
