/********************************************************************************
** 作者： androllen
** 日期： 16/5/9 19:22:40
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DemoControl.Model
{
    public class NavLink: INotifyPropertyChanged
    {
        private string label;
        public string Label
        {
            get { return label; }
            set { OnPropertyChanged("Label"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
