using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JonahsBooks.Infrastructure;
using JonahsBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JonahsBooks.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookRepository repository;
        // constructor
        public PurchaseModel (IBookRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            //ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long bookID, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.BookID == bookID);

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(book, 1);
           //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });

        }

        public IActionResult OnPostRemove(long bookID, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.FirstOrDefault(cl => cl.Book.BookID == bookID).Book);
            //HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
