using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompanyMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable
    {
        private Company company;
        public MainWindow()
        {
            var viewModel = new CompanyViewModel();            
            EnterData enterData = new EnterData();       
            InitializeComponent();
            enterData.DataContext = this.DataContext;
            DataContext = viewModel;

        }

        private void CompanyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {        
            CompanyViewModel vm = this.DataContext as CompanyViewModel;
            vm.DoubleClickCommand.Execute(this.DataContext);
            //vm.CompanyAddedEvent += ItemAddedEventHandler;
        }

        //public void ItemAddedEventHandler(object sender, CompanyAddedEventHandler e)
        //{
        //    (this.DataContext as CompanyViewModel).Companies.Add(e.newCompany);
        //    (this.DataContext as CompanyViewModel).Companies.CollectionChanged += OnContentChanged;
        //}
    }
    
}
