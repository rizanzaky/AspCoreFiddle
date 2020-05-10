using System.Collections.Generic;
using CafeFurz.Core.Enums;
using CafeFurz.Core.Models;
using CafeFurz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeFurs.Web.Pages.Restaurants
{
    public class UpdateModel : PageModel
    {
        private readonly IHtmlHelper _htmlHelper;
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cousines => _htmlHelper.GetEnumSelectList<CousineType>();

        public UpdateModel(IHtmlHelper htmlHelper, IRestaurantData restaurantData)
        {
            _htmlHelper = htmlHelper;
            _restaurantData = restaurantData;
        }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (restaurant.Id == 0)
            {
                Restaurant = _restaurantData.Create(restaurant);
            }
            else
            {
                Restaurant = _restaurantData.Update(restaurant);
            }

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}