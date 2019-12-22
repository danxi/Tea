using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tea;

namespace TeaTests
{
    [TestClass]
    public class GeoUtilsTest
    {
        private GeoPosition Dublin = new GeoPosition(53.339428, -6.257664);
        private GeoPosition Livepool = new GeoPosition(53.403090, -2.966878);

        [TestMethod]
        public void TestCalcDistanceInKm_DublinIsCloserToLivepoolThanToBeijing()
        {
            GeoPosition Beijing = new GeoPosition(39.895362, 116.357594);
                              
            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Livepool) < 
                GeoUtils.CalcDistanceInKm(Dublin, Beijing));
        }

        [TestMethod]
        public void TestCalcDistanceInKm_DublinIsCloserToLivepoolThanToNewYork()
        {
            GeoPosition NewYork = new GeoPosition(40.690902, -73.965987);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Livepool) <
                GeoUtils.CalcDistanceInKm(Dublin, NewYork));
        }

        [TestMethod]
        public void TestCalcDistanceInKm_DublinIsCloserToLivepoolThanToSydney()
        {
            GeoPosition Sydney = new GeoPosition(-33.854770, 151.092606);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Livepool) <
                GeoUtils.CalcDistanceInKm(Dublin, Sydney));
        }

        [TestMethod]
        public void TestCalcDistanceInKm_DublinIsCloserToLivepoolThanToStPaulo()
        {
            GeoPosition StPaulo = new GeoPosition(-23.564203, -46.630023);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Livepool) <
                GeoUtils.CalcDistanceInKm(Dublin, StPaulo));
        }

        [TestMethod]
        public void TestCalcDistanceInKm_DublinToSandyfordIsLessThan100KM()
        {
            GeoPosition Sandyford = new GeoPosition(53.278015, -6.203205);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Sandyford) < 100);
        }

        [TestMethod]
        public void TestCalcDistanceInKm_DublinToNorthPoleIslongerThan100KM()
        {
            GeoPosition NorthPole = new GeoPosition(90, 0);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, NorthPole) > 100);
        }


        [TestMethod]
        public void TestCalcDistanceInKm_DublinToNorthPoleIsLessThanEarthRadius()
        {
            GeoPosition NorthPole = new GeoPosition(90, 0);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, NorthPole) < GeoUtils.EARTH_RADIUS);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCalcDistanceInKm_DublinToNonExistPlace()
        {
            GeoPosition NonExistPlace = new GeoPosition(100, 30);

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, NonExistPlace) > 0);
        }

        [TestMethod]
        public void TestCalcDistanceInKm_Dublin30DegreeNorth()
        {
            GeoPosition place = new GeoPosition(Dublin.Latitude + 30, Dublin.Longitude);

            Assert.AreEqual(GeoUtils.CalcDistanceInKm(Dublin, place),
                GeoUtils.EARTH_RADIUS * Math.PI / 6, 0.0001);
        }

        [TestMethod]
        public void TestCalcDistanceInKm_Dublin30DegreeSouth()
        {
            GeoPosition place = new GeoPosition(Dublin.Latitude - 30, Dublin.Longitude);

            Assert.AreEqual(GeoUtils.CalcDistanceInKm(Dublin, place),
                GeoUtils.EARTH_RADIUS * Math.PI / 6, 0.0001);
        }

        [TestMethod]
        public void TestCalcDistanceInKm_Dublin60DegreeSouth()
        {
            GeoPosition place = new GeoPosition(Dublin.Latitude - 60, Dublin.Longitude);

            Assert.AreEqual(GeoUtils.CalcDistanceInKm(Dublin, place),
                GeoUtils.EARTH_RADIUS * Math.PI / 3, 0.0001);
        }



    }
}
