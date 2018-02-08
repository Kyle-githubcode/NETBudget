using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETBudget.Models;

namespace NETBudget.Pages.Budget
{
    public class CreateModel : PageModel
    {
        private readonly NETBudget.Models.IncomeContext _context;

        public CreateModel(NETBudget.Models.IncomeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
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
                    new SelectListItem { Text = "weekly", Value = "weekly" },
                    new SelectListItem { Text = "daily", Value = "daily" },
                    new SelectListItem{Text = "hourly", Value = "hourly"}
                }, "Value", "Text"
                );
            return ratelist;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Income.Add(Income);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}