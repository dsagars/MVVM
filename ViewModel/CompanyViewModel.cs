using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class CompanyViewModel : ViewModelBase
    {

        #region Properties  
        private ObservableCollection<Company> _companies;
        private Company _selectedItemOnControl;
        private int _id;
        private string _companyName;
        private bool _ismainCompany;
        private CompanyAddress _address;
        private IList<Car> _cars;
        private string _carName;
        private string _color;
        private int? _doors;
        private int _tires;
        private DateTime _mfd;
        private readonly Company _company;

        

        public ObservableCollection<Company> Companies
        {
            get { return _companies; }
            set { SetField(ref _companies, value, "Companies"); } 
        }
        
        public Company SelectedItemOnControl
        {
            get { return _selectedItemOnControl; }
            set { SetField(ref _selectedItemOnControl, value, "SelectedItemOnControl"); }
        }

        

        public  int Id
        {
            get { return _id; }
            set
            {
                SetField(ref _id, value, "Id");
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { SetField(ref _companyName, value, "CompanyName"); }
        }

        public bool IsMainCompany
        {
            get { return _ismainCompany; }
            set { SetField(ref _ismainCompany, value, "IsMainCompany"); }
        }

        public CompanyAddress Address
        {
            get { return _address; }
            set { SetField(ref _address, value, "Address"); }
        }
        public IList<Car> Cars
        {
            get { return _cars; }
            set { SetField(ref _cars, value, "Cars"); }
        }
        public string CarName
        {
            get { return _carName; }
            set { SetField(ref _carName, value, "CarName"); }
        }
        public string Color
        {
            get { return _color; }
            set { SetField(ref _color, value, "Color"); }
        }
        public int? Doors
        {
            get { return _doors; }
            set { SetField(ref _doors, value, "Doors"); }
        }
        public int Tires
        {
            get { return _tires; }
            set { SetField(ref _tires, value, "Tires"); }
        }
        public DateTime MFD
        {
            get { return _mfd; }
            set { SetField(ref _mfd, value, "MFD"); }
        }
        #endregion

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region Commands
        public ICommand CloseCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DoubleClickCommand { get; private set; }
      
        #endregion




        
        #region Constructor
        public CompanyViewModel()
        {

            this.Companies = new ObservableCollection<Company>();
            IList<Car> cars = new List<Car>();
            cars.Add(new Car("Audi A1", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("BMW", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("Opel", "red", 4, 4, new DateTime(2026, 02, 12)));
            
            Cars = new ObservableCollection<Car>(cars.AsEnumerable<Car>());

            this.Companies.Add(new Company(1, " GmbH", false, new CompanyAddress("Frankenstraße", 12), Cars));
            this.Companies.Add(new Company(2, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), Cars));

            
            AddCommand = new Command(ExecuteAdd, CanExecuteAdd);
            DoubleClickCommand = new Command(ExecuteDoubleClick, CanDoubleClick);
            


        }
        public Company dummyCompany { get; set; }
        public CompanyViewModel(Company company)
        {

            this.Companies = new ObservableCollection<Company>();    
            dummyCompany = company;
            this.Companies.Add(dummyCompany);
            SaveCommand = new Command(SaveExecute, CanExecuteSaveCommand);
            MessageBox.Show(Companies.Count.ToString());
           
        }


        #endregion



        /// <summary>
        /// Add Execution
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 

        #region AddCommand
        public event EventHandler CanExecuteAddChanged
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
            WindowService ws = new WindowService();
            CompanyViewModel dataViewModel = new CompanyViewModel();
            ws.ShowWindow<EnterData>(dataViewModel);
           
        }
        #endregion




        /// <summary>
        /// Double Click Execution
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// 
        #region Double Click  
        private bool CanDoubleClick(object parameter)
        {
            return true;
        }
        private void ExecuteDoubleClick(object parameter)
        {
            if (SelectedItemOnControl != null)
            {     
                WindowService ws = new WindowService();
                CompanyViewModel dataViewModel = new CompanyViewModel(SelectedItemOnControl);
                ws.ShowWindow<EnterData>(dataViewModel);
            }
            
        }


        #endregion


        #region SaveCommand
        public event EventHandler CanExecuteChanged;
        
        public ICommand SaveCommand { get; set; }
       
        private bool CanExecuteSaveCommand(object parameter)
        {
            return true;
        } 
        private void SaveExecute(object parameter)
        {

            Company newDummyCompany = new Company();
            newDummyCompany.Id = dummyCompany.Id;
            newDummyCompany.CompanyName = dummyCompany.CompanyName;
            newDummyCompany.IsMainCompany = dummyCompany.IsMainCompany;
            newDummyCompany.Address = dummyCompany.Address;
            newDummyCompany.Cars = dummyCompany.Cars;
            Companies.Add(newDummyCompany);
            MessageBox.Show(newDummyCompany.CompanyName.ToString());
            RaiseNewCompanyEvent(newDummyCompany);


        }

        #endregion
        public event EventHandler<CompanyAddedEventHandler> CompanyAddedEvent;
        protected void RaiseNewCompanyEvent(Company company)
        {
            var companyAddedEventArgs = new CompanyAddedEventHandler { newCompany = company };
            var handler = CompanyAddedEvent;
            if(handler != null)
            {
                handler(this, companyAddedEventArgs);
            }
        }
    }
}

    
