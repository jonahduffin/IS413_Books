using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JonahsBooks.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BookDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookDbContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        title = "Les Miserables",
                        author = "Victor Hugo",
                        publisher = "Signet",
                        isbn = "978-0451419439",
                        classification = "Fiction, Classic",
                        price = 9.95,
                        numPages = 1488
                    },
                    new Book
                    {
                        title = "Team of Rivals",
                        author = "Doris Kearns Goodwin",
                        publisher = "Simon & Schuster",
                        isbn = "978-0743270755",
                        classification = "Non-Fiction, Biography ",
                        price = 14.58,
                        numPages = 944
                    },
                    new Book
                    {
                        title = "The Snowball",
                        author = "Alice Schroeder",
                        publisher = "Bantam",
                        isbn = "978-0553384611",
                        classification = "Non-Fiction, Biography",
                        price = 21.54,
                        numPages = 832
                    },
                    new Book
                    {
                        title = "American Ulysses",
                        author = "Ronald C. White",
                        publisher = "Random House",
                        isbn = "978-0812981254",
                        classification = "Non-Fiction, Biography",
                        price = 11.61,
                        numPages = 864
                    },
                    new Book
                    {
                        title = "Unbroken",
                        author = "Laura Hillenbrand",
                        publisher = "Random House",
                        isbn = "978-0812974492",
                        classification = "Non-Fiction, Historical",
                        price = 13.33,
                        numPages = 528
                    },
                    new Book
                    {
                        title = "The Great Train Robbery",
                        author = "Michael Crichton",
                        publisher = "Vintage",
                        isbn = "978-0804171281 ",
                        classification = "Fiction, Historical Fiction",
                        price = 15.95,
                        numPages = 288
                    },
                    new Book
                    {
                        title = "Deep Work",
                        author = "Cal Newport",
                        publisher = "Grand Central Publishing",
                        isbn = "978-1455586691",
                        classification = "Non-Fiction, Self-Help",
                        price = 14.99,
                        numPages = 304
                    },
                    new Book
                    {
                        title = "It's Your Ship",
                        author = "Michael Abrashoff",
                        publisher = "Grand Central Publishing",
                        isbn = "978-1455523023",
                        classification = "Non-Fiction, Self-Help",
                        price = 21.66,
                        numPages = 240
                    },
                    new Book
                    {
                        title = "The Virgin Way",
                        author = "Richard Branson",
                        publisher = "Portfolio",
                        isbn = "978-1591847984",
                        classification = "Non-Fiction, Business",
                        price = 29.16,
                        numPages = 400
                    },
                    new Book
                    {
                        title = "Sycamore Row",
                        author = "John Grisham",
                        publisher = "Bantam",
                        isbn = "978-0553393613",
                        classification = "Fiction, Thrillers",
                        price = 15.03,
                        numPages = 642
                    },
                    new Book
                    {
                        title = "Eragon",
                        author = "Christopher Paolini",
                        publisher = "Knopf Books for Young Readers",
                        isbn = "978-0375826696",
                        classification = "Fiction, Fantasy",
                        price = 15.61,
                        numPages = 528
                    },
                    new Book
                    {
                        title = "The Fellowship of the Ring",
                        author = "J.R.R. Tolkien",
                        publisher = "Mariner Books",
                        isbn = "978-0547928210",
                        classification = "Fiction, Fantasy",
                        price = 18.89,
                        numPages = 432
                    },
                    new Book
                    {
                        title = "To Kill A Mockingbird",
                        author = "Harper Lee",
                        publisher = "Grand Central Publishing",
                        isbn = "978-0446310789",
                        classification = "Fiction, Classic",
                        price = 6.70,
                        numPages = 384
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
