using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models;

public class Expense
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, double.MaxValue, 
        ErrorMessage = "Amount must be greater than 0.")]
    public decimal? Amount { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Date is required.")]
    public DateTime? Date { get; set; }

}
