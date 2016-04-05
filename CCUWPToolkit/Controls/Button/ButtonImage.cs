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
    [TemplatePart(Name = ContentPresenterName, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = GridStateName, Type = typeof(Grid))]
    [TemplatePart(Name = EllipseStateName, Type = typeof(Ellipse))]
    public class ButtonImage : ButtonBase
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
        private const string EllipseStateName = "PART_EllipseStateName";
        /// <summary>
        /// 图片控件
        /// </summary>
        private Ellipse _ellipseStateName;
        private ContentPresenter _contentPresenter;
        private Grid _gridStateName;
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        #endregion

        public ButtonImage()
        {
            DefaultStyleKey = typeof(ButtonImage);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _gridStateName = (Grid)GetTemplateChild(GridStateName);
            _ellipseStateName = (Ellipse)GetTemplateChild(EllipseStateName);
            _contentPresenter = (ContentPresenter)GetTemplateChild(ContentPresenterName);
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
             typeof(ButtonImage),
             new PropertyMetadata(string.Empty, ImageUriChanged));

        private static void ImageUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ButtonImage)d).ImageUri = (string)e.NewValue;
            ((ButtonImage)d).SetImageImgSource();
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
                    ib.ImageSource = new BitmapImage(uri) { DecodePixelHeight =200,DecodePixelWidth=200};
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
                ((ImageBrush)_ellipseStateName.Fill).ImageFailed -= Img_ImageFailed;
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
            typeof(ButtonImage),
            new PropertyMetadata(false, OnIsEnableComponentStretchChanged));

        private static void OnIsEnableComponentStretchChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (ButtonImage)d;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsEnableComponentStretch;
            target.OnIsEnableComponentChanged(oldtarget, newTarget);
        }
        private async void OnIsEnableComponentChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;

            if (oldtarget != newTarget)
            {
                _contentPresenter.Visibility = Visibility.Visible;
            }
        }
        #endregion

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
            typeof(ButtonImage),
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
            typeof(ButtonImage),
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
            typeof(ButtonImage),
            new PropertyMetadata(VerticalAlignment.Center));
        #endregion
    }
}
