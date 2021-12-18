using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public class Emergency : CVehicle
    {
        public string GetVehicleType() => nameof(Emergency); public bool TollFree() => false;
     }
}
