using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CompanyMVVM
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>(object DataContext) where T : Window, new()
        {
            T view = new T();
            view.DataContext = DataContext;
            view.Show();

        }
    }

}
