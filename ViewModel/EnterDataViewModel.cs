using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class EnterDataViewModel : ViewModelBase, ICommand, INotifyPropertyChanged
    {
        private Company company = new Company();
        public Command AddSaveCommand { get; set; }
        public int IdTextBox { get; set; }
        public String CompanyNameTextBox { get; set; }
        public bool IsMainCompanyCheckBox { get; set; }
        public IList<Car> Cars { get; set; }
        public CompanyAddress Address { get; set; }


        public EnterDataViewModel()
        {         
            this.AddSaveCommand = new Command(Execute, CanExecute);
        }




        #region Command
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
        #endregion
    }
}
