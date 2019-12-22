using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea
{
    /// <summary>
    /// Utility to work with geography distance calculation. 
    /// </summary> 
    public class GeoUtils
    {
        //take the earch mean radius as 6371km. https://en.wikipedia.org/wiki/Earth_radius#Mean_radius
        public const int EARTH_RADIUS = 6371;

        /// <summary>
        /// Calc the central angle in sphere. https://en.wikipedia.org/wiki/Great-circle_distance 
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="posB"></param>
        /// <returns></returns>
        public static double GetCentralAngle(GeoPosition posA, GeoPosition posB)
        {
            double LongtitudeDiff = Math.Abs(posA.LongitudeInRadians - posB.LongitudeInRadians);

            return Math.Acos(
                Math.Sin(posA.LatitudeInRadians) * Math.Sin(posB.LatitudeInRadians) +
                Math.Cos(posA.LatitudeInRadians) * Math.Cos(posB.LatitudeInRadians) * Math.Cos(LongtitudeDiff));
         }

        /// <summary>
        /// calc distance between two points in Earth
        /// </summary>
        /// <param name="posA"></param>
        /// <param name="posB"></param>
        /// <returns></returns>
        public static double CalcDistanceInKm(GeoPosition posA, GeoPosition posB)
        {
            return EARTH_RADIUS * GetCentralAngle(posA, posB);
        }
    }

    /// <summary>
    /// Convert decimal degree to radians.
    /// </summary>
    /// <param name="val">decimal degree</param>
    /// <returns>The value in radians</returns>
    public static class DecimalDegreeExtensions
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }

}
