using System.Collections.Generic;
using Newtonsoft.Json;

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
                return new GeoPosition
                {
                    LongitudeInRadians = longitude.ToRadians(),
                    LatitudeInRadians = latitude.ToRadians()
                };
            }
        }
    }

    public struct GeoPosition
    {
        public double LongitudeInRadians;
        public double LatitudeInRadians;
    }
}

