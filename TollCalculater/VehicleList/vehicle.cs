
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCalculater.VehicleList
{
    public class Vehicle
    {
        public VehicleType VehicleType { get; }

        public Vehicle(VehicleType vehicle_Type)
        {
            VehicleType = vehicle_Type;
        }
    }

    public enum VehicleType
    {
        Motorbike,
        Tractor,
        Emergency,
        Diplomat,
        Foreign,
        Military,
        Car_private
    }
}
