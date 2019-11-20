using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class CompanyAddress : ViewModelBase
    {
        
        public string Street { get; set; }


        public int Number { get; set; }

        public CompanyAddress(string s, int n)
        {
            this.Street = s;
            this.Number = n;
        }

        public string Display { get { return Street + "" + Number; } }
    }
}
