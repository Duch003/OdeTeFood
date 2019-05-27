using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeTeFood.Core;
using OdeTeFood.Data;

namespace UI.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly OdeTeFood.Data.OdeTeFoodDbContext _context;

        public IndexModel(OdeTeFood.Data.OdeTeFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
