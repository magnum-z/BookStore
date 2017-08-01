using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Util;

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
            purchase.Date = getToday();
            // add purchase's info to DB
            db.Purchases.Add(purchase);
            // save all changes in DB
            db.SaveChanges();

            return "Thanks for purchase, " + purchase.Person;
        }

        // This helper method isn't Action method
        private DateTime getToday()
        {
            return DateTime.Now;
        }

        // http://.../Home/Square
        // http://.../Home/Square?a=15
        // http://.../Home/Square?h=4
        // http://.../Home/Square?a=20&h=7
        public string Square(int a = 10, int h = 3)
        {
            double s = (double) a * h / 2;
            return "<h2>Square triangle with base " + a +
                    " and altitude " + h + " equals " + s + "</h2>";
        }

        // http://.../Home/Square_request?a=18&h=6
        public string Square_request()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = (double) a * h / 2;
            return "<h2>Square triangle with base " + a +
                    " and altitude " + h + " equals " + s + "</h2>";
        }

        // http://.../Home/GetHtml
        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Hello world!</h2>");
        }

        // http://.../Home/GetImage
        public ActionResult GetImage()
        {
            string path = "../Content/visualstudio.png";
            return new ImageResult(path);
        }

        // http://.../Home/Square_content?a=12&h=4
        public ContentResult Square_content(int a, int h)
        {
            int s = a * h / 2;
            return Content("<h2>Square triangle with base " + a + " and altitude " + h + " equals " + s + "</h2>");
        }
    }
}