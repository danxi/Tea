using System;
using System.Net;

namespace Tea
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /* setup condtion to find users for tea
                 * 1. distance range (in km)
                 * 2. load user to search for
                 * 3. the meet location
                 */
                double range = 100;
                if (args.Length > 0) double.TryParse(args[0], out range);

                var url = @"https://s3.amazonaws.com/intercom-take-home-test/customers.txt";
                UserGroup allUsers = UserGroup.LoadUserGroup(url);
                User office = new User()
                {
                    name = "Intercom Dublin office",
                    latitude = 53.339428,
                    longitude = -6.257664
                };
                Console.WriteLine(string.Format(@"Looking for: user in {0}km range around {1}...", range, office.name));

                UserGroup userInRange = new TeaMateFinder(office, range, allUsers).UserInRange();
                Console.WriteLine(string.Format(@"totally: {0} users in range.", userInRange.Users.Count));

                //print out user that in range
                if (userInRange.Users.Count > 0)
                {
                    //sort user by id
                    userInRange.Users.Sort((a, b) => a.user_id - b.user_id);

                    Console.WriteLine("\nUser ID\t\tName");
                    userInRange.Users.ForEach(
                        user => Console.WriteLine(string.Format("{0}\t\t{1}", user.user_id, user.name)));
                }
            }
            catch (WebException)
            {
                Console.WriteLine("Network error, please try later.");
            }
            catch(Exception e)
            {
                Console.WriteLine("unexpected error:" + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }


    public class TeaMateFinder
    {
        private User centralLocation;
        private UserGroup allUsers;
        private double range;

        public TeaMateFinder(User meetLocation, double rangeInKm, UserGroup users)
        {
            centralLocation = meetLocation;
            allUsers = users;
            range = rangeInKm;
        }

        public UserGroup UserInRange()
        {
            UserGroup userInRange = new UserGroup();
            allUsers.Users.ForEach(user => { if (IsInRange(user, range)) userInRange.Users.Add(user); });
            return userInRange;
        }

        private bool IsInRange(User user, double rangeInKm)
        {
            return (GeoUtils.CalcDistanceInKm(centralLocation.Position, user.Position) <= rangeInKm);

        }
    }

}


