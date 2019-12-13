using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.Specialized;

namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class CompanyViewModel : ViewModelBase
    {

        #region Properties         
        private ObservableCollection<Company> _companies;
        private Company _selectedItemOnControl;       
        private Company viewModelCompany;
        private IList<Car> _cars;

        //public ObservableCollection<Company> Companies
        //{
        //    get { return _companies; }
        //    set 
        //    {
        //        if (_companies != value)
        //            _companies = value;             
        //    }
        //}
      

        public Company ViewModelCompany
        {
            get { return viewModelCompany; }
            set
            {
                if (viewModelCompany != value)
                {
                    viewModelCompany = value;
                    OnPropertyChanged("ViewModelCompany"); 
                }

            }
        }
        public Company SelectedItemOnControl
        {
            get { return _selectedItemOnControl; }
            set
            {
                if(_selectedItemOnControl != value)
                {
                    _selectedItemOnControl = value;
                    OnPropertyChanged("SelectedItemOnControl");
                }
            }
                  
        }
        public IList<Car> Cars
        {
            get { return _cars; }
            set { SetField(ref _cars, value, "Cars"); }
        }
       
        #endregion

        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

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

            Cars = new ObservableCollection<Car>(cars.AsEnumerable<Car>());

            Companies.Add(new Company(1, " GmbH", false, new CompanyAddress("Frankenstraße", 12), Cars));
            Companies.Add(new Company(2, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), Cars));

            ViewModelCompany = new Company();
            AddCommand = new Command(ExecuteAdd, CanExecuteAdd);
            DoubleClickCommand = new Command(ExecuteDoubleClick, CanDoubleClick);
            Companies.CollectionChanged += OnCollectionChanged;
        }

        public CompanyViewModel(Company company)
        {
            Companies = new ObservableCollection<Company>();
            IList<Car> cars = new List<Car>();
            cars.Add(new Car("Audi A1", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("BMW", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("Opel", "red", 4, 4, new DateTime(2026, 02, 12)));

            Cars = new ObservableCollection<Car>(cars.AsEnumerable<Car>());

            Companies.Add(new Company(1, " GmbH", false, new CompanyAddress("Frankenstraße", 12), Cars));
            Companies.Add(new Company(2, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), Cars));

            
            SelectedItemOnControl = company;
            
            SaveCommand = new Command(SaveExecute, CanExecuteSaveCommand);
            
        }
        public event PropertyChangedEventHandler CompanyPropertyChanged;
        protected void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = CompanyPropertyChanged;
            if (handler != null)
                handler(this, e);
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
        private Command saveCommand;
        public ICommand SaveCommand { get; }
        

        private bool CanExecuteSaveCommand(object parameter)
        {
            return true;
        }
        
        private void SaveExecute(object parameter)
        {
            ViewModelCompany = new Company();            
            SelectedItemOnControl.PropertyChanged += CompanyPropertyChanged;
            //Companies.Remove(SelectedItemOnControl);
            CompaniesOutput(Companies, ViewModelCompany);
            Companies.CollectionChanged += OnCollectionChanged;

        }

        #endregion


        #region PropertyChangedEvents
        public event EventHandler<CompanyAddedEventHandler> CompanyAddedEvent;
        protected void RaiseNewCompanyEvent(Company company)
        {
            var companyAddedEventArgs = new CompanyAddedEventHandler { newCompany = company };
            var handler = CompanyAddedEvent;
            if (handler != null)
            {
                handler(this, companyAddedEventArgs);
            }
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Company newItem in e.NewItems)
                {
                    //Companies.Add(newItem);

                    //Add listener for each item on PropertyChanged event
                    if (e.Action == NotifyCollectionChangedAction.Add)
                        newItem.PropertyChanged += this.CompanyPropertyChanged;
                    else if (e.Action == NotifyCollectionChangedAction.Remove)
                        newItem.PropertyChanged -= this.CompanyPropertyChanged;
                }
            }
        }
        #endregion  




        private ObservableCollection<Company> CompaniesOutput(ObservableCollection<Company> companies, Company company)
        {
            //if(SelectedItemOnControl.Equals(company) == true)
            //{
                //Companies.Remove(SelectedItemOnControl);
                ViewModelCompany = new Company(company.Id, company.CompanyName, company.IsMainCompany, company.Address, company.Cars); 
           // }
            //Companies.Add(ViewModelCompany);
           foreach(Company company1 in Companies)
            {
                MessageBox.Show(company1.CompanyName);
            }
            return Companies;
            
        }
    }
}

    
