using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApplication1.ViewModels
{
   public class PageOneViewModel : BaseViewModel
    {
      
        private ICommand _navigateToLoginPageCommand;
        public ICommand navigateToLoginPageCommand
        {
            get
            {
                if (_navigateToLoginPageCommand == null)
                {
                    _navigateToLoginPageCommand = new Command(navigateToLoginPage, canNavigateToLoginPage);
                }
                return _navigateToLoginPageCommand;
            }
            set { _navigateToLoginPageCommand = value; }
        }

        private bool canNavigateToLoginPage()
        {
            return true;
        }

        private void navigateToLoginPage()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "LoginPage.xaml";
        }
    }
}
