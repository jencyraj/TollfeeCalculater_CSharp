using NUnit.Framework;
using System;
using FluentAssertions;
using TollCalculater.Hourfee;


namespace TollCalculater.Tests.Helper_Calende_HourlyFee
{
    [TestFixture]
    public class TollFeeHourlyTests
    {
        [Test]
        public void test_IsNullTollfreeDays_exceptionThrows()
        {
            Action Hr_FeewithNullTollFreeDays = () => new HourFeeSweden(null, new TollfreeVehilceType_Sweden());
            Hr_FeewithNullTollFreeDays.Should().Throw<ArgumentNullException>().WithMessage("OOPS!! Value Cannot be Null");
            
            
        }

        [Test]
        public void test_IsNullTollfreeVehicle_ExceptionThrows()
        {
            Action Hr_FeewithNullTollFreeDays = () => new HourFeeSweden(new tollfreeSweden(), null);
            Hr_FeewithNullTollFreeDays.Should().Throw<ArgumentNullException>().WithMessage("OOPS!! Value Cannot be Null");
            ;
        }
    }
}