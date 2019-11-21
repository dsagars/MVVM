//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;
//using PropertyChanged;
//namespace CompanyMVVM
//{
//    [AddINotifyPropertyChangedInterface]
//    public class EnterDataViewModel : ViewModelBase, ICommand, INotifyPropertyChanged
//    {
//        #region Private Properties
       
//        #endregion
//        #region Properties     
//        //public int IdTextBox
//        //{
//        //    get { return idTextBox; }
//        //    set
//        //    {
//        //        if(idTextBox != value)
//        //        {
//        //            idTextBox = value;
//        //            OnPropertyChanged("IdTextBox");
//        //        }
//        //    }
//        //}
//        //public string CompanyNameTextBox { get; set; }

//        //public bool IsMainCompanyCheckBox { get; set; }

//        //public CompanyAddress AddressTextBox { get; set; }
//        //public IList<Car> Cars { get; set; }
//        public ObservableCollection<Company> GetCompanies { get; set; }
//        public Company company { get; set; }
//        public Company SaveCompany { get; set; }

//        #endregion



//        #region Constructor
//        //public EnterDataViewModel(CompanyViewModel companyViewModel)
//        //{
//        //    Company company = new Company();
//        //    company.Id = int.Parse(companyViewModel.IdTextBox);
//        //    company.CompanyName = companyViewModel.CompanyNameTextBox;
//        //    company.IsMainCompany = companyViewModel.IsMainCompanyCheckBox;
//        //    company.Cars = companyViewModel.Cars;
//        //    company.Address = companyViewModel.AddressTextBox;
//        //    companyViewModel.Companies.Add(company);
            
//        //}
//        //public EnterDataViewModel(Company company , CompanyViewModel companyViewModel)
//        //{
//        //    //IdTextBox = company.Id;
//        //    company = new Company();
//        //    company.Id = IdTextBox;
//        //    CompanyNameTextBox = company.CompanyName;
//        //    IsMainCompanyCheckBox = company.IsMainCompany;
//        //    Cars = company.Cars;
//        //    AddressTextBox = company.Address;
//        //    GetCompanies = new ObservableCollection<Company>();

//        //    GetCompanies.Add(company);
//        //    companyViewModel.Companies = this.GetCompanies;
//        //    CreateSaveCommand(GetCompanies); 
//        //}
//        #endregion



//        #region SaveCommand

//        public event EventHandler CanExecuteChanged
//        {
//            add
//            {
//                SaveCommand.CanExecuteChanged += value;
//            }

//            remove
//            {
//                SaveCommand.CanExecuteChanged -= value;
//            }
//        }
//        public ICommand SaveCommand { get; set; }

//        public bool CanExecute(object parameter)
//        {
//            return true;
//        }
//        private void CreateSaveCommand(ObservableCollection<Company> companies)
//        {
            
//            SaveCommand = new Command(Execute, CanExecute);
//        }
//        public void Execute(object parameter)
//        {
            
//        }

//        #endregion







//    }
//}
