using System.ComponentModel.DataAnnotations;

namespace NETBudget.Models
{
    public class Income
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Rate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public string Type()
        {
            if(Amount < 0)
            {
                return "Expense";
            }
            else
            {
                return "Income";
            }
        }
    }
}
