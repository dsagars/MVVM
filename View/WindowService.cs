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
        public void ShowWindow<T>(T viewmodel)
        {
            var window = Application.Current
                                    .Windows
                                    .OfType<EnterData>()
                                    .FirstOrDefault(x => x.Content?.GetType() == viewmodel.GetType());
            if(window == null)
            {
                window = new EnterData { Content = viewmodel };
                window.Title = "Enter Data";
                window.Owner = Application.Current.Windows[0];
                window.Show();
            }
            else
            {
                window.Activate();
            }
        }
    }
}
