using OdeTeFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeTeFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants { get; private set; }
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { ID = 1, Name = "Barizola", Location="Dzierżoniów", Cuisine = CuisineType.Italian },
                new Restaurant { ID = 2, Name = "Mexican restaurant",Location="Wrocław", Cuisine = CuisineType.Mexican},
                new Restaurant { ID = 3, Name = "Indian restaurant",Location="Warszawa", Cuisine = CuisineType.Indian },
                new Restaurant { ID = 4, Name = "Sushi bar",Location="Wrocław", Cuisine = CuisineType.None },
                new Restaurant { ID = 5, Name = "Dolce Vita",Location="Bydgoszcz", Cuisine = CuisineType.Italian },
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from item in restaurants
                   where string.IsNullOrWhiteSpace(name) || item.Name.ToLower().Contains(name.ToLower())
                   orderby item.Name
                   select item;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(item => item.ID == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(item => item.ID == updatedRestaurant.ID);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.ID = restaurants.Max(item => item.ID) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(item => item.ID == id);

            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants() => restaurants.Count();
    }
}
