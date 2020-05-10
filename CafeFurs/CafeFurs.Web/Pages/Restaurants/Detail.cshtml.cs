using CafeFurz.Core.Models;
using CafeFurz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CafeFurs.Web.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet(int restaurantId)
        {
            Message = TempData["Message"]?.ToString();
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null) return RedirectToPage("NotFound");

            return Page();
        }
    }
}