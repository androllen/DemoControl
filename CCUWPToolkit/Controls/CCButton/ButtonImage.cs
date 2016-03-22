using CCUWPToolkit.Controls.CCButton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = RectangleStateName, Type = typeof(Rectangle))]
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = ImageStateName, Type = typeof(Image))]
    public class ButtonImage : ButtonImageBase
    {
        /// <summary>
        /// 矩形控件名字
        /// </summary>
        private const string RectangleStateName = "PART_RectangleStateName";
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
        /// <summary>
        /// 矩形控件
        /// </summary>
        private Rectangle _rectangleStateName;
        private Grid _gridStateName;
        public ButtonImage()
        {
            DefaultStyleKey = typeof(ButtonImage);
        }

        #region NormalStateImage
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
            typeof(ButtonImage),
            new PropertyMetadata(Colors.Transparent, OnNormalStateColorsChanged));

        private static void OnNormalStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
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
        private Color HoverStateColors
        {
            get { return (Color)GetValue(HoverStateColorsProperty); }
            set { SetValue(HoverStateColorsProperty, value); }
        }
        public static readonly DependencyProperty HoverStateColorsProperty =
            DependencyProperty.Register(
            "HoverStateColors",
            typeof(Color),
            typeof(ButtonImage),
            new PropertyMetadata(Colors.Transparent, OnHoverStateColorsChanged));

        private static void OnHoverStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
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
        private Color PressedStateColors
        {
            get { return (Color)GetValue(PressedStateColorsProperty); }
            set { SetValue(PressedStateColorsProperty, value); }
        }
        public static readonly DependencyProperty PressedStateColorsProperty =
            DependencyProperty.Register(
            "PressedStateColors",
            typeof(Color),
            typeof(ButtonImage),
            new PropertyMetadata(Colors.Transparent, OnPressedStateColorsChanged));

        private static void OnPressedStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
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
            typeof(ButtonImage),
            new PropertyMetadata(Colors.Transparent, OnDisabledStateColorsChanged));

        private static void OnDisabledStateColorsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
            Color oldtarget = (Color)e.OldValue;
            Color newTarget = target.NormalStateColors;
            //to do
            target.UpdateRectangleState(oldtarget, newTarget);
        }
        private async void UpdateRectangleState(Color oldtarget, Color newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (_rectangleStateName != null)
                _rectangleStateName.Fill = new SolidColorBrush(newTarget);
        }
        #endregion
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);


        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _imageStateName = (Image)GetTemplateChild(ImageStateName);
            _rectangleStateName = (Rectangle)GetTemplateChild(RectangleStateName);
            _waitForApplyTemplateTaskSource.SetResult(true);
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
            typeof(ButtonImage),
            new PropertyMetadata(HorizontalAlignment.Stretch));



        private static void OnGeneratedImageHorizontalStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
            HorizontalAlignment oldGeneratedDisabledStateGrayscaleAmount = (HorizontalAlignment)e.OldValue;
            HorizontalAlignment newGeneratedDisabledStateGrayscaleAmount = target.GeneratedImageHorizontalStretch;
            target.OnGeneratedHorizontalAlignmentChanged(oldGeneratedDisabledStateGrayscaleAmount, newGeneratedDisabledStateGrayscaleAmount);
        }

        protected virtual void OnGeneratedHorizontalAlignmentChanged(
            HorizontalAlignment oldGeneratedDisabledStateGrayscaleAmount, 
            HorizontalAlignment newGeneratedDisabledStateGrayscaleAmount)
        {
            UpdateGeneratedImageHorizontalStretch();
        }
        private void UpdateGeneratedImageHorizontalStretch()
        {

        }

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
            typeof(ButtonImage),
            new PropertyMetadata(VerticalAlignment.Stretch));

        private static void OnGeneratedImageVerticalStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
            VerticalAlignment oldGeneratedDisabledStateGrayscaleAmount = (VerticalAlignment)e.OldValue;
            VerticalAlignment newGeneratedDisabledStateGrayscaleAmount = target.GeneratedImageVerticalStretch;
            target.OnGeneratedVerticalAlignmentChanged(oldGeneratedDisabledStateGrayscaleAmount, newGeneratedDisabledStateGrayscaleAmount);
        }
        protected virtual void OnGeneratedVerticalAlignmentChanged(
            VerticalAlignment oldGeneratedDisabledStateGrayscaleAmount,
            VerticalAlignment newGeneratedDisabledStateGrayscaleAmount)
        {
            UpdateGeneratedImageVerticalStretch();
        }
        private void UpdateGeneratedImageVerticalStretch()
        {

        }
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
            typeof(ButtonImage),
            new PropertyMetadata(false, OnIsGeneratedImageStretchChanged));
        private static void OnIsGeneratedImageStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsGeneratedImageStretch;
            target.OnIsGeneratedImageChanged(oldtarget, newTarget);
        }
        private void OnIsGeneratedImageChanged(bool oldtarget,bool newTarget)
        {
            if (oldtarget != newTarget)
                _imageStateName.Visibility = Visibility.Collapsed;
            else
                _imageStateName.Visibility = Visibility.Visible;
        }
        #endregion

    }
}
