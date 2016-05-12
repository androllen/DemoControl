/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 13:45:52
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using WeYa.Utils;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = ImageElementName, Type = typeof(Image))]
    [TemplatePart(Name = RectangleElementState, Type = typeof(Rectangle))]
    [TemplatePart(Name = GridElementState, Type = typeof(Grid))]
    public class WYImage : BaseControl
    {
        private const string RectangleElementState = "PART_RectangleElementState";
        private const string ImageElementName = "PART_ImageElementState";
        private const string GridElementState = "PART_GridElementState";

        private Grid _grid;
        private Image _image;
        private Rectangle _rectangle;
        private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);

        public WYImage()
        {
            DefaultStyleKey = typeof(WYImage);
        }

        protected override void OnApplyTemplate()
        {
            _grid = GetTemplateChild(GridElementState) as Grid;
            _image = GetTemplateChild(ImageElementName) as Image;
            _rectangle = GetTemplateChild(RectangleElementState) as Rectangle;

            _waitForApplyTemplateTaskSource.SetResult(true);
            base.OnApplyTemplate();
        }

        #region DefaultUri

        public string DefaultUri
        {
            get { return (string)GetValue(DefaultUriProperty); }
            set { SetValue(DefaultUriProperty, value); }
        }

        public static readonly DependencyProperty DefaultUriProperty = DependencyProperty.Register(
            "DefaultUri",
            typeof(string),
            typeof(WYImage),
            new PropertyMetadata(string.Empty, DefaultImageUriChangedCallback));

        private static void DefaultImageUriChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYImage)dependencyObject;
            target.OnDefaultImageUriChanged();
        }
        private async void OnDefaultImageUriChanged()
        {
            await _waitForApplyTemplateTaskSource.Task;
            _image.Source = new BitmapImage(new Uri(DefaultUri, UriKind.RelativeOrAbsolute));

        }

        #endregion

        #region Stretch
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(
            "Stretch", typeof(Stretch), typeof(WYImage), new PropertyMetadata(Stretch.UniformToFill));

        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        #endregion

        #region ImageUrl

        public static readonly DependencyProperty ImageUrlProperty = DependencyProperty.Register(
            "ImageUrl", 
            typeof(string), 
            typeof(WYImage), 
            new PropertyMetadata(string.Empty, ImageUriChangedCallback));

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        private static void ImageUriChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            var target = (WYImage)dependencyObject;
            target.OnImageUrlChanged();
        }

        private async void OnImageUrlChanged()
        {
            await _waitForApplyTemplateTaskSource.Task;

            var uri = await ImageUtil.LoadImage(ImageUrl, LoadNew);
            if (!string.IsNullOrEmpty(uri.OriginalString) || !string.IsNullOrEmpty(DefaultUri))
            {
                _image.Source = uri != null ? new BitmapImage(uri) : new BitmapImage(new Uri(DefaultUri, UriKind.RelativeOrAbsolute));
                StoryBordImg(_image);
            }
            else
            {
                _grid.Background = this.ColorsSource;
                StoryBordImg(_grid);
            }

        }

        private void StoryBordImg(UIElement img)
        {
            var sb = new Storyboard();
            var anim = new DoubleAnimation { From = 0, To = 1, Duration = TimeSpan.FromMilliseconds(500) };
            Storyboard.SetTarget(anim, img);
            Storyboard.SetTargetProperty(anim, "Opacity");
            sb.Children.Add(anim);
            sb.Begin();
        }

        #endregion

        #region IsNightMode
        public bool IsNightMode
        {
            get { return (bool)GetValue(IsNightModeProperty); }
            set { SetValue(IsNightModeProperty, value); }
        }
        public static readonly DependencyProperty IsNightModeProperty = DependencyProperty.Register(
            "IsNightMode", typeof(bool), typeof(WYImage), new PropertyMetadata(default(bool), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var target = (WYImage)dependencyObject;
            bool oldtarget = (bool)e.OldValue;
            bool newTarget = target.IsNightMode;
            target.OnRectangleNightModeChanged(oldtarget, newTarget);
        }
        private async void OnRectangleNightModeChanged(bool oldtarget, bool newTarget)
        {
            await _waitForApplyTemplateTaskSource.Task;
            _rectangle.Visibility = newTarget ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        #region LoadNew

        public bool LoadNew
        {
            get { return (bool)GetValue(LoadNewProperty); }
            set { SetValue(LoadNewProperty, value); }
        }
        public static readonly DependencyProperty LoadNewProperty =
            DependencyProperty.Register(
            "LoadNew",
            typeof(bool),
            typeof(WYImage),
            new PropertyMetadata(true));
        #endregion

    }
}
