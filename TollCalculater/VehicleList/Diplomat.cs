using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
     public class Diplomat : CVehicle
    {
        public string GetVehicleType() => nameof(Diplomat); public bool TollFree() => false;
     }
}
