using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tea;

namespace TeaTests
{
    [TestClass]
    public class GeoUtilsTest
    {
        GeoPosition Dublin = new GeoPosition
        {
            LatitudeInRadians = (double)53.339428.ToRadians(),
            LongitudeInRadians = (double)-6.257664.ToRadians()
        };

        [TestMethod]
        public void TestCalcDistanceInKm_DublinIsCloserToBarcelonaThanToBeijing()
        {
            GeoPosition Beijing = new GeoPosition
            {
                LatitudeInRadians = (double)39.895362.ToRadians(),
                LongitudeInRadians = (double)116.357594.ToRadians()
            };

            GeoPosition Barcelona = new GeoPosition
            {

                LatitudeInRadians = (double)41.387042.ToRadians(),
                LongitudeInRadians = (double)2.152542.ToRadians()
            };

            Assert.IsTrue(GeoUtils.CalcDistanceInKm(Dublin, Barcelona) < GeoUtils.CalcDistanceInKm(Dublin, Beijing));
                
        }
    }
}
