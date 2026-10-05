using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services;

public class ExpenseService
{
    private readonly AppDbContext _dbContext;

    public ExpenseService(AppDbContext appDbContext)
    {
        _dbContext = appDbContext;
    }

    public async Task CreateExpense(Expense expenseReq)
    {    
        _dbContext.Expenses.Add(expenseReq);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Expense>> GetAllExpenses()
    {
        return await _dbContext.Expenses.ToListAsync();
    }

    public async Task<Expense?> GetById(int id)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> ModifyExpenseById(Expense expenseReq)
    {
        var expenseObj = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == expenseReq.Id);
        if (expenseObj == null)
        {
            return false;
        }

        expenseObj.Description = expenseReq.Description;
        expenseObj.Amount = expenseReq.Amount;
        expenseObj.Category = expenseReq.Category;
        expenseObj.Date = expenseReq.Date;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task DeleteById(int id)
    {
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
        if (expense != null)
        {
            _dbContext.Expenses.Remove(expense);
            await _dbContext.SaveChangesAsync();
        }
    }
}