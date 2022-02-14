using Microsoft.AspNetCore.Mvc;
using WebGentleCourse.Models;
using WebGentleCourse.Repository;

namespace WebGentleCourse.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }


        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        //public BookModel GetBook(int id)
        //{
        //    var data = _bookRepository.GetBookById(id);
            
        //}

        //public IActionResult GetAllBooks()
        //{
        //    var data = _bookRepository.GetAllBooks();
        //    return View();
        //}
    }
}
