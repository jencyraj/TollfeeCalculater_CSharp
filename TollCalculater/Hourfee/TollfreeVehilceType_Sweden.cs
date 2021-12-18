using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollCalculater.VehicleList;

namespace TollCalculater.Hourfee
{
    public class TollfreeVehilceType_Sweden : ItollFreeVehicleType
    {
        private enum TollFreeVehicles
        {
            Motorbike = 0,
            Tractor = 1,
            Emergency = 2,
            Diplomat = 3,
            Foreign = 4,
            Military = 5
        }
        public bool IsTollfree(VehicleType vehicle_type)
        {
            return Enum.IsDefined(typeof(TollFreeVehicles), vehicle_type.ToString());
        }
            
    }
}
