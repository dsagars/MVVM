using GalaSoft.MvvmLight;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class CompanyViewModel : ViewModelBase
    {
        #region Public Properties  
        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public Company SelectedItemOnTheControl { get; set; }
        #endregion


        #region Commands
        public ICommand CloseCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DoubleClickCommand { get; private set; }
        #endregion
        

        #region Constructor
        public CompanyViewModel()
        {

            Companies = new ObservableCollection<Company>();
            IList<Car> cars = new List<Car>();
            cars.Add(new Car("Audi A1", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("BMW", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("Opel", "red", 4, 4, new DateTime(2026, 02, 12)));
            Companies = new ObservableCollection<Company>();
            Cars = new ObservableCollection<Car>(cars.AsEnumerable<Car>());

            Companies.Add(new Company(1, " GmbH", false, new CompanyAddress("Frankenstraße", 12), Cars));
            Companies.Add(new Company(2, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), Cars));

            AddCommand = new Command(ExecuteAdd, CanExecuteAdd);
            DoubleClickCommand = new Command(ExecuteDoubleClick, CanDoubleClick);
            
        }
        #endregion


        #region CommandImplementation
        public event EventHandler CanExecuteChanged
        {
            add
            {
                AddCommand.CanExecuteChanged += value;
            }

            remove
            {
                AddCommand.CanExecuteChanged -= value;
            }
        }

        private bool CanExecuteAdd(object parameter)
        {
            return true;
        }

        private void ExecuteAdd(object parameter)
        {
            EnterData enterData = new EnterData();
            enterData.Show();
        }
        private bool CanDoubleClick(object parameter)
        {
            return true;
        }
        private void ExecuteDoubleClick(object parameter)
        {
            if(SelectedItemOnTheControl != null)
            {
                Company company = SelectedItemOnTheControl;
                EnterData enterData = new EnterData(company);
                enterData.Show();
            }
        }


        Command _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(p => this.ExecuteSave((object)p),
                     p => this.CanSave(p));
                }
                return _saveCommand;
            }
        }
        private bool CanSave(object parameter)
        {
            return true;
        }
        private void ExecuteSave(object parameter)
        {
            
            EnterDataViewModel model = new EnterDataViewModel(company, Companies);
            Company company = model.SaveCompany;
        }
        #endregion

    }
}
    
