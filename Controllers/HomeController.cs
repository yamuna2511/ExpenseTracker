using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Controllers;

public class HomeController : Controller
{

    private readonly ExpenseService _expenseService;

    public HomeController(ExpenseService expenseService)
    {
        _expenseService = expenseService;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task<IActionResult> Expenses()
    {
        return View(await _expenseService.GetAllExpenses());
    }

    public IActionResult AddExpense()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> AddExpense(Expense expense)
    {
        if (ModelState.IsValid)
        {
            await _expenseService.CreateExpense(expense);
            return RedirectToAction("Expenses");
        }
        return View(expense);      

    }

    [HttpGet]
    public async Task<IActionResult> EditExpense(int id)
    {
        var expense = await _expenseService.GetById(id);
        if (expense == null)
        {
            return NotFound();
        }
        return View(expense);
    }

    [HttpPost]
    public async Task<IActionResult> EditExpense(Expense expense)
    {
        if (ModelState.IsValid && await _expenseService.ModifyExpenseById(expense))
        {    
            return RedirectToAction("Expenses");
        }

        return View(expense);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteExpense(int id)
    {  
        await _expenseService.DeleteById(id);        
        return RedirectToAction("Expenses");
    }
}
