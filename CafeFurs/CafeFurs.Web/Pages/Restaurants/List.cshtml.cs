using System.Collections.Generic;
using CafeFurz.Core.Models;
using CafeFurz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CafeFurs.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public ListModel(IRestaurantData restaurantData, IConfiguration configuration)
        {
            _restaurantData = restaurantData;
            _configuration = configuration;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)] public string SearchTerm { get; set; }

        public void OnGet()
        {
            Message = _configuration["Application"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}