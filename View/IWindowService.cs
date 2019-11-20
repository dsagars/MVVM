using System.Windows;
using System.Windows.Controls;

namespace CompanyMVVM
{
    public interface IWindowService
    {
        void ShowWindow<T>(object viewModel) where T : Window, new();
    }
}