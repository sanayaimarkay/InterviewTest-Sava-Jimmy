using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewTestMvc.Models;
using InterviewTest.Data;
using Microsoft.Extensions.Configuration;

namespace InterviewTestMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksRepository _book;       
        private readonly IGenreRepository _genre;       
        private readonly IReviewsRepository _review;       

       
        public HomeController(ILogger<HomeController> logger, IBooksRepository book,IGenreRepository genre, IReviewsRepository review)
        {
            _book = book;
            _genre = genre;
            _logger = logger;
            _review = review;
        }
        //Action method for the book list
        public IActionResult Index(string option, string sort,string searchString)
        {
            
            var book = _book.GetBooks().ToList();
            var genres = _genre.GetGenre().ToList();
            var reviews = _review.GetReviews().ToList();
            //BookGenreViewModel is a combination of book,genre and review count
            List<BookGenreViewModel> genreBook = new List<BookGenreViewModel>();

            //looping through every book and adding the genre and reviews count
            for(var i=0;i< book.Count;i++) 
            {
                var bookid = book[i].Id;
                var g = "";
                var reviewCount = 0;
                foreach (var genre in genres)
                {
                    if (bookid == genre.Id)
                    {
                        g = g + " " + genre.Description+",";
                    }
                }
                foreach (var review in reviews)
                {
                    if (bookid == review.BookId)
                    {
                        reviewCount++;
                    }
                }
                BookGenreViewModel gb = new BookGenreViewModel()
                {
                    book = book[i],
                    genre = g,
                    reviewCount=reviewCount
                };
                genreBook.Add(gb);
                

            }
            //Checking to see whether the user have entered any search string
            if (!string.IsNullOrEmpty(searchString))
            {
                genreBook= genreBook.Where(x => x.book.Title.ToLower().Contains(searchString.ToLower()) | x.book.Forename.ToLower().Contains(searchString.ToLower()) | x.book.Surname.ToLower().Contains(searchString.ToLower()) | x.book.ISBN.ToLower().Contains(searchString.ToLower()) | x.book.FirstPublished.ToString().Contains(searchString) | x.genre.ToLower().Contains(searchString.ToLower())).ToList();
            }
            //checking to see whether the user wants to sort the table
            if(!string.IsNullOrEmpty(option) && !string.IsNullOrEmpty(sort))
            {
                string caseSwitch = option;
                switch (caseSwitch)
                {
                    case "title":
                        if (sort == "asc")
                        {
                            genreBook = genreBook.OrderBy(x => x.book.Title).ToList();
                        }
                        else if (sort == "dsc")
                        {
                            genreBook = genreBook.OrderByDescending(x => x.book.Title).ToList();
                        }
                        break;
                    
                    case "genre":
                        if (sort == "asc")
                        {
                            genreBook = genreBook.OrderBy(x => x.genre).ToList();
                        }
                        else if (sort == "dsc")
                        {
                            genreBook = genreBook.OrderByDescending(x => x.genre).ToList();
                        }
                        break;

                    case "author":
                        if (sort == "asc")
                        {
                            genreBook = genreBook.OrderBy(x => x.genre).ToList();
                        }
                        else if (sort == "dsc")
                        {
                            genreBook = genreBook.OrderByDescending(x => x.genre).ToList();
                        }
                        break;

                    case "isbn":
                        if (sort == "asc")
                        {
                            genreBook = genreBook.OrderBy(x => x.book.ISBN).ToList();
                        }
                        else if (sort == "dsc")
                        {
                            genreBook = genreBook.OrderByDescending(x => x.book.ISBN).ToList();
                        }
                        break;

                    case "firstPublished":
                        if (sort == "asc")
                        {
                            genreBook = genreBook.OrderBy(x => x.book.FirstPublished).ToList();
                        }
                        else if (sort == "dsc")
                        {
                            genreBook = genreBook.OrderByDescending(x => x.book.FirstPublished).ToList();
                        }
                        break;
                    
                }
            }
                return View(genreBook);
        }

        //Return the details of a book with its associated genre and reviews
        public IActionResult Details(int Id)
        {
            var book = _book.GetBooks().Where(x=>x.Id==Id).FirstOrDefault();
            var genre = _genre.GetGenre().Where(x=>x.Id==Id).Select(x=>x.Description).ToList();
            var reviews = _review.GetReviews().Where(x => x.BookId == Id).ToList();
            //BookDetailsViewModel combines book,review and genre
            BookDetailsViewModel BookDetails = new BookDetailsViewModel()
            {
                Book = book,
                Reviews = reviews,
                Genres = genre
            };
            
            
            return View(BookDetails);
        }
        //Return a view to enter new review
        [HttpGet]
        public IActionResult Review(Int64 bookid)
        {
            ViewBag.bookid = bookid;
            return View();
        }
        //Save a new review to database
        [HttpPost]
        public IActionResult Review(Reviews model)
        {
            
            if (ModelState.IsValid)
            {
                if (model.Name == null)
                {
                    model.Name = "Anonymous";
                }
                Reviews_DTO review = new Reviews_DTO()
                {
                    BookId = model.BookId,
                    Name = model.Name,
                    Rating = model.Rating,
                    Review = model.Review,
                    ReviewedOn = Convert.ToDateTime(model.ReviewedOn)
                };

                _review.AddReview(review);
            }

            return RedirectToAction("Index");


        }
        
        public IActionResult Brief()
        {
            return View();
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
