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
            decimal income_total = Calculate_Total(Income, "Income");
            return income_total;
        }

        [DataType(DataType.Currency)]
        public decimal Expense_Total()
        {
            decimal expense_total = Calculate_Total(Income, "Expense");
            return -expense_total;
        }

        private decimal Calculate_Total(DbSet<Income> Income, string type)
        {
            decimal total = 0;
            foreach (var item in Income.Where(income => income.Type() == type))
            {
                decimal modifier = RateModifer(item);
                total += item.Amount*modifier;
            }
            return total;
        }

        private decimal RateModifer(Income Income)
        {
            switch(Income.Rate)
            {
                case "hourly":
                    return 24*365;
                case "daily":
                    return 365;
                case "weekly":
                    return 52;
                case "monthly":
                    return 12;
                default:
                    return 1;
            }
        }
    }
}
