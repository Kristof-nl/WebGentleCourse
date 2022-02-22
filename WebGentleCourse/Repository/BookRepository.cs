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
                        Language = book.Language,
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
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.Now
            };  

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                
                return bookDetails;
            }

            return null;
        }


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id= 1, Title ="MVC", Author = "Nitish", Description="This is description for MVC", Category="Programming", Language="English", TotalPages=1245 },
                new BookModel() { Id = 2, Title = "Dot Net Core", Author = "Nitish", Description="This is description for Dot Net Core", Category="Programming", Language="French", TotalPages=975 },
                new BookModel() { Id = 3, Title = "C#", Author = "Monika", Description="This is description for C#", Category="Developer", Language="English", TotalPages=789 },
                new BookModel() { Id = 4, Title = "Java", Author = "WebGentle", Description="This is description for Java", Category="Programming", Language="English", TotalPages=541 },
                new BookModel() { Id = 5, Title = "PHP", Author = "WebGentle", Description="This is description for PHP", Category="Developer", Language="German", TotalPages=689 },
                new BookModel() { Id = 6, Title = "Azure DevOps", Author = "Nitish", Description="This is description for Azure DevOps with the second ine of text.", Category="Programming", Language="English", TotalPages=1003 }
            };
        }
    }
}
