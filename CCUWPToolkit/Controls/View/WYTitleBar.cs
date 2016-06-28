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
    [TemplatePart(Name = LeftBtnElementName, Type = typeof(WYBtnImage))]
    [TemplatePart(Name = RightBtnElementName, Type = typeof(WYBtnImage))]
    public class WYTitleBar : BaseControl
    {
        private const string LeftBtnElementName = "PART_LeftBtnElementState";
        private const string RightBtnElementName = "PART_RightBtnElementState";

        public WYTitleBar()
        {
            DefaultStyleKey = typeof(WYTitleBar);
        }
        public event RoutedEventHandler LeftClick;
        public event RoutedEventHandler RightClick;
        private WYBtnImage _leftBtn;
        private WYBtnImage _rightBtn;

        protected override void OnApplyTemplate()
        {
            if (_leftBtn != null)
                _leftBtn.Click -= OnLeftBtn_Click;

            if (_rightBtn != null)
                _rightBtn.Click -= OnRightBtn_Click;

            _leftBtn = GetTemplateChild(LeftBtnElementName) as WYBtnImage;
            _rightBtn = GetTemplateChild(RightBtnElementName) as WYBtnImage;

            if (_leftBtn != null)
                _leftBtn.Click += OnLeftBtn_Click;

            if (_rightBtn != null)
                _rightBtn.Click += OnRightBtn_Click;

            base.OnApplyTemplate();
        }

        private void OnLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            LeftClick?.Invoke(sender, e);
        }

        private void OnRightBtn_Click(object sender, RoutedEventArgs e)
        {
            RightClick?.Invoke(sender, e);
        }

        #region Title
        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("Title", 
                typeof(object), 
                typeof(WYTitleBar), 
                new PropertyMetadata(string.Empty));
        #endregion

        #region BtnLeftStyle
        /// <summary>
        /// TitleStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty BtnLeftStyleProperty =
            DependencyProperty.Register(
                "BtnLeftStyle",
                typeof(Style),
                typeof(WYTitleBar),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the TitleStyle property. This dependency property 
        /// indicates the style to use for the title TextBlock.
        /// </summary>
        public Style BtnLeftStyle
        {
            get { return (Style)GetValue(BtnLeftStyleProperty); }
            set { SetValue(BtnLeftStyleProperty, value); }
        }
        #endregion

        #region BtnRightStyle
        /// <summary>
        /// TitleStyle Dependency Property
        /// </summary>
        public static readonly DependencyProperty BtnRightStyleProperty =
            DependencyProperty.Register(
                "BtnRightStyle",
                typeof(Style),
                typeof(WYTitleBar),
                new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the TitleStyle property. This dependency property 
        /// indicates the style to use for the title TextBlock.
        /// </summary>
        public Style BtnRightStyle
        {
            get { return (Style)GetValue(BtnRightStyleProperty); }
            set { SetValue(BtnRightStyleProperty, value); }
        }
        #endregion
    }
}
