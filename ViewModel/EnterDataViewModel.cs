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
        #region Properties
        private int id;
        private string companyName;
        private bool isMainCompany;
        private CompanyAddress address;
        private IList<Car> cars;
        private ObservableCollection<Company> getCompanies;

        public int IdTextBox { get; set; }
      
        public string CompanyNameTextBox { get; set; }

        public bool IsMainCompanyCheckBox { get; set; }

        public CompanyAddress AddressTextBox { get; set; }
        public IList<Car> Cars { get; set; }
        public ObservableCollection<Company> GetCompanies { get; set; }
        public Company company { get; set; }
        public Company SaveCompany { get; set; }

        #endregion



        #region Constructor
        public EnterDataViewModel()
        {
            
        }
        public EnterDataViewModel(Company company)
        {
            CompanyViewModel model = new CompanyViewModel();
               this.GetCompanies = model.Companies;
            
                //Company company1 = new Company();
                IdTextBox = company.Id;
                CompanyNameTextBox = company.CompanyName;
                IsMainCompanyCheckBox = company.IsMainCompany;
                Cars = company.Cars;
                AddressTextBox = company.Address;
                
        }
       
        //public EnterDataViewModel(ObservableCollection<Company> companies)
        //{
        //    //Company company = new Company();
        //    //company.Id = IdTextBox;
        //    //company.CompanyName = CompanyNameTextBox;
        //    //company.IsMainCompany = IsMainCompanyCheckBox;
        //    //company.Cars = Cars;
        //    //company.Address = AddressTextBox;
        //    //companies.Add(company);
        //    //GetCompanies = companies;
        //    companies = GetCompanies;
            
        //}
        #endregion



        #region SaveCommand

        public event EventHandler CanExecuteChanged
        {
            add
            {
                SaveCommand.CanExecuteChanged += value;
            }

            remove
            {
                SaveCommand.CanExecuteChanged -= value;
            }
        }
        public ICommand SaveCommand { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        private void CreateSaveCommand()
        {
            SaveCommand = new Command(Execute, CanExecute);
        }
        public void Execute(object parameter)
        {
            CompanyViewModel test = new CompanyViewModel();
            test.Companies = GetCompanies;
        }

        #endregion







    }
}
