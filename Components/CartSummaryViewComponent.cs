using JonahsBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonahsBooks.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartservice)
        {
            cart = cartservice;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }

    }
}
