using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;


namespace CompanyMVVM
{
    public class Command : ICommand
    {
        private  Action<object> executeAction;
        private  Func<object, bool> canExecuteAction;

        public Command(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.executeAction = executeMethod;
            this.canExecuteAction = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
            
        }
      
        
    }
}
