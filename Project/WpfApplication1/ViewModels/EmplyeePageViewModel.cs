using EntityClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.ViewModels
{
   public class EmplyeePageViewModel : BaseViewModel
    {
        public List<Employee> Employee { get; set; }
        public Employee CurrentEmployee { get; set; }


       private string _employeeName; 
       public string employeeName 
       {
           get { return _employeeName; }
           set { _employeeName = employeeName;
           OnPropertyChanged("employeeName");
           } 
       }


       private string _employeePassword;
       public string employeePassword
       {
           get { return _employeePassword; }
           set { _employeePassword = employeePassword;
           OnPropertyChanged("employeePassword");
           }
       }




       private ICommand _registerCommandButton;
       public ICommand registerCommandButton
       {
           get
           {
               if (_registerCommandButton == null)
               {

                   _registerCommandButton = new RelayCommand(
                   param => SaveEmployee(),
                   param => (CurrentEmployee != null));


                  
               }
               return _registerCommandButton;
           }
          
       }

       private void SaveEmployee()
       {
           var employee = new Employee();
           using 
               (var context = new ProjectEntities()) 
               { 
               context.Employees.Add(employee);
               context.SaveChanges(); 
           }
           
       }

      

      

    }

}
