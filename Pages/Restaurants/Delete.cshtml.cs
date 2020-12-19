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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantsData _restaurantsData;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantsData restaurantsData)
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
        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = _restaurantsData.Delete(restaurantId);
            _restaurantsData.Commit();
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restaurant.Name} Restaurant has been deleted ";
            return RedirectToPage("./List");
        }
    }
}