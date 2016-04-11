/********************************************************************************
** 作者： androllen
** 日期： 16/4/8 10:47:43
*********************************************************************************/
using CCUWPToolkit.Controls.Extensions;
using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = LayoutRootPanelName, Type = typeof(Panel))]
    [TemplatePart(Name = TextTextBlockName, Type = typeof(TextBlock))]
    [TemplateVisualState(GroupName = PopupStatesGroupName, Name = OpenPopupStateName)]
    public class WYToastDialog : BaseDialog
    {
        /// <summary>
        /// Template Part Names
        /// </summary>
        private const string PopupStatesGroupName = "PopupStates";
        private const string OpenPopupStateName = "OpenPopupState";

        private const string LayoutRootPanelName = "LayoutRoot";
        private const string TextTextBlockName = "TextTextBlock";
        /// <summary>
        /// Template Part Fields
        /// </summary>
        private Popup _dialogPopup;
        private Panel _layoutRoot;
        private TextBlock _textTextBlock;
        /// <summary>
        /// Flag for preventing reentrancy in the Show() method.
        /// </summary>
        private bool _shown;

        public WYToastDialog()
        {
            DefaultStyleKey = typeof(WYToastDialog);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _layoutRoot = GetTemplateChild(LayoutRootPanelName) as Panel;
            _textTextBlock = GetTemplateChild(TextTextBlockName) as TextBlock;
        }

        private FrameworkElement RootFrameworkElement
        {
            get
            {
                return (FrameworkElement)Window.Current.Content;
            }
        }

        public async void ShowAsync(string text, Action action = null)
        {
            if (_shown)
            {
                throw new InvalidOperationException();
            }

            //注册自适应
            RootFrameworkElement.SizeChanged += WYDialog_SizeChanged;
            _shown = true;
            _dialogPopup = new Popup();
            _dialogPopup.Child = this;
            _dialogPopup.IsOpen = true;
            await this.WaitForLayoutUpdateAsync();
            _textTextBlock.Text = text;

            ResizeLayoutRoot();
            // Show dialog
            await this.GoToVisualStateAsync(_layoutRoot, PopupStatesGroupName, OpenPopupStateName);
            // Hide dialog
            _dialogPopup.IsOpen = false;
            _shown = false;
            action?.Invoke();
        }
        /// <summary>
        /// 重载布局
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            ResizeLayoutRoot();
            return base.ArrangeOverride(finalSize);
        }
        /// <summary>
        /// 自适应大小布局
        /// </summary>
        private void ResizeLayoutRoot()
        {
            var root = RootFrameworkElement;
            _layoutRoot.Width = root.ActualWidth;
            _layoutRoot.Height = root.ActualHeight;
        }
        /// <summary>
        /// 注册根页面自适应遮罩背景
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WYDialog_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeLayoutRoot();
        }
    }
}
