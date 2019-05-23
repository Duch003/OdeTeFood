using OdeTeFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeTeFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();


    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant { ID = 1, Name = "Barizola", Cuisine = CuisineType.Italian },
                new Restaurant { ID = 2, Name = "Mexican restaurant", Cuisine = CuisineType.Mexican},
                new Restaurant { ID = 3, Name = "Indian restaurant", Cuisine = CuisineType.Indian },
                new Restaurant { ID = 4, Name = "Sushi bar", Cuisine = CuisineType.None },
                new Restaurant { ID = 5, Name = "Dolce Vita", Cuisine = CuisineType.Italian },
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
