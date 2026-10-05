namespace ExpenseTracker.Models;

public class CreateExpenseDto
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime date { get; set; }
    
}