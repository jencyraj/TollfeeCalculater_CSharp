using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculater.VehicleList;

namespace TollCalculater.Hourfee
{
    public interface ItollFreeVehicleType
    {
        bool IsTollfree(VehicleType vehicle_type);
    }
}
