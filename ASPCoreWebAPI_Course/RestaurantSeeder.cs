using ASPCoreWebAPI_Course.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWebAPI_Course
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name="KFC",
                    Category="Fast Foof",
                    Description="Lorem Ypsum",
                    ContactEmail="kfc@kfc.com",
                    HasDelivery=true,
                    Dishes=new List<Dish>()
                    {
                        new Dish()
                        {
                            Name="Hot Chicken",
                            Price="10.30M",
                        },
                        new Dish()
                        {
                            Name="Chicken Nugets",
                            Price="5.30M",
                        },
                    },
                    Address= new Address()
                    {
                        City="Kraków",
                        Street="Długa",
                        PostalCode="30-001"
                    }
                },
                new Restaurant()
                {
                    Name="Mc Donald",
                    Category="Fast Foof",
                    Description="Lorem Ypsum",
                    ContactEmail="mc@mc.com",
                    HasDelivery=true,
                    Dishes=new List<Dish>()
                    {
                        new Dish()
                        {
                            Name="Happy meal",
                            Price="8.30M",
                        },
                        new Dish()
                        {
                            Name="Mc Royal",
                            Price="4.30M",
                        },
                    },
                    Address= new Address()
                    {
                        City="Kraków",
                        Street="Szara",
                        PostalCode="30-005"
                    }
                }

            };

            return restaurants;
        }
    }
}
