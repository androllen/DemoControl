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
    //[TemplatePart(Name = GridElementName, Type = typeof(Grid))]
    //[TemplatePart(Name = TitleElementName, Type = typeof(ContentControl))]
    //[TemplatePart(Name = LeftBtnElementName, Type = typeof(WYBtnColors))]
    //[TemplatePart(Name = RightBtnElementName, Type = typeof(WYBtnColors))]
    public class WYHeaderTitleBar : BaseControl
    {
        //private readonly TaskCompletionSource<bool> _waitForApplyTemplateTaskSource = new TaskCompletionSource<bool>(false);
        //private const string GridElementName = "PART_GridElementName";
        //private const string TitleElementName = "PART_TitleElementName";
        //private const string LeftBtnElementName = "PART_LeftBtnElementName";
        //private const string RightBtnElementName = "PART_RightBtnElementName";

        private Grid _gridElementName;

        public WYHeaderTitleBar()
        {
            DefaultStyleKey = typeof(WYHeaderTitleBar);
        }

        protected override void OnApplyTemplate()
        {
            //_waitForApplyTemplateTaskSource.SetResult(true);
            //_gridElementName = GetTemplateChild(GridElementName) as Grid;


            base.OnApplyTemplate();
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

        public string LeftTextTitle
        {
            get { return (string)GetValue(LeftTextTitleProperty); }
            set { SetValue(LeftTextTitleProperty, value); }
        }

        public static readonly DependencyProperty LeftTextTitleProperty =
            DependencyProperty.Register("LeftTextTitle",
                typeof(string),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty RightTextTitleProperty =
            DependencyProperty.Register("RightTextTitle",
                typeof(string),
                typeof(WYHeaderTitleBar),
                new PropertyMetadata(string.Empty));

        public string RightTextTitle
        {
            get { return (string)GetValue(RightTextTitleProperty); }
            set { SetValue(RightTextTitleProperty, value); }
        }
    }
}
