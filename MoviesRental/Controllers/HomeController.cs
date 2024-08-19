using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesRental.Models;

namespace MoviesRental.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Expenses()
        {
            ExpensesBusinessLayer businessLayer = new ExpensesBusinessLayer();
            List<Expenses> expenses = businessLayer.Expenses.ToList();
            return View(expenses);
        }

        [HttpGet]
        public ActionResult CreateExpense()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExpense(FormCollection formCollection)
        {
            Expenses expenses = new Expenses();
            expenses.Value = Convert.ToDecimal(formCollection["Value"]);
            expenses.Description = formCollection["Description"];

            ExpensesBusinessLayer expensesBusinessLayer = new ExpensesBusinessLayer();
            expensesBusinessLayer.AddExpenses(expenses);

            return RedirectToAction("Expenses");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}