using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyMVVM
{
    public class CompanyData
    {
       public static ObservableCollection<Company> mainWindowCompanyData { get; set; }
        public CompanyData()
        {


            //company1 = new CompanyData(1, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), cars);

            GetCompanies();
           
        }
        public ObservableCollection<Company> GetCompanies()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Audi A1", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("BMW", "red", 4, 4, new DateTime(2026, 02, 12)));
            cars.Add(new Car("Opel", "red", 4, 4, new DateTime(2026, 02, 12)));
            mainWindowCompanyData = new ObservableCollection<Company>();
            mainWindowCompanyData.Add(new Company(1, " GmbH", false, new CompanyAddress("Frankenstraße", 12), cars));
            mainWindowCompanyData.Add(new Company(2, "Hanseaticsoft GmbH", true, new CompanyAddress("Frankenstraße", 12), cars));
            return mainWindowCompanyData;
        }
    }
    
}
