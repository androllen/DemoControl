/********************************************************************************
** 作者： androllen
** 日期： 16/5/16 14:42:04
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = StackPanelStateName, Type = typeof(StackPanel))]
    public class WYBtnImage : BaseButton
    {
        #region Property
        /// <summary>
        /// Grid
        /// </summary>
        private const string GridStateName = "PART_GridStateName";
        /// <summary>
        /// 控件名字
        /// </summary>
        private const string StackPanelStateName = "PART_StackPanelStateName";
        private StackPanel _stackPanelStateName;
        private Grid _gridStateName;
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        #endregion

        public WYBtnImage()
        {
            DefaultStyleKey = typeof(WYBtnImage);
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
            typeof(WYBtnImage),
            new PropertyMetadata(Colors.Transparent, OnNormalStateColorsChanged));

        private static void OnNormalStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnImage)d;
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
            typeof(WYBtnImage),
            new PropertyMetadata(Colors.Transparent, OnHoverStateColorsChanged));

        private static void OnHoverStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnImage)d;
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
            typeof(WYBtnImage),
            new PropertyMetadata(Colors.Transparent, OnPressedStateColorsChanged));

        private static void OnPressedStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnImage)d;
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
            typeof(WYBtnImage),
            new PropertyMetadata(Colors.Transparent, OnDisabledStateColorsChanged));

        private static void OnDisabledStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnImage)d;
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
            _stackPanelStateName = (StackPanel)GetTemplateChild(StackPanelStateName);
            _waitForApplyTemplateTaskSource.SetResult(true);
        }

        #region 控件或布局方向
        public Orientation OrientationSource
        {
            get { return (Orientation)GetValue(OrientationSourceProperty); }
            set { SetValue(OrientationSourceProperty, value); }
        }

        private static readonly DependencyProperty OrientationSourceProperty =
            DependencyProperty.Register("OrientationSource",
                typeof(Orientation),
                typeof(WYBtnImage),
                new PropertyMetadata(Orientation.Vertical, OnOrientationStateChanged));

        private static void OnOrientationStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnImage)d;
            Orientation oldtarget = (Orientation)e.OldValue;
            Orientation newTarget = target.OrientationSource;
            target.UpdateOrientationState(oldtarget, newTarget);
        }
        /// <summary>
        /// 更新布局方向状态
        /// </summary>
        /// <param name="oldtarget"></param>
        /// <param name="newTarget"></param>
        private async void UpdateOrientationState(Orientation oldtarget, Orientation newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (_stackPanelStateName != null)
                _stackPanelStateName.Orientation = newTarget;
        }
        #endregion

    }
}
