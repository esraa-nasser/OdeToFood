using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.VieComponents
{
    public class RestaurantsCountViewComponent:ViewComponent
    {
        private readonly IRestaurantsData _restaurantsData;

        public RestaurantsCountViewComponent(IRestaurantsData restaurantsData)
        {
            _restaurantsData = restaurantsData;
        }
        public IViewComponentResult Invoke()
        {
          var count = _restaurantsData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
