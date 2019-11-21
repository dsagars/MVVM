using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMVVM
{
    public class CompanyAddedEventHandler : EventArgs
    {
        public Company newCompany { get; set; }
    }
}
