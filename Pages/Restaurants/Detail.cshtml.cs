using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantsData _restaurantsData;

        [TempData]
        public string Message { get; set; }
        public Restaurant  Restaurant { get; set; }

        public DetailModel(IRestaurantsData restaurantsData)
        {
            _restaurantsData = restaurantsData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantsData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}