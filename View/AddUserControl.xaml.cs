using System;
using System.Collections;
using System.Collections.Generic;
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
using PropertyChanged;
namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public partial class AddUserControl : UserControl
    {
        #region Properties
        public int Id
        {
            get { return (int)GetValue(IdProperty);}
            set { SetValue(IdProperty, value); }
        }
        public string CompanyName
        {
            get { return (string)GetValue(CompanyNameProperty); }
            set { SetValue(CompanyNameProperty, value); }
        }
        public bool IsMainCompany
        {
            get { return (bool)GetValue(IsMainCompanyProperty); }
            set { SetValue(IsMainCompanyProperty, value); }
        }
        public IList<Car> Cars
        {
            get { return (IList<Car>)GetValue(CarsProperty); }
            set { SetValue(CarsProperty, value); }
        }
        public CompanyAddress Address
        {
            get { return (CompanyAddress)GetValue(AddressProperty); }
            set { SetValue(AddressProperty, value); }
        }
        public Command AddSaveCommand
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(AddUserControl), new UIPropertyMetadata());

        public static readonly DependencyProperty CompanyNameProperty =
            DependencyProperty.Register("CompanyName", typeof(string), typeof(AddUserControl), new UIPropertyMetadata());

        public static readonly DependencyProperty IsMainCompanyProperty =
            DependencyProperty.Register("IsMainCompany", typeof(IList), typeof(AddUserControl), new UIPropertyMetadata());

        public static readonly DependencyProperty CarsProperty =
            DependencyProperty.Register("Cars", typeof(IList<Car>), typeof(AddUserControl), new UIPropertyMetadata());

        public static readonly DependencyProperty AddressProperty =
            DependencyProperty.Register("Address", typeof(CompanyAddress), typeof(AddUserControl), new UIPropertyMetadata());

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("AddSaveCommand", typeof(Command), typeof(AddUserControl), new UIPropertyMetadata(null));

        #endregion


        public AddUserControl()
        {
            InitializeComponent();
        }


    }
}
