using JonahsBooks.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonahsBooks.Components
{
    public class NavigationMenuViewComponent : ViewComponent 
    {
        private IBookRepository repository;
        public NavigationMenuViewComponent(IBookRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            //returns to view all the categories needed to build the category navigation menu. Pulls that data from the repository
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(x => x.classification)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
