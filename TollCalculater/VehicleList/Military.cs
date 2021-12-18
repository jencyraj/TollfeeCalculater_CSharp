using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public class Military : CVehicle
    {
        public string GetVehicleType() => nameof(Military); public bool TollFree() => false;
     }
}
