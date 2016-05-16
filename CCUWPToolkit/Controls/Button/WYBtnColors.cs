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
using WeYa.Utils;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = ContentPresenterName, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = ImageStateName, Type = typeof(Image))]
    public class WYBtnColors : BaseButton
    {
        #region Property
        /// <summary>
        /// 矩形控件名字
        /// </summary>
        private const string ContentPresenterName = "PART_ContentPresenter";
        /// <summary>
        /// Grid
        /// </summary>
        private const string GridStateName = "PART_GridStateName";
        /// <summary>
        /// 图片控件名字
        /// </summary>
        private const string ImageStateName = "PART_ImageStateName";
        private Grid _gridStateName;
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        #endregion

        public WYBtnColors()
        {
            DefaultStyleKey = typeof(WYBtnColors);
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
            typeof(WYBtnColors),
            new PropertyMetadata(Colors.Transparent, OnNormalStateColorsChanged));

        private static void OnNormalStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnColors)d;
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
            typeof(WYBtnColors),
            new PropertyMetadata(Colors.Transparent, OnHoverStateColorsChanged));

        private static void OnHoverStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnColors)d;
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
            typeof(WYBtnColors),
            new PropertyMetadata(Colors.Transparent, OnPressedStateColorsChanged));

        private static void OnPressedStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnColors)d;
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
            typeof(WYBtnColors),
            new PropertyMetadata(Colors.Transparent, OnDisabledStateColorsChanged));

        private static void OnDisabledStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnColors)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);
        }
        #endregion
        /// <summary>
        /// 更新三种状态
        /// </summary>
        /// <param name="oldtarget"></param>
        /// <param name="newTarget"></param>
        private async void UpdateRectangleState(Color oldtarget, Color newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (_gridStateName != null)
                _gridStateName.Background = new SolidColorBrush(newTarget);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _waitForApplyTemplateTaskSource.SetResult(true);
        }

        #region IsEnableColorsStretch
        /// <summary>
        /// 是否启用三种颜色状态
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
            typeof(WYBtnColors),
            new PropertyMetadata(false, OnIsEnableColorsStretchChanged));

        private static void OnIsEnableColorsStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnColors)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsEnableColorsStretch;
            target.OnIsEnableColorsChanged(oldtarget, newTarget);
        }

        private async void OnIsEnableColorsChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget && _gridStateName != null)
            {
                if (DeviceUtil.IsType(DeviceFamily.Mobile)) return;

                _gridStateName.PointerEntered += OnPointerEntered;
                _gridStateName.PointerExited += OnPointerExited;
                _gridStateName.PointerPressed += OnPointerPressed;
                _gridStateName.PointerReleased += OnPointerReleased;
            }

        }
        private void OnPointerExited(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            VisualStateManager.GoToState(this, "Normal", true);
            if (_gridStateName != null)
                _gridStateName.Background = new SolidColorBrush(NormalStateColors);
        }
        private void OnPointerPressed(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_gridStateName != null)
                _gridStateName.Background = new SolidColorBrush(PressedStateColors);
        }
        private void OnPointerReleased(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            if (_gridStateName != null)
                _gridStateName.Background = new SolidColorBrush(HoverStateColors);
        }
        private void OnPointerEntered(object sender, PointerRoutedEventArgs pointerRoutedEventArgs)
        {
            //VisualStateManager.GoToState(this, "PointerOver", true);

            if (_gridStateName != null)
                _gridStateName.Background = new SolidColorBrush(HoverStateColors);
        }
        #endregion

    }
}
