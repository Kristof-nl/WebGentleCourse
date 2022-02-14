using System.Collections.Generic;
using System.Linq;
using WebGentleCourse.Models;

namespace WebGentleCourse.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }


        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id= 1, Title ="MVC", Author = "Nitish", Description="This is description for MVC" },
                new BookModel() { Id = 2, Title = "Dot Net Core", Author = "Nitish", Description="This is description for Dot Net Core" },
                new BookModel() { Id = 3, Title = "C#", Author = "Monika", Description="This is description for C#" },
                new BookModel() { Id = 4, Title = "Java", Author = "WebGentle", Description="This is description for Java" },
                new BookModel() { Id = 5, Title = "PHP", Author = "WebGentle", Description="This is description for PHP" },
                new BookModel() { Id = 6, Title = "Azure DevOps", Author = "Nitish", Description="This is description for Azure DevOps" }
            };
        }
    }
}
