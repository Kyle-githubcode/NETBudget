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
    public class DetailsModel : PageModel
    {
        private readonly NETBudget.Models.IncomeContext _context;

        public DetailsModel(NETBudget.Models.IncomeContext context)
        {
            _context = context;
        }

        public Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.Income.SingleOrDefaultAsync(m => m.ID == id);

            if (Income == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
