﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebGentleCourse.Models;
using WebGentleCourse.Repository;

namespace WebGentleCourse.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {

            var data = await _bookRepository.GetBookById(id);

            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel) 
        {
            int id = await _bookRepository.AddNewBook(bookModel);
            if(id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new  {isSuccess = true, bookId = id });    
            }
            return View();
        }


    }
}
