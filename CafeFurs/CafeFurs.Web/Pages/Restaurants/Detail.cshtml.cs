using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeFurz.Core.Models;
using CafeFurz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CafeFurs.Web.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }
    }
}
