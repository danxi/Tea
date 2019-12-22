using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System;

namespace Tea
{
    public class UserGroup
    {
        public List<User> Users = new List<User>();

        public UserGroup() { }
        public UserGroup(string[] userArr)
        {
            if (userArr != null)
            {
                foreach (string s in userArr)
                {
                    Users.Add(JsonConvert.DeserializeObject<User>(s));
                }
            }
        }

        public static UserGroup LoadUserGroup(string url)
        {
            var myJSON = new WebClient().DownloadString(url);
            string[] jsonArr = myJSON.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return new UserGroup(jsonArr);
        }
    }

    public class User
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        public GeoPosition Position
        {
            get
            {
                return new GeoPosition(latitude, longitude);
            }
        }
    }

    public class GeoPosition
    {
        public Double Latitude { get; private set; }
        public Double Longitude { get; private set; }

        public double LatitudeInRadians
        {
            get
            {
                return Latitude.ToRadians();
            }
        }
        public double LongitudeInRadians
        {
            get
            {
                return Longitude.ToRadians();
            }
        }

        public GeoPosition(double latitude, double longitude)
        {
            if (Math.Abs(latitude) > 90 || Math.Abs(Longitude) > 180)
            {
                throw new ArgumentOutOfRangeException(null, "the place is not on earth::(((");
            }
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

