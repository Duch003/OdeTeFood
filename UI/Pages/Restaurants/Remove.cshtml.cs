using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeTeFood.Data;

namespace UI.Pages.Restaurants
{
    public class RemoveModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [TempData]
        public string Message { get; set; }
        public RemoveModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet(int restaurantId)
        {
            restaurantData.Remove(restaurantId);
            Message = "Restaurant has been removed!";
        }
    }
}