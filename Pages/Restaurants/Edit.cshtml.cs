using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Data;
using OdeToFood.Core;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantsData _restaurantsData;
        private readonly IHtmlHelper _htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantsData restaurantsData, IHtmlHelper htmlHelper)
        {
            _restaurantsData = restaurantsData;
            _htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantsData.GetById(restaurantId.Value);

            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();               
            }
            if (Restaurant.Id > 0)
            {
                _restaurantsData.Update(Restaurant);
                TempData["Message"] = "Restaurant Saved";
            }
            else
            {
                _restaurantsData.Add(Restaurant);
                TempData["Message"] = "Restaurant Added";
            }

            _restaurantsData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });

        }
    }
}