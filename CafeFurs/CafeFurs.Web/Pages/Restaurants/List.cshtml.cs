using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeFurz.Core.Models;
using CafeFurz.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CafeFurs.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IConfiguration _configuration;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData, IConfiguration configuration)
        {
            this.restaurantData = restaurantData;
            _configuration = configuration;
        }

        public void OnGet()
        {
            Message = _configuration["Application"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
