using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant NewRestaurant)
        {
            db.Restaurants.Add(NewRestaurant);
            return NewRestaurant;
        }

        public int Commit()
        {
            db.SaveChanges();
            return 1;
        }

        public Restaurant Delete(int restaurantId)
        {
            var restaurant = GetById(restaurantId);
            if(restaurant!=null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name)
        {
            var query = from s in db.Restaurants
                        where s.Name.StartsWith(Name) || string.IsNullOrEmpty(Name)
                        select s;

            return query;
        }

        public Restaurant Updated(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
                return restaurant;
        }
    }
}
