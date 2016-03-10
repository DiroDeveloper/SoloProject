using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{
  public class WindowViewModel : BaseViewModel
    {
        private string _page;

        public string page
        {
            get { return _page; }
            set { 
                _page = value;
                OnPropertyChanged("page");
            }
        }
                     
      public WindowViewModel()
        {
            page = "Page1.xaml";
        }
    }
}
