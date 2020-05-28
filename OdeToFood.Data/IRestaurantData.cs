using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;
namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string Name);
        Restaurant GetById(int Id);

        Restaurant Updated(Restaurant restaurant);
        Restaurant Add(Restaurant NewRestaurant);
        Restaurant Delete(int restaurantId);
        int Commit();
        int GetCountOfRestaurants();
    }
}
