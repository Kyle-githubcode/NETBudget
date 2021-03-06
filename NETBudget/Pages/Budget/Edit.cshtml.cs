using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETBudget.Models;

namespace NETBudget.Pages.Budget
{
    public class EditModel : PageModel
    {
        private readonly NETBudget.Models.IncomeContext _context;

        public EditModel(NETBudget.Models.IncomeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Income Income { get; set; }

        public SelectList RateList()
        {
            SelectList ratelist = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem{Text = "yearly", Value = "yearly"},
                    new SelectListItem{Text = "monthly", Value = "monthly"},
                    new SelectListItem { Text = "fortnightly", Value = "fortnightly" },
                    new SelectListItem { Text = "weekly", Value = "weekly" },
                    new SelectListItem { Text = "daily", Value = "daily" },
                    new SelectListItem{Text = "hourly", Value = "hourly"}
                }, "Value", "Text"
                );
            return ratelist;
        }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Income.Any(e => e.ID == Income.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.ID == id);
        }
    }
}
