using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        // create DbContext
        BookContext db = new BookContext();
                
        public ActionResult Index()
        {
            // fetch objects Book from DB
            IEnumerable<Book> books = db.Books;
            // and send into ViewBag
            ViewBag.Books = books;

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // add purchase's info to DB
            db.Purchases.Add(purchase);
            // save all changes in DB
            db.SaveChanges();

            return "Thanks for purchase, " + purchase.Person;
        }
    }
}