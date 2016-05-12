/********************************************************************************
** 作者： androllen
** 日期： 16/5/12 14:57:21
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using DemoControl.Model;

namespace DemoControl.ViewModels
{
    public class WYGridViewModel : BaseViewModel 
    {
        private readonly INotifyFrameChanged _frame;
        public WYGridViewModel(INotifyFrameChanged navigate) : base(navigate)
        {
            _frame = navigate;

        }

        private BindableCollection<string> listItems;
        public BindableCollection<string> ListItems => listItems ?? (listItems = GenerateSampleListData());

        private BindableCollection<string> GenerateSampleListData()
        {
            var list = new BindableCollection<string>();

            for (int i = 1; i < 2000; i++)
            {
                list.Add($"Item {i}");
            }

            return list;
        }

    }
}
