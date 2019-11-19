using System.Windows;
using System.Windows.Controls;

namespace CompanyMVVM
{
    public interface IWindowService
    {
        void ShowWindow<T>(object DataContext) where T : Window, new();
    }
}