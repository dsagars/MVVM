using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMVVM
{
    public class Company : ViewModelBase
    {
       
        public int Id { get; set; }
        
        public string CompanyName { get; set; }
        

        public bool IsMainCompany { get; set; }

        public CompanyAddress Address { get; set; }

        public List<Car> Cars { get; set; }

        public Company(int id, string name, bool isMainCompany, CompanyAddress address, List<Car> cars)
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
