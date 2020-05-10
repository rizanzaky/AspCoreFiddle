using System;
using System.Collections.Generic;
using System.Linq;
using CafeFurz.Core.Enums;
using CafeFurz.Core.Models;

namespace CafeFurz.Core.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int restaurnatId);
        Restaurant Create(Restaurant restaurant);
        Restaurant Update(Restaurant restaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant> {
            new Restaurant{ Id = 1, Name = "Afu's Special Delight", Location = "Gampaha", Cousine = CousineType.Arabian },
            new Restaurant{ Id = 2, Name = "Cafe Afu", Location = "Dehiwala", Cousine = CousineType.Mexican },
            new Restaurant{ Id = 3, Name = "Afu and Bakes", Location = "Gampaha", Cousine = CousineType.Arabian },
            new Restaurant{ Id = 4, Name = "Premium Afu Food", Location = "Colombo", Cousine = CousineType.Italian },
            new Restaurant{ Id = 5, Name = "Afu n Z Taste", Location = "Mount Lavinia", Cousine = CousineType.Indian }
        };

        public Restaurant Create(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(restaurant);
            return restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var oldRestaurant = Restaurants.FirstOrDefault(r => r.Id == restaurant.Id);

            if (oldRestaurant != null)
            {
                oldRestaurant.Name = restaurant.Name;
                oldRestaurant.Location = restaurant.Location;
                oldRestaurant.Cousine = restaurant.Cousine;
            }

            return oldRestaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Restaurants;
            }

            return Restaurants.Where(r => r.Name.ToLower().Contains(name.ToLower()));
        }

        public Restaurant GetRestaurantById(int restaurnatId)
        {
            return Restaurants.FirstOrDefault(r => r.Id == restaurnatId);
        }
    }
}
