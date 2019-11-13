using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
namespace CompanyMVVM
{
    [AddINotifyPropertyChangedInterface]
    public class Car : ViewModelBase
    {
        public string CarName { get; set; }
        public string Color { get; set; }
        public int? Doors { get; set; }
        public int Tires { get; set; }
        public DateTime MFD { get; set; }


        public Car(string name, string color, int doors, int tires, DateTime mfd)
        {
            this.CarName = name;
            this.Color = color;
            this.Doors = doors;
            this.Tires = tires;
            this.MFD = mfd;
        }
        public string GetCar { get { return CarName + " " + Color + " " + Doors + " " + Tires + " " + MFD; } }

    }
}
