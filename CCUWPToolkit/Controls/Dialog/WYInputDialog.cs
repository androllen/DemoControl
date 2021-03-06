﻿/********************************************************************************
** 作者： androllen
** 日期： 16/4/6 14:59:50
*********************************************************************************/
using WeYa.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace CCUWPToolkit.Controls
{
    [TemplatePart(Name = LayoutRootPanelName, Type = typeof(Panel))]
    [TemplatePart(Name = ContentBorderName, Type = typeof(Border))]
    [TemplatePart(Name = TitleTextBlockName, Type = typeof(TextBlock))]
    [TemplatePart(Name = InputTextBoxName, Type = typeof(WYTextBox))]
    [TemplatePart(Name = ButtonsPanelName, Type = typeof(Panel))]
    [TemplateVisualState(GroupName = PopupStatesGroupName, Name = OpenPopupStateName)]
    [TemplateVisualState(GroupName = PopupStatesGroupName, Name = ClosedPopupStateName)]
    public class WYInputDialog : BaseDialog
    {
        /// <summary>
        /// Template Part Names
        /// </summary>
        private const string PopupStatesGroupName = "PopupStates";
        private const string OpenPopupStateName = "OpenPopupState";
        private const string ClosedPopupStateName = "ClosedPopupState";

        private const string LayoutRootPanelName = "LayoutRoot";
        private const string ContentBorderName = "ContentBorder";
        private const string InputTextBoxName = "InputTextBox";
        private const string TitleTextBlockName = "TitleTextBlock";
        private const string ButtonsPanelName = "ButtonsPanel";
        /// <summary>
        /// Template Part Fields
        /// </summary>
        private Popup _dialogPopup;
        private Panel _layoutRoot;
        private Border _contentBorder;
        private WYTextBox _inputTextBox;
        private TextBlock _titleTextBlock;
        private Panel _buttonsPanel;
        /// <summary>
        /// Flag for preventing reentrancy in the Show() method.
        /// </summary>
        private bool _shown;
        private TaskCompletionSource<string> _dismissTaskSource;
        private List<BaseButton> _buttons;

        public WYInputDialog()
        {
            DefaultStyleKey = typeof(WYInputDialog);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _layoutRoot = GetTemplateChild(LayoutRootPanelName) as Panel;
            _contentBorder = GetTemplateChild(ContentBorderName) as Border;
            _inputTextBox = GetTemplateChild(InputTextBoxName) as WYTextBox;
            _titleTextBlock = GetTemplateChild(TitleTextBlockName) as TextBlock;
            _buttonsPanel = GetTemplateChild(ButtonsPanelName) as Panel;

            _layoutRoot.Tapped += OnLayoutRootTapped;
            _inputTextBox.KeyUp += OnInputTextBoxKeyUp;
            if (_inputTextBox != null)
                _inputTextBox.PlaceholderText = PlaceholderText;

            _contentBorder.Tapped += OnContentBorderTapped;
        }

        #region PlaceholderText
        /// <summary>
        /// PlaceholderText Dependency Property
        /// </summary>
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register(
                "PlaceholderText",
                typeof(string),
                typeof(WYInputDialog),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the InputText property. This dependency property 
        /// indicates the text in the input box.
        /// </summary>
        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }
        #endregion

        #region IsLightDismissEnabled
        /// <summary>
        /// IsLightDismissEnabled Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsLightDismissEnabledProperty =
            DependencyProperty.Register(
                "IsLightDismissEnabled",
                typeof(bool),
                typeof(WYInputDialog),
                new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets the IsLightDismissEnabled property. This dependency property 
        /// indicates whether the dialog can be dismissed by tapping outside of the main dialog border.
        /// </summary>
        public bool IsLightDismissEnabled
        {
            get { return (bool)GetValue(IsLightDismissEnabledProperty); }
            set { SetValue(IsLightDismissEnabledProperty, value); }
        }
        #endregion

        #region AwaitsCloseTransition
        /// <summary>
        /// AwaitsCloseTransition Dependency Property
        /// </summary>
        public static readonly DependencyProperty AwaitsCloseTransitionProperty =
            DependencyProperty.Register(
                "AwaitsCloseTransition",
                typeof(bool),
                typeof(WYInputDialog),
                new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets the AwaitsCloseTransition property. This dependency property 
        /// indicates whether awaiting ShowAsync() also awaits the closing transition..
        /// </summary>
        public bool AwaitsCloseTransition
        {
            get { return (bool)GetValue(AwaitsCloseTransitionProperty); }
            set { SetValue(AwaitsCloseTransitionProperty, value); }
        }
        #endregion

        private void OnGlobalKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape)
            {
                DismissDialog();
                e.Handled = true;
            }
        }
        /// <summary>
        /// 遮罩背景点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLayoutRootTapped(object sender, TappedRoutedEventArgs e)
        {
            if (e.OriginalSource == sender && this.IsLightDismissEnabled)
            {
                _dismissTaskSource.TrySetResult(CancelButton);
                e.Handled = true;
            }
        }
        /// <summary>
        /// 判断是否点击的内容区域
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnContentBorderTapped(object sender, TappedRoutedEventArgs e)
        {
            if (e.OriginalSource == sender)
            {
                FocusOnButton(AcceptButton);
                e.Handled = true;
            }
        }

        private void FocusOnButton(string buttonContent)
        {
            BaseButton button;

            if (AcceptButton != null && (button = _buttons.FirstOrDefault(b => string.Equals(b.Content, buttonContent))) != null)
            {
                button.Focus(FocusState.Programmatic);
                return;
            }

            if (_buttons.Count > 0)
            {
                button = (WYBtnColors)_buttons[0];
                button.Focus(FocusState.Programmatic);
            }
        }

        private FrameworkElement RootFrameworkElement
        {
            get
            {
                return (FrameworkElement)Window.Current.Content;
            }
        }

        public async Task<string> ShowAsync(string title, string text, params string[] buttonTexts)
        {
            if (_shown)
            {
                throw new InvalidOperationException();
            }

            _shown = true;
            RootFrameworkElement.SizeChanged += WYDialog_SizeChanged;
            Window.Current.Content.KeyUp += OnGlobalKeyUp;
            _dismissTaskSource = new TaskCompletionSource<string>();
            _dialogPopup = new Popup();
            _dialogPopup.Child = this;
            _dialogPopup.IsOpen = true;
            await this.WaitForLayoutUpdateAsync();
            _titleTextBlock.Text = title;
            _buttons = new List<BaseButton>();

            foreach (var buttonText in buttonTexts)
            {
                var button = new WYBtnColors();

                if (this.ButtonStyle != null)
                {
                    button.Style = this.ButtonStyle;
                }

                button.Label = buttonText;
                button.Click += OnButtonClick;
                button.KeyUp += OnGlobalKeyUp;
                _buttons.Add(button);
                _buttonsPanel.Children.Add(button);
            }
            System.Diagnostics.Debug.Write(_buttonsPanel.Children.Count);

            _inputTextBox.Focus(FocusState.Programmatic);

            ResizeLayoutRoot();

            // Show dialog
            await this.GoToVisualStateAsync(_layoutRoot, PopupStatesGroupName, OpenPopupStateName);

            // Wait for button click
            var result = await _dismissTaskSource.Task;

            // Hide dialog
            if (this.AwaitsCloseTransition)
            {
                await this.CloseAsync();
            }
            else
            {
#pragma warning disable 4014
                this.CloseAsync();
#pragma warning restore 4014
            }

            Window.Current.Content.KeyUp -= OnGlobalKeyUp;
            return result;
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
        /// <summary>
        /// 关闭对话框
        /// </summary>
        /// <returns></returns>
        private async Task CloseAsync()
        {
            await this.GoToVisualStateAsync(_layoutRoot, PopupStatesGroupName, ClosedPopupStateName);
            _dialogPopup.IsOpen = false;
            _buttonsPanel.Children.Clear();

            foreach (var button in _buttons)
            {
                button.Click -= OnButtonClick;
                button.KeyUp -= OnGlobalKeyUp;
            }

            _buttons.Clear();

            _shown = false;
        }
        /// <summary>
        /// 当点击按钮时启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            var clickedButton = (BaseButton)sender;
            _dismissTaskSource.TrySetResult((string)clickedButton.Content);
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

        private void OnInputTextBoxKeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                FocusOnButton(AcceptButton);
                e.Handled = true;
                return;
            }

            if (e.Key == VirtualKey.Escape)
            {
                FocusOnButton(CancelButton);
                e.Handled = true;
                return;
            }
        }
        /// <summary>
        /// 撤销对话框组件
        /// </summary>
        private void DismissDialog()
        {
            if (CancelButton != null)
            {
                _dismissTaskSource.TrySetResult(CancelButton);
            }

            if (_buttons.Count > 0)
            {
                var button = (WYBtnColors)_buttons[0];
                button.Focus(FocusState.Programmatic);
            }
        }
    }
}
