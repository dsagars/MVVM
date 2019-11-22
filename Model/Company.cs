using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace CompanyMVVM
{
    //[AddINotifyPropertyChangedInterface]
    public class Company : ViewModelBase
    {
       
        public  int Id { get; set; }
        
        public string CompanyName { get; set; }
        

        public bool IsMainCompany { get; set; }

        public CompanyAddress Address { get; set; }

        public IList<Car> Cars { get; set; }

        public Company(int id, string name, bool isMainCompany, CompanyAddress address, IList<Car> cars)
        {
            this.Id = id;
            this.CompanyName = name;
            this.IsMainCompany = isMainCompany;
            this.Address = address;
            this.Cars = cars;
        }
        public Company()
        {

        }
    }
}
