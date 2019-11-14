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
    public class CompanyViewModel : ViewModelBase,INotifyPropertyChanged
    {
        #region Public Properties  
        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public Company SelectedItemOnTheControl { get; set; }
        #endregion
        //
        public int IdTextBox { get; set; }

        public string CompanyNameTextBox { get; set; }

        public bool IsMainCompanyCheckBox { get; set; }

        public CompanyAddress AddressTextBox { get; set; }
        public IList<Car> CarsList { get; set; }
        //
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
        public CompanyViewModel(Company company)
        {
            IdTextBox = company.Id;
            CompanyNameTextBox = company.CompanyName;
            IsMainCompanyCheckBox = company.IsMainCompany;
            AddressTextBox = company.Address;
        }
            
        #endregion




        /// <summary>
        /// Add Execution
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 

         #region AddCommand
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
        #endregion


        /// <summary>
        /// Double Click Execution
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        #region Double Click  
        private bool CanDoubleClick(object parameter)
        {
            return true;
        }
        private void ExecuteDoubleClick(object parameter)
        {
            if(SelectedItemOnTheControl != null)
            {
                
               // Company company = SelectedItemOnTheControl;
                EnterData enterData = new EnterData(SelectedItemOnTheControl);  
                enterData.Show();
            }
        }
        #endregion
    }
}
    
