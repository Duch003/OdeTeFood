using System;
using System.Collections.Generic;
using System.Text;
using OdeTeFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeTeFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeTeFoodDbContext db;

        public SqlRestaurantData(OdeTeFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public int Commit() => db.SaveChanges();
        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id) => db.Restaurants.Find(id);
        public int GetCountOfRestaurants() => db.Restaurants.Count();
        public IEnumerable<Restaurant> GetRestaurantsByName(string name) => (from item in db.Restaurants
                                                                             where string.IsNullOrWhiteSpace(name) ||
                                                                             item.Name.ToLower().Contains(name.ToLower())
                                                                            orderby item.Name
                                                                            select item).ToList();
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
