using NUnit.Framework;
using TollCalculater.Hourfee;
using FluentAssertions;
using TollCalculater.VehicleList;
namespace TollCalculater.Tests.Helper_Calende_HourlyFee
{
    [TestFixture]
    public class TollFreeVehicleSwedenTests
    {
        [Test]
        [TestCase(VehicleType.Motorbike)]
        [TestCase(VehicleType.Tractor)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Military)]
        public void Istollfree_VehicleType(VehicleType vehicleType)
        {
            ItollFreeVehicleType itollFreeVehicleType = GetTollFreeVehicles();
            Vehicle vehicle = new Vehicle(vehicleType);
            itollFreeVehicleType.IsTollfree(vehicle.VehicleType).Should().BeTrue();

        }

        [Test]
        public void istollNotfree_Private()
        {
            ItollFreeVehicleType itollFreeVehicleType = GetTollFreeVehicles();
            Vehicle vehicle = new Vehicle(VehicleType.Car_private);
            itollFreeVehicleType.IsTollfree(vehicle.VehicleType).Should().BeFalse();

        }
        private static ItollFreeVehicleType GetTollFreeVehicles()
        {
            return new TollfreeVehilceType_Sweden();
        }
    }
}