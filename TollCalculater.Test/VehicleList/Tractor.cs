using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
   public class Tractor : CVehicle
    {
        public string GetVehicleType() => nameof(Tractor);

        public bool TollFree() => false;
    }
}
