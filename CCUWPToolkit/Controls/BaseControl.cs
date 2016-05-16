/********************************************************************************
** 作者： androllen
** 日期： 16/4/6 11:21:24
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    public abstract class BaseControl : Control ,IBaseControl
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
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
            typeof(BaseControl),
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
            typeof(BaseControl),
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
            typeof(BaseControl),
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
            typeof(BaseControl),
            new PropertyMetadata(VerticalAlignment.Center));
        #endregion

        #region 文本大小
        /// <summary>
        /// 背景色
        /// </summary>
        public double WidthSource
        {
            get { return (double)GetValue(WidthSourceProperty); }
            set { SetValue(WidthSourceProperty, value); }
        }

        public static readonly DependencyProperty WidthSourceProperty =
            DependencyProperty.Register("WidthSource", typeof(double), typeof(BaseControl),
                new PropertyMetadata(21.0));
        #endregion

        #region 文本大小
        /// <summary>
        /// 背景色
        /// </summary>
        public double HeightSource
        {
            get { return (double)GetValue(HeightSourceProperty); }
            set { SetValue(HeightSourceProperty, value); }
        }

        public static readonly DependencyProperty HeightSourceProperty =
            DependencyProperty.Register("HeightSource", typeof(double), typeof(BaseControl),
                new PropertyMetadata(21.0));
        #endregion

        #region 文本大小
        /// <summary>
        /// 背景色
        /// </summary>
        public double FontSizeSource
        {
            get { return (double)GetValue(FontSizeSourceProperty); }
            set { SetValue(FontSizeSourceProperty, value); }
        }

        public static readonly DependencyProperty FontSizeSourceProperty =
            DependencyProperty.Register("FontSizeSource", typeof(double), typeof(BaseControl),
                new PropertyMetadata(21.0));
        #endregion

        #region 前景色
        /// <summary>
        /// 背景色
        /// </summary>
        public Brush ForegroundSource
        {
            get { return (Brush)GetValue(ForegroundSourceProperty); }
            set { SetValue(ForegroundSourceProperty, value); }
        }

        public static readonly DependencyProperty ForegroundSourceProperty =
            DependencyProperty.Register("ForegroundSource", typeof(Brush), typeof(BaseControl),
                new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        #endregion

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
            DependencyProperty.Register("ColorsSource", typeof(Brush), typeof(BaseControl),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));
        #endregion

        #region 背景圆角度
        /// <summary>
        /// 背景圆角度
        /// </summary>
        public CornerRadius CornerSource
        {
            get { return (CornerRadius)GetValue(CornerSourceProperty); }
            set { SetValue(CornerSourceProperty, value); }
        }

        public static readonly DependencyProperty CornerSourceProperty =
            DependencyProperty.Register("CornerSource", typeof(CornerRadius), typeof(BaseControl),
                new PropertyMetadata(new CornerRadius(0)));
        #endregion

        #region 背景边距
        public Thickness MarginSource
        {
            get { return (Thickness)GetValue(MarginSourceProperty); }
            set { SetValue(MarginSourceProperty, value); }
        }

        private static readonly DependencyProperty MarginSourceProperty =
            DependencyProperty.Register("MarginSource",
                typeof(Thickness),
                typeof(BaseControl),
                new PropertyMetadata(new Thickness(0)));
        #endregion

        #region 图片的扩展
        /// <summary>
        /// 图片的扩展
        /// </summary>
        public Stretch StretchSource
        {
            get { return (Stretch)GetValue(StretchSourceProperty); }
            set { SetValue(StretchSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stretch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StretchSourceProperty =
            DependencyProperty.Register("StretchSource", typeof(Stretch), typeof(BaseControl),
                new PropertyMetadata(Stretch.None));
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
                typeof(BaseControl),
                new PropertyMetadata(Orientation.Horizontal));
        #endregion
    }
}
