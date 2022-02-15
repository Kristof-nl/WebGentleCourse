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
