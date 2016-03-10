using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfApplication1.ViewModels
{
   public class PageTwoViewModel : BaseViewModel
    {

        private ICommand _navigateToProfilePageCommand;
        public ICommand navigateToProfilePageCommand
        {
            get
            {
                if (_navigateToProfilePageCommand == null)
                {
                    _navigateToProfilePageCommand = new Command(navigateToProfilePage, canNavigateToProfilePage);
                }
                return _navigateToProfilePageCommand;
            }
            set { _navigateToProfilePageCommand = value; }
        }

        private bool canNavigateToProfilePage()
        {
            return true;
        }

        private void navigateToProfilePage()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "ProfilePage.xaml";
        }



        private ICommand _navigateToEmployeePageCommand;
        public ICommand navigateToEmployeePageCommand
        {
            get
            {
                if (_navigateToEmployeePageCommand == null)
                {
                    _navigateToEmployeePageCommand = new Command(navigateToEmployeePage, canNavigateToEmployeePage);
                }
                return _navigateToEmployeePageCommand;
            }
            set { _navigateToEmployeePageCommand = value; }
        }

       

        private bool canNavigateToEmployeePage()
        {
            return true;
        }

        private void navigateToEmployeePage()
        {
            WindowViewModel windowViewModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowViewModel.page = "EmployeePage.xaml";
        }



    }
}
