using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace OdeToFood.Data
{
   public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetById(int Id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {

       public readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id=1,Name="Mangesh Restaurant",Location="Pune",Cuisine=CuisineType.Indian },
                new Restaurant {Id=2,Name="Mrunali Restaurant",Location="Jalgaon",Cuisine=CuisineType.Italian },
                new Restaurant {Id=3,Name="Mrugesh Restaurant",Location="Yuganda",Cuisine=CuisineType.Mexican }
            };
        }

        public Restaurant GetById(int Id)
        {
            return restaurants.SingleOrDefault(r=>r.Id==Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string Name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(Name)||r.Name.StartsWith(Name)
                   orderby r.Name
                   select r;
        }
    }
}
