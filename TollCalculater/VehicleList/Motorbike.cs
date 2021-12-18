using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public class Motorbike : CVehicle
    {
        public string GetVehicleType() => nameof(Motorbike); public bool TollFree() => false;
    }
}
