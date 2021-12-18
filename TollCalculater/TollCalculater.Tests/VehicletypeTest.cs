using NUnit.Framework;
using FluentAssertions;
using TollCalculater.VehicleList;

namespace TollCalculater.Test
{
    [TestFixture]
    public class VehicletypeTest
    {

        [Test]
        [TestCase(VehicleType.Motorbike)]
        [TestCase(VehicleType.Tractor)]
        [TestCase(VehicleType.Emergency)]
        [TestCase(VehicleType.Diplomat)]
        [TestCase(VehicleType.Foreign)]
        [TestCase(VehicleType.Military)]
        public void test_Vehicletype_ShouldTrue(VehicleType vehicleType)
        {
            Vehicle vehicle = new Vehicle(vehicleType);
            vehicle.VehicleType.Should().Be(vehicleType);

        }

        
    }
}