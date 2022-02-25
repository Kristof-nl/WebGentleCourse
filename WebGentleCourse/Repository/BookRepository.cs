using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentleCourse.Data;
using WebGentleCourse.Models;

namespace WebGentleCourse.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async  Task<List<BookModel>> GetAllBooks()
        {

            var allBooks = await _context.Books.ToListAsync();
            var books = new List<BookModel>();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Id = book.Id,
                        Category = book.Category,
                        Description = book.Description,
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.Now
            };  

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();
               
        }


        //public List<BookModel> SearchBook(string title, string authorName)
        //{
        //    return _context.Books.Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        //}

    }
}
