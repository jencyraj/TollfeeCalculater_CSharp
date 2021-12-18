using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public class Foreign : CVehicle
    {
        public string GetVehicleType() => nameof(Foreign); public bool TollFree() => false;
     }
}
