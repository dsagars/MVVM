using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMVVM
{
    public class MainWindowViewModel
    {
        public RelayCommand<IClosable> CloseWindowCommand { get; private set; }
        public MainWindowViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<IClosable>(this.CloseWindow);
        }
        private void CloseWindow(IClosable window)
        {
            if(window != null)
            {
                window.Close();
            }
        }
    }

}
