/********************************************************************************
** 作者： androllen
** 日期： 16/4/22 17:07:52
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = LeftBtnElementName, Type = typeof(WYBtnColors))]
    [TemplatePart(Name = RightBtnElementName, Type = typeof(WYBtnColors))]
    public class WYHeaderTitleBar : BaseControl
    {
        private const string LeftBtnElementName = "PART_LeftBtnElementState";
        private const string RightBtnElementName = "PART_RightBtnElementState";

        public WYHeaderTitleBar()
        {
            DefaultStyleKey = typeof(WYHeaderTitleBar);
        }
        public event EventHandler<RoutedEventArgs> LeftClick;
        public event EventHandler<RoutedEventArgs> RightClick;
        private WYBtnColors _leftBtn;
        private WYBtnColors _rightBtn;

        protected override void OnApplyTemplate()
        {
            if (_leftBtn != null)
                _leftBtn.Click -= OnLeftBtn_Click;

            if (_rightBtn != null)
                _rightBtn.Click -= OnRightBtn_Click;

            _leftBtn = GetTemplateChild(LeftBtnElementName) as WYBtnColors;
            _rightBtn = GetTemplateChild(RightBtnElementName) as WYBtnColors;

            if (_leftBtn != null)
                _leftBtn.Click += OnLeftBtn_Click;

            if (_rightBtn != null)
                _rightBtn.Click += OnRightBtn_Click;

            base.OnApplyTemplate();
        }

        private void OnLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LeftClick != null)
                LeftClick(sender, e);
        }

        private void OnRightBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RightClick != null)
                RightClick(sender, e);
        }

        public ImageSource LeftIcon
        {
            get { return (ImageSource)GetValue(LeftIconProperty); }
            set { SetValue(LeftIconProperty, value); }
        }

        private static readonly DependencyProperty LeftIconProperty =
            DependencyProperty.Register("LeftIcon",
                typeof(ImageSource),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(null));

        public ImageSource RightIcon
        {
            get { return (ImageSource)GetValue(RightIconProperty); }
            set { SetValue(RightIconProperty, value); }
        }

        private static readonly DependencyProperty RightIconProperty =
            DependencyProperty.Register("RightIcon",
                typeof(ImageSource),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(null));

        public Visibility LeftVisibility
        {
            get { return (Visibility)GetValue(LeftVisibilityProperty); }
            set { SetValue(LeftVisibilityProperty, value); }
        }

        private static readonly DependencyProperty LeftVisibilityProperty =
            DependencyProperty.Register("LeftVisibility",
                typeof(Visibility),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(Visibility.Collapsed));


        public Visibility RightVisibility
        {
            get { return (Visibility)GetValue(RightVisibilityProperty); }
            set { SetValue(RightVisibilityProperty, value); }
        }

        private static readonly DependencyProperty RightVisibilityProperty =
            DependencyProperty.Register("RightVisibility",
                typeof(Visibility),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(Visibility.Collapsed));


        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("Title", 
                typeof(object), 
                typeof(WYHeaderTitleBar), 
                new PropertyMetadata(string.Empty));

        public string LeftText
        {
            get { return (string)GetValue(LeftTextProperty); }
            set { SetValue(LeftTextProperty, value); }
        }

        public static readonly DependencyProperty LeftTextProperty =
            DependencyProperty.Register("LeftText",
                typeof(string),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty RightTextProperty =
            DependencyProperty.Register("RightText",
                typeof(string),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(string.Empty));

        public string RightText
        {
            get { return (string)GetValue(RightTextProperty); }
            set { SetValue(RightTextProperty, value); }
        }

        #region TitleStyle
        /// <summary>
        /// TitleStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty BtnColorsStyleProperty =
            DependencyProperty.Register(
                "BtnColorsStyle",
                typeof(Style),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the TitleStyle property. This dependency property 
        /// indicates the style to use for the title TextBlock.
        /// </summary>
        public Style BtnColorsStyle
        {
            get { return (Style)GetValue(BtnColorsStyleProperty); }
            set { SetValue(BtnColorsStyleProperty, value); }
        }
        #endregion
    }
}
