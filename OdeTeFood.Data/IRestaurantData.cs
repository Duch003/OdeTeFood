using OdeTeFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeTeFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);

        void Remove(int id);
        int Commit();
    }

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

            if(restaurant != null)
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

        public void Remove(int id)
        {
            restaurants.RemoveAll(item => item.ID == id);
        }
    }
}
