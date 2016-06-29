using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CCUWPToolkit.Controls.Xaml
{
    [ContentProperty(Name = "TemplatePart")]
    public sealed partial class WYGrid : UserControl
    {
        public WYGrid()
        {
            this.InitializeComponent();
        }
        #region 背景色
        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ColorsSource
        {
            get { return (Brush)GetValue(ColorsSourceProperty); }
            set { SetValue(ColorsSourceProperty, value); }
        }

        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(WYGrid),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
        #endregion

        public static readonly DependencyProperty HeaderTextProperty = 
            DependencyProperty.Register("HeaderText", typeof(string), typeof(WYGrid), 
                new PropertyMetadata(null));
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty TemplatePartProperty = 
            DependencyProperty.Register("TemplatePart", typeof(object), typeof(WYGrid), 
                new PropertyMetadata(null));

        public object TemplatePart
        {
            get { return GetValue(TemplatePartProperty); }
            set { SetValue(TemplatePartProperty, value); }
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public double HeightSource
        {
            get { return (double)GetValue(HeightSourceProperty); }
            set { SetValue(HeightSourceProperty, value); }
        }

        public static readonly DependencyProperty HeightSourceProperty =
            DependencyProperty.Register("HeightSource", typeof(double), typeof(WYGrid),
                new PropertyMetadata(40.0));

        public new static readonly DependencyProperty HorizontalAlignmentProperty = 
            DependencyProperty.Register("HorizontalAlignment", 
                typeof(HorizontalAlignment), 
                typeof(WYGrid), 
                new PropertyMetadata(HorizontalAlignment.Center));

        public new HorizontalAlignment HorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty); }
            set { SetValue(HorizontalAlignmentProperty, value); }
        }
    }
}
