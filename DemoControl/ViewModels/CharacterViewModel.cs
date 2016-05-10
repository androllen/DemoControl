/********************************************************************************
** 作者： androllen
** 日期： 16/5/10 12:01:50
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace DemoControl.ViewModels
{
    public class CharacterViewModel
    {
        public CharacterViewModel(string name, string image)
        {
            TBName = name;
            Image = image;
        }

        public string TBName
        {
            get;
            private set;
        }

        public string Image
        {
            get;
            private set;
        }
  
        public async void CarouselClick(CharacterViewModel character)
        {
            var dialog = new MessageDialog(String.Format("{0} selected.", character.TBName), "Character Selected");

            await dialog.ShowAsync();
        }
    }
}
