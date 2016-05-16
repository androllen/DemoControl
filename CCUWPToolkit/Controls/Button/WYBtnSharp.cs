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
    [TemplatePart(Name = EllipseStateName, Type = typeof(Ellipse))]
    [TemplatePart(Name = StackPanelStateName, Type = typeof(StackPanel))]
    public class WYBtnSharp : BaseButton
    {
        #region Property
        private const string StackPanelStateName = "PART_StackPanelStateName";
        private const string GridStateName = "PART_GridStateName";
        private const string EllipseStateName = "PART_EllipseStateName";

        private Grid _gridStateName;
        private Ellipse _ellipseStateName;
        private StackPanel _stackPanelStateName;
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        #endregion

        public WYBtnSharp()
        {
            DefaultStyleKey = typeof(WYBtnSharp);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _ellipseStateName = (Ellipse)GetTemplateChild(EllipseStateName);
            _stackPanelStateName = (StackPanel)GetTemplateChild(StackPanelStateName);

            _waitForApplyTemplateTaskSource.SetResult(true);
        }

        #region ImageUri
        public string ImageUri
        {
            get { return (string)GetValue(ImageUriProperty); }
            set { SetValue(ImageUriProperty, value); }
        }
        public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register(
             "ImageUri",
             typeof(string),
             typeof(WYBtnSharp),
             new PropertyMetadata(string.Empty, ImageUriChanged));

        private static void ImageUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WYBtnSharp)d).ImageUri = (string)e.NewValue;
            ((WYBtnSharp)d).SetImageImgSource();
        }
        private async void SetImageImgSource()
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (!String.IsNullOrEmpty(ImageUri))
            {
                Uri uri = new Uri(ImageUri);

                if (_ellipseStateName != null)
                {
                    var ib = new ImageBrush();
                    ib.ImageSource = new BitmapImage(uri) { DecodePixelHeight = 200, DecodePixelWidth = 200 };
                    ib.Stretch = StretchSource;
                    ib.ImageFailed += Img_ImageFailed;
                    _ellipseStateName.Fill = ib;
                }
            }
        }
        private void Img_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            if (_ellipseStateName != null)
            {
                _ellipseStateName.Fill = new SolidColorBrush(Colors.Gray);
                ((ImageBrush)_ellipseStateName.Fill).ImageFailed -= Img_ImageFailed;
            }
        }

        #endregion

        #region EllipseWidth
        public double EllipseWidth
        {
            get { return (double)GetValue(EllipseWidthProperty); }
            set { SetValue(EllipseWidthProperty, value); }
        }
        public static readonly DependencyProperty EllipseWidthProperty =
            DependencyProperty.Register(
            "EllipseWidth",
            typeof(double),
            typeof(WYBtnSharp),
            new PropertyMetadata(0.0));
        #endregion

        #region EllipseHeight
        public double EllipseHeight
        {
            get { return (double)GetValue(EllipseHeightProperty); }
            set { SetValue(EllipseHeightProperty, value); }
        }
        public static readonly DependencyProperty EllipseHeightProperty =
            DependencyProperty.Register(
            "EllipseHeight",
            typeof(double),
            typeof(WYBtnSharp),
            new PropertyMetadata(0.0));

        #endregion

        #region 控件或布局方向
        public Orientation OrientationSource
        {
            get { return (Orientation)GetValue(OrientationSourceProperty); }
            set { SetValue(OrientationSourceProperty, value); }
        }

        private static readonly DependencyProperty OrientationSourceProperty =
            DependencyProperty.Register("OrientationSource",
                typeof(Orientation),
                typeof(WYBtnSharp),
                new PropertyMetadata(Orientation.Vertical, OnOrientationStateChanged));

        private static void OnOrientationStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYBtnSharp)d;
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
