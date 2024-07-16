using BookHub.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Xml.Linq;

namespace BookHub.data.Repository
{
    public class BooksRepository
    {
        public List<Book> GetAllBooks()
        {
            using (var context = new AppContext())
            {
            return context.Set<Book>().ToList();
            }
        }

       
       
        public Book GetBookByID(int id)
        {
            using (var context = new AppContext()) {
                return context.Set<Book>().FirstOrDefault(book => book.BookId == id);
            }
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            using (var context = new AppContext())
            {
                return context.Books
                                .Join(context.BookCategories,b => b.BookId, bc => bc.BookId,(b, bc) => new { Book = b, BookCategory = bc })
                                .Where(result => result.BookCategory.CategoryId == categoryId)
                                .Select(result => result.Book)
                                .ToList();
            }
        }
        public Book GetBookByName(string name)
        {
            using (var context = new AppContext())
            {
                return context.Set<Book>().FirstOrDefault(book => book.BookName == name);
            }
        }


    }
}