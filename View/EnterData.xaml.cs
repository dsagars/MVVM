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
using System.Windows.Shapes;

namespace CompanyMVVM
{
    /// <summary>
    /// Interaction logic for EnterData.xaml
    /// </summary>
    public partial class EnterData : Window
    {
        private Company _company;

        public EnterData()
        {
            InitializeComponent();

            DataContext = new CompanyViewModel();

        }
        public EnterData(Company company)
        {           
            InitializeComponent();
            this._company = company;
            DataContext = new CompanyViewModel(_company);         
        }    
    }
}
