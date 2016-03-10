using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModels
{
   public class PageOptionViewModel
    {


        private ICommand _navigateToOptionPageCommand;
        public ICommand navigateToOptionPageCommand
        {
            get
            {
                if (_navigateToOptionPageCommand == null)
                {
                    _navigateToOptionPageCommand = new Command(navigateToOptionPage, canNavigateToOptionPage);
                }
                return _navigateToOptionPageCommand;
            }
            set { _navigateToOptionPageCommand = value; }
        }

        private bool canNavigateToOptionPage()
        {
            return true;
        }

        private void navigateToOptionPage()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "OptionPage.xaml";
        }
    }
}
