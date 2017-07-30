using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Purchase
    {
        // ID of purchase
        public int PurchaseId { get; set; }
        // customer's name and surname
        public string Person { get; set; }
        // customer's address
        public string Address { get; set; }
        // ID of book
        public int BookId { get; set; }
        // date of purchase
        public DateTime Date { get; set; }
    }
}