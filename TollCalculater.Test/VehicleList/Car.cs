using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public  class Car : CVehicle
    {
        public string GetVehicleType() => nameof(Car);

        public bool TollFree() => false;
    }
}
