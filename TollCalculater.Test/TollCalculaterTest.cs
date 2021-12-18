using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using TollCalculater.VehicleList;
namespace TollCalculater.Test
{
    [TestClass]
    public class TollCalculaterTest
    {
        [TestMethod]
        public void test_TollFreeVehicle()
        {
            var vehicle_type = new Emergency();
            var passes = new DateTime[0];
            var val_tollfee = TollCalculater.GetTollFee(vehicle_type, passes);

            Assert.IsTrue(val_tollfee == 0);
        }

        [TestMethod]
        public void GetTollFee_WhenOneTimePassedPrivateCarNotHolidayFrom600To629AM_Returns9()
        {
            var vehicle_type = new Car();
            var passes = new[]
            {
                DateTime.Parse("2018-07-10 06:00:00"),
                DateTime.Parse("2020-01-01 06:05:00"),
                DateTime.Parse("2020-01-01 06:29:59")

            };
            var tollFee = TollCalculater.GetTollFee(vehicle_type, passes);

            Assert.IsTrue(tollFee == 9);

        }

            [TestMethod]
        public void Test_NoTollSunday()
        {
            var vehicle_Type = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-01-01 07:34:00"),
                DateTime.Parse("2020-04-09 07:34:00"),
                DateTime.Parse("2020-04-10 07:34:00"),
                DateTime.Parse("2020-12-23 07:34:00"),
                DateTime.Parse("2020-12-24 08:33:00")

            };
            var tollFee = TollCalculater.GetTollFee(vehicle_Type, passes);

            Assert.IsTrue(tollFee == 0);


        }
        [TestMethod]
        public void Within60MinutesTest()
        {
            var vehicle = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-09-01 07:34:00"),
                DateTime.Parse("2020-09-01 08:33:00"),
                DateTime.Parse("2020-09-01 08:00:00")
            };

            var tollFee = TollCalculater.GetTollFee(vehicle, passes);

            Assert.IsTrue(tollFee == 18);
        }

        [TestMethod]
        public void Max60DayTest()
        {
            var vehicle = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-09-01 07:01:00"),
                DateTime.Parse("2020-09-01 08:02:00"),
                DateTime.Parse("2020-09-01 09:36:00"),
                DateTime.Parse("2020-09-01 10:37:00"),
                DateTime.Parse("2020-09-01 11:38:00"),
                DateTime.Parse("2020-09-01 15:38:00"),
                DateTime.Parse("2020-09-01 16:39:00")
            };

            var tollFee = TollCalculater.GetTollFee(vehicle, passes);

            Assert.IsTrue(tollFee == 60);
        }

        [TestMethod]
        public void NoTollJulyTest()
        {
            var vehicle = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-07-01 07:01:00"),
                DateTime.Parse("2020-07-12 08:02:00"),
                DateTime.Parse("2020-07-14 09:36:00"),
                DateTime.Parse("2020-07-18 10:37:00"),
                DateTime.Parse("2020-07-25 11:38:00")
            };

            var tollFee = TollCalculater.GetTollFee(vehicle, passes);

            Assert.IsTrue(tollFee == 0);
        }

        [TestMethod]
        public void NoTollSaturdaySundayTest()
        {
            var vehicle = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-04-04 07:01:00"),
                DateTime.Parse("2020-04-05 08:02:00"),
            };

            var tollFee = TollCalculater.GetTollFee(vehicle, passes);

            Assert.IsTrue(tollFee == 0);
        }

        [TestMethod]
        public void GetTollFeeTest()
        {
            var vehicle = new Car();

            var passes = new[]
            {
                DateTime.Parse("2020-04-08 07:34:00"),
                DateTime.Parse("2020-04-09 07:34:00"),
                DateTime.Parse("2020-04-10 07:34:00"),
                DateTime.Parse("2020-09-01 07:34:00"),
                DateTime.Parse("2020-09-01 08:33:00"),
                DateTime.Parse("2020-09-01 08:00:00"),
                DateTime.Parse("2020-09-01 09:00:00"),
                DateTime.Parse("2020-09-01 11:00:00"),
                DateTime.Parse("2020-09-02 09:00:00"),
                DateTime.Parse("2020-09-02 11:00:00")

            };

            var tollFee = TollCalculater.GetTollFee(vehicle, passes);
            
            Assert.IsTrue(tollFee == 18);
        }
    }
}

