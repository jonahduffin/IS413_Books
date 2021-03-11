using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JonahsBooks.Models;
using JonahsBooks.Models.ViewModels;

namespace JonahsBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookRepository _repository;
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pageNum = 1) // page indicates which page of books to show. Defaults to page 1.
        {
            //This returns data from Books database to the Home view
            return View(new BookListViewModel
            {
                Books = _repository.Books
                .Where(p => category == null || p.classification.ToLower().Contains(category.ToLower())) // because category field is comma separated, we check to see if classification contains the category
                .OrderBy(p => p.BookID)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = PageSize,
                    //Calculates page numbers based on category, if there is one
                    TotalNumItems = category == null ? _repository.Books.Count() : 
                        _repository.Books.Where( x => x.classification == category).Count()
                },
                CurrentCategory = category
            }) ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
