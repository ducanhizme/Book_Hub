using BookHub.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}