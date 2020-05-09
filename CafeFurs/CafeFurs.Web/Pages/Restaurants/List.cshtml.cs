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
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = "Hello World";
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
