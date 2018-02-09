using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
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
            Income_Total = context.Income_Total();
            Expense_Total = context.Expense_Total();
            Total = context.Total();
        }

        public IList<Income> Income { get;set; }

        [DataType(DataType.Currency)]
        public decimal Income_Total { get; set; }

        [DataType(DataType.Currency)]
        public decimal Expense_Total { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public async Task OnGetAsync()
        {
            Income = await _context.Income.ToListAsync();
        }
    }
}
