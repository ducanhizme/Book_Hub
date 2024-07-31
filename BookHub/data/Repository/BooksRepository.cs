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

       
       
        public Book GetBookById(int id)
        {
            using (var context = new AppContext()) {
                return context.Books.Include("Publisher").Include("BookCategories").FirstOrDefault(book => book.BookId == id);
            }
        }

        public List<Book> GetBooksByCategoryId(int categoryId)
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
        
        public  List<Book> GetBooksByCategoryIds(List<int> categoryIds)
        {
            using (var context = new AppContext())
            {
                return context.Books
                    .Where(book => book.BookCategories.Any(bc => categoryIds.Contains(bc.CategoryId)))
                    .Distinct()
                    .ToList();
            }
        }
        public List<Book> GetBookByName(string name)
        {
            using (var context = new AppContext())
            {
                return context.Books.Where(book => book.BookName.Contains(name)).ToList();
            }
        }
        
        public void DeleteBookById(int id)
        {
            using (var context = new AppContext())
            {
                var book = context.Books.FirstOrDefault(b => b.BookId == id);
                if (book != null)
                {
                    var bookCategories = context.BookCategories.Where(bc => bc.BookId == id).ToList();
                    context.BookCategories.RemoveRange(bookCategories);
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }
        public void UpdateBook(Book updatedBook)
        {
            using (var context = new AppContext())
            {
                var existingBook = context.Books.FirstOrDefault(b => b.BookId == updatedBook.BookId);
                if (existingBook != null)
                {
                    existingBook.BookName = updatedBook.BookName;
                    existingBook.Author = updatedBook.Author;
                    existingBook.Price = updatedBook.Price;
                    existingBook.Language = updatedBook.Language;
                    existingBook.PublicationDate = updatedBook.PublicationDate;
                    existingBook.Image = updatedBook.Image;
                    context.SaveChanges();
                }
            }
        }
        
        public List<Publisher> GetAllPublishers()
        {
            using (var context = new AppContext())
            {
              return context.Publishers.ToList();
            }
        }
        
        public void CreateBook(Book newBook)
        {
            using (var context = new AppContext())
            {
                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }
    }
}