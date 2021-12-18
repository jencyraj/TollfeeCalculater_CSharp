using NUnit.Framework;
using FluentAssertions;
using TollCalculater.Hourfee;
using TollCalculater.VehicleList;
using System;

namespace TollCalculater.Test
{
    [TestFixture]
    public class TotalcalculaterTests
    {
        [Test]
        [TestCase(2021, 11, 2, 06, 00, 00)]
        [TestCase(2021, 11, 2, 06, 15, 00)]
        [TestCase(2021, 11, 2, 06, 29, 59)]
        public void Test_Tollfee_privatecar_weekday_6to629(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(9);
        }
        [Test]
        [TestCase(2021, 11, 2, 06, 30, 00)]
        [TestCase(2021, 11, 2, 06, 45, 00)]
        [TestCase(2021, 11, 2, 06, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_630to659(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(16);
        }

        [Test]
        [TestCase(2021, 11, 2, 07, 00, 00)]
        [TestCase(2021, 11, 2, 07, 45, 00)]
        [TestCase(2021, 11, 2, 07, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_7to759(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(22);
        }
        [Test]
        [TestCase(2021, 11, 2, 08, 00, 00)]
        [TestCase(2021, 11, 2, 08, 15, 00)]
        [TestCase(2021, 11, 2, 08, 29, 59)]
        public void Test_Tollfee_privatecar_weekday_8to829(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(16);
        }
        [Test]
        [TestCase(2021, 11, 2, 08, 30, 00)]
        [TestCase(2021, 11, 2, 12, 15, 00)]
        [TestCase(2021, 11, 2, 14, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_830to1459(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(9);
        }
        [Test]
        [TestCase(2021, 11, 2, 15, 00, 00)]
        [TestCase(2021, 11, 2, 15, 15, 00)]
        [TestCase(2021, 11, 2, 15, 29, 59)]
        public void Test_Tollfee_privatecar_weekday_15to1529(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(16);
        }
        [Test]
        [TestCase(2021, 11, 2, 15, 30, 00)]
        [TestCase(2021, 11, 2, 16, 35, 00)]
        [TestCase(2021, 11, 2, 16, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_1530to1659(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(22);
        }
        [Test]
        [TestCase(2021, 11, 2, 17, 00, 00)]
        [TestCase(2021, 11, 2, 17, 35, 00)]
        [TestCase(2021, 11, 2, 17, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_17to1759(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(16);
        }
        [Test]
        [TestCase(2021, 11, 2, 18, 00, 00)]
        [TestCase(2021, 11, 2, 18, 25, 00)]
        [TestCase(2021, 11, 2, 18, 29, 59)]
        public void Test_Tollfee_privatecar_weekday_18to1829(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(9);
        }
        [Test]
        [TestCase(2021, 11, 2, 18, 30, 00)]
        [TestCase(2021, 11, 2, 01, 35, 00)]
        [TestCase(2021, 11, 2, 05, 59, 59)]
        public void Test_Tollfee_privatecar_weekday_1830to0559(int year, int month, int day, int hour, int minute, int second)
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes = { new DateTime(year, month, day, hour, minute, second) };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(0);
        }

        [Test]
        public void Test_maxTollfeePerDay60()
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes =
            {
                new DateTime(2021,12,16,06,01,00),
                new DateTime(2021,12,16,07,02,00),
                new DateTime(2021,12,16,08,03,00),
                new DateTime(2021,12,16,09,04,00),
                new DateTime(2021,12,16,10,05,00),
                new DateTime(2021,12,16,11,06,00),
                new DateTime(2021,12,16,12,07,00)
               
            };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(60);

        }

        [Test]
        public void Test_tollfee_shouldbe_onceanHour()
        {
            TollCalculater tollCalculater = GetSwcalculater();
            DateTime[] datetime_passes =
            {
                new DateTime(2021,12,16,06,00,00),
                new DateTime(2021,12,16,06,54,00),
                new DateTime(2021,12,16,07,01,00),
                new DateTime(2021,12,16,07,06,00),
                new DateTime(2021,12,16,08,08,00)
                

            };
            int Tollfee_privatecar = tollCalculater.GetTollFee(new Vehicle(VehicleType.Car_private), datetime_passes);
            Tollfee_privatecar.Should().Be(47);

        }
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


        private static TollCalculater GetSwcalculater()
        {
            return new TollCalculater(new HourFeeSweden(new tollfreeSweden(), new TollfreeVehilceType_Sweden()));
        }
    }
}