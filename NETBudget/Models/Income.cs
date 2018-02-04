using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETBudget.Models
{
    public class Income
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Rate { get; set; }
        public decimal AnnualIncome { get; set; }
    }
}
