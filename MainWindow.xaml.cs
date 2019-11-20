﻿using System;
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
      
        public MainWindow()
        {
            
            InitializeComponent();
            this.DataContext = new CompanyViewModel();
   
        }

        private void CompanyListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {        
            CompanyViewModel vm = this.DataContext as CompanyViewModel;
            vm.DoubleClickCommand.Execute(DataContext);
           
        }
    }
    
}
