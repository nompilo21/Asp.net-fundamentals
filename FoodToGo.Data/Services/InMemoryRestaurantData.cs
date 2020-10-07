using FoodToGo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoodToGo.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
            List<Restaurant> restaurants;
            public InMemoryRestaurantData()
            {
                restaurants = new List<Restaurant>()
                {
                    new Restaurant{Id = 1, Name="Krispy Kreme", Location="Durban", Cuisine =CuisineType.None },
                    new Restaurant{Id = 2, Name="Mike's Pizza", Location="Balito", Cuisine =CuisineType.Italian },
                    new Restaurant{Id = 3, Name="Curry Guru", Location="Umhlanga", Cuisine =CuisineType.Indian },
                    new Restaurant{Id = 4, Name="Mama Thembis", Location="La Lucia", Cuisine =CuisineType.African },
                    new Restaurant{Id = 5, Name="Ratata", Location="KwaMashu", Cuisine =CuisineType.Mozambican }
                }; 
            }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
}
}
