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

        //The Type variable determines which table the Income object will appear in
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
