using GS.DataBase.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GS.DataBase.SeedData
{
    public static class SeedDataProvider
    {
        public static City[] GetCities()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/City.json");
            var cities = JsonConvert.DeserializeObject<List<City>>(citiesFile);
            return cities.ToArray();
        }

        public static Place[] GetPlaces()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/Place.json");
            var places = JsonConvert.DeserializeObject<List<Place>>(citiesFile);
            return places.ToArray();
        }

        public static Review[] GetReviews()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/Review.json");
            var reviews = JsonConvert.DeserializeObject<List<Review>>(citiesFile);
            return reviews.ToArray();
        }

        public static Trip[] GetTrips()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/Trip.json");
            var trips = JsonConvert.DeserializeObject<List<Trip>>(citiesFile);
            return trips.ToArray();
        }

        public static TripNode[] GetTripNodes()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/TripNode.json");
            var tripNodes = JsonConvert.DeserializeObject<List<TripNode>>(citiesFile);
            return tripNodes.ToArray();
        }

        public static User[] GetUsers()
        {
            string citiesFile = File.ReadAllText(Directory.GetCurrentDirectory() + "/SeedData/User.json");
            var users = JsonConvert.DeserializeObject<List<User>>(citiesFile);
            return users.ToArray();
        }
    }
}
