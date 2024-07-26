using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookHub.data.Models;
using BookHub.data.Repository;
using BookHub.Ultis;
using Org.BouncyCastle.Ocsp;

namespace BookHub
{
    public partial class AdminHome : AdminPage
    {
        private BooksRepository _booksRepository;
        private CategoryRepository _categoryRepository;

        protected void Page_Load(object sender, EventArgs e)
        {
            _booksRepository = new BooksRepository();
            _categoryRepository = new CategoryRepository();
            BindSelectedCategory();
            BindDataToTable(Request.QueryString["action"]);
        }

        private void BindDataToTable(String action)
        {
            List<Book> books = new List<Book>();
            switch (action)
            {
                case "search":
                    string searchKey = Request.Form.Get("search-key");
                    books = _booksRepository.GetBookByName(searchKey);
                    break;
                case "filter":
                    string orderBy = Request.QueryString["orderBy"];
                    switch (orderBy)
                    {
                        case "category":
                            if (Request.QueryString["categoryId"] != null)
                            {
                                     books = _booksRepository.GetBooksByCategoryId(
                                                                        Convert.ToInt32(Request.QueryString["categoryId"]));
                            }
                            break;
                        case "price":
                            books = _booksRepository.GetAllBooks();
                            if (Request.QueryString["type"] != null)
                            {
                                switch (Request.QueryString["type"])
                                {
                                    case "asc":
                                        books.Sort((book1, book2) => book1.Price.CompareTo(book2.Price));
                                        break;
                                    case "desc":
                                        books.Sort((book1, book2) => book2.Price.CompareTo(book1.Price));
                                        break;
                                }
                            }

                            break;
                        case "date":
                            books = _booksRepository.GetAllBooks();
                            if (Request.QueryString["type"] != null)
                            {
                                switch (Request.QueryString["type"])
                                {
                                    case "asc":
                                        books.Sort((book1, book2) =>
                                            book1.PublicationDate.CompareTo(book2.PublicationDate));
                                        break;
                                    case "desc":
                                        books.Sort((book1, book2) =>
                                            book2.PublicationDate.CompareTo(book1.PublicationDate));
                                        break;
                                }
                            }

                            break;
                    }

                    break;
                default:
                    books = _booksRepository.GetAllBooks();
                    break;
            }
            string html = "";
            foreach (var book in books)
            {
                html += $@" <tr>
                        <td class=""book-id"">{book.BookId}</td>
                        <td>{book.BookName}</td>
                        <td>{book.Author}</td>
                        <td class=""price"">{book.Price}</td>
                        <td class=""language"">{book.Language}</td>
                        <td class=""publication-date"">{book.DateToString()}</td>
                        <td><img src=""{book.Image}"" alt=""Book Image"" class=""book-image""></td>
                        <td><a href=""EditBook.aspx?id={book.BookId}"" class=""edit-button"">Edit</button></td>
                        <td><a href=""RemoveBook.aspx?id={book.BookId}"" class=""delete-button"">Delete</button></td>
                    </tr>";
            }
            bookTableBody.InnerHtml = html;
        }

        private void BindSelectedCategory()
        {
            List<Category> categories = _categoryRepository.GetAllCategories();
            string html = categoryFilter.InnerHtml;
            foreach (var category in categories)
            {
                html +=
                    $@"<a href=""AdminHome.aspx?action=filter&orderBy=category&categoryId={category.CategoryId}"">{category.CategoryName}</a>";
            }

            categoryFilter.InnerHtml = html;
        }
    }
}