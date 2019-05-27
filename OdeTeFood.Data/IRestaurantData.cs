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

        Restaurant Delete(int id);
        int Commit();
        int GetCountOfRestaurants();
    }

    
}
