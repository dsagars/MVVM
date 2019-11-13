using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class EnterDataViewModel : ViewModelBase
    {
        public int IdTextBox { get; set; }
        public string CompanyNameTextBox { get; set; }

        public bool IsMainCompanyCheckBox { get; set; }

        public CompanyAddress AddressTextBox { get; set; }
        public IList<Car> Cars { get; set; }
        public ObservableCollection<Company> GetCompanies { get; set; }
        public Company company { get; set; }

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
        public EnterDataViewModel(Company company, ObservableCollection<Company> newCompanyCollection)
        {
            SaveCompany.CompanyName = CompanyNameTextBox;
            SaveCompany.Id = IdTextBox;
            SaveCompany.IsMainCompany = IsMainCompanyCheckBox;
            SaveCompany.Address = AddressTextBox;
            SaveCompany.Cars = Cars;
            newCompanyCollection.Add(SaveCompany);
        }

        private bool CanSave(object parameter)
        {
            return true;
        }
        private void ExecuteSave(object parameter)
        {
            Company company = new Company();
            company.Id = IdTextBox;
            company.CompanyName = CompanyNameTextBox;
            company.IsMainCompany = IsMainCompanyCheckBox;
            company.Address = AddressTextBox;
            company.Cars = Cars;
            GetCompanies.Add(company);
            
        }

        public Company SaveCompany { get; set; }
        

        
    }
}
