
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public interface CVehicle
    {
        string GetVehicleType();
        bool TollFree();
    }
}
