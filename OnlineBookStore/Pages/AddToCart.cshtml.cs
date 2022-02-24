// AddToCart Model
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineBookStore.Infrastructure;
using OnlineBookStore.Models;

namespace OnlineBookStore.Pages
{
    public class AddToCartModel : PageModel
    {
        private IBookStoreRepository repo { get; set; }

        public AddToCartModel (IBookStoreRepository temp)
        {
            repo = temp;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.AddItem(b, 1);

            HttpContext.Session.SetJson("Cart", Cart);

            // return RedirectToAction(ReturnUrl);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
