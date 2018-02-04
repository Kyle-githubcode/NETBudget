using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NETBudget.Models;

namespace NETBudget.Pages.Budget
{
    public class IndexModel : PageModel
    {
        private readonly NETBudget.Models.IncomeContext _context;

        public IndexModel(NETBudget.Models.IncomeContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; }

        public async Task OnGetAsync()
        {
            Income = await _context.Income.ToListAsync();
        }
    }
}
