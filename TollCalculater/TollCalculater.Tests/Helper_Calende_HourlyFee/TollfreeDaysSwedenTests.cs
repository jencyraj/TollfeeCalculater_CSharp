using NUnit.Framework;
using FluentAssertions;
using TollCalculater.Hourfee;
using System;

namespace TollCalculater.Tests.Helper_Calende_HourlyFee
{
    [TestFixture]
    public class TollfreeDaysSwedenTests
    {
        [Test]
        public void Test_TollfreeInNewYear()
        {
            DateTime datetime_newYr = new DateTime(2021, 1, 1);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_newYr).Should().BeTrue();

        }

        [Test]
        public void Test_Tollfreemay_First()
        {
            DateTime datetime_may_First = new DateTime(2021, 5, 1);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_may_First).Should().BeTrue();
        }
        [Test]
        public void Test_TollFree_Epiphany()
        {
            DateTime datetime_Epiphany = new DateTime(2021, 1, 6);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Epiphany).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 4, 10)]
        [TestCase(2021, 4, 2)]
        public void Test_TollfreeGoodFriday(int year, int month, int day)
        {
            DateTime datetime_Goodfriday = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Goodfriday).Should().BeTrue();


        }
        [Test]
        [TestCase(2020, 4, 12)]
        [TestCase(2021, 4, 4)]
        public void Test_tollfree_Easter(int year, int month, int day)
        {
            DateTime datetime_Ëster = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Ëster).Should().BeTrue();

        }

        [Test]
        [TestCase(2020, 4, 13)]
        [TestCase(2021, 4, 5)]
        public void Test_tollfree_Easter_Monday(int year, int month, int day)
        {
            DateTime datetime_Ëster_Monday = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Ëster_Monday).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 06, 06)]
        [TestCase(2021, 06, 06)]
        public void Test_tollfree_SW_Nationalday(int year, int month, int day)
        {
            DateTime datetime_SW_Nationalday = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_SW_Nationalday).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 12, 24)]
        [TestCase(2021, 12, 24)]
        public void Test_tollfree_XMasEve(int year, int month, int day)
        {
            DateTime datetime_XMasEve = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_XMasEve).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 12, 25)]
        [TestCase(2021, 12, 25)]
        public void Test_tollfree_XMasDay(int year, int month, int day)
        {
            DateTime datetime_XMasDay = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_XMasDay).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 8, 9)]
        [TestCase(2021, 8, 8)]
        public void Test_tollfree_Sunday(int year, int month, int day)
        {
            DateTime datetime_Sunday = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Sunday).Should().BeTrue();

        }
        [Test]
        [TestCase(2020, 8, 8)]
        [TestCase(2021, 8, 7)]
        public void Test_tollfree_Saturday(int year, int month, int day)
        {
            DateTime datetime_Saturday = new DateTime(year, month, day);
            tollfreeSweden tollfreedays_Sweden = new tollfreeSweden();
            tollfreedays_Sweden.Istollfree(datetime_Saturday).Should().BeTrue();

        }
    }
}