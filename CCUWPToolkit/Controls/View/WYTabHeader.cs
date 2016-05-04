/********************************************************************************
** 作者： androllen
** 日期： 16/5/4 18:08:51
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CCUWPToolkit.Controls
{
    public class WYTabHeader : BaseText
    {
        public WYTabHeader()
        {
            DefaultStyleKey = typeof(WYTabHeader);
        }
    
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register("Glyph", typeof(string), typeof(WYTabHeader), null);

        public string Glyph
        {
            get { return GetValue(GlyphProperty) as string; }
            set { SetValue(GlyphProperty, value); }
        }

    }
}
