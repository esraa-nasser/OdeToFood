using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantsData _restaurantsData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantsData restaurantsData)
        {
            _configuration = configuration;
            _restaurantsData = restaurantsData;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IConfiguration _configuration { get; set; }
        public void OnGet()
        {
            Message = "Hello, World!";
            Restaurants = _restaurantsData.GetRestaurantByName(SearchTerm);
        }
    }
}