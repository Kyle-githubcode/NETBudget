using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NETBudget.Models
{
    public class IncomeContext : DbContext
    {
        public IncomeContext(DbContextOptions<IncomeContext> options)
                : base(options)
        {
        }

        public DbSet<Income> Income { get; set; }

        [DataType(DataType.Currency)]
        public decimal Income_Total()
        {
            decimal income_total = 0;
            foreach (var item in Income.Where(income => income.Type() == "Income"))
            {
                income_total += item.Amount;
            }
            return income_total;
        }

        [DataType(DataType.Currency)]
        public decimal Expense_Total()
        {
            decimal expense_total = 0;
            foreach (var item in Income.Where(income => income.Type() == "Expense"))
            {
                expense_total += item.Amount;
            }
            return -expense_total;
        }
    }
}
