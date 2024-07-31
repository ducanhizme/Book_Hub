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
            UpdateBook();
            BindSelectedCategory();
            BindDataToTable(Request.QueryString["action"]);
            BindSelectedPublisher();
            
        }

        private void UpdateBook()
        {
            if (Request.Form.Get("action") == "Edit")
            {
                foreach (var book in _booksRepository.GetAllBooks())
                {
                    string bookName = Request.Form.Get($"nameEt_{book.BookId}");
                    string author = Request.Form.Get($"authorEt_{book.BookId}");
                    decimal price = Convert.ToDecimal(Request.Form.Get($"priceEt_{book.BookId}"));
                    string language = Request.Form.Get($"languageEt_{book.BookId}");
                    DateTime publicationDate = Convert.ToDateTime(Request.Form.Get($"dateEt_{book.BookId}"));
                    string image = Request.Form.Get($"imgEt_{book.BookId}");
                    book.BookName = bookName;
                    book.Author = author;
                    book.Price = price;
                    book.Language = language;
                    book.PublicationDate = publicationDate;
                    book.Image = image;
                    _booksRepository.UpdateBook(book);
                    Session[Constants.Success] = "Update book success";
                    Response.Redirect("AdminHome.aspx");
                }
            }else if(Request.Form.Get("create") == "Create")
            {
                CreateProduct();
            }
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
                    <td class=""book-id""><input type=""text"" value=""{book.BookId}""  class=""book-input"" name=""idEt_{book.BookId}"" readonly></td>
                    <td><input type=""text"" value=""{book.BookName}""  class=""book-input"" name=""nameEt_{book.BookId}""></td>
                    <td><input type=""text"" value=""{book.Author}""  class=""book-input"" name=""authorEt_{book.BookId}""></td>
                    <td class=""price""><input type=""text"" value=""{book.Price}""  class=""book-input"" name=""priceEt_{book.BookId}""></td>
                    <td class=""language""><input type=""text"" value=""{book.Language}""  class=""book-input"" name=""languageEt_{book.BookId}""></td>
                    <td class=""publication-date""><input type=""datetime"" value=""{book.DateToString()}""  class=""book-input"" name=""dateEt_{book.BookId}""></td>
                    <td><img src=""{book.Image}"" alt=""Book Image"" class=""book-image""><input type=""text"" value=""{book.Image}""  class=""book-input"" name=""imgEt_{book.BookId}""></td>
                    <td><button type=""submit"" name=""action"" value=""Edit""  class=""edit-button"">Edit</a></td>
                    <td><a href=""RemoveBook.aspx?id={book.BookId}"" class=""delete-button"">Delete</a></td>
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

        private void BindSelectedPublisher()
        {
            var publishers = _booksRepository.GetAllPublishers();
            foreach (var publisher in publishers)
            {
                publisherId.Items.Add(new ListItem(publisher.PublisherName, publisher.PublisherId.ToString()));
            }
            publisherId.Attributes["name"] = "publisherId";
        }

        private void CreateProduct()
        {
            string bookName = Request.Form.Get("bookName");
            string author = Request.Form.Get("author");
            int publisher = Convert.ToInt32(publisherId.Value);
            decimal price = Convert.ToDecimal(Request.Form.Get("price"));
            string description = Request.Form.Get("description");
            string language = Request.Form.Get("language");
            DateTime publicationDate = Convert.ToDateTime(Request.Form.Get("publicationDate"));
            int readingAge = Convert.ToInt32(Request.Form.Get("readingAge"));
            int printLength = Convert.ToInt32(Request.Form.Get("printLength"));
            string dimension = Request.Form.Get("dimensions");
            string image = Request.Form.Get("image");
            Book book = new Book
            {
                BookName = bookName,
                Author = author,
                PublisherId = publisher,
                Price = price,
                Description = description,
                Language = language,
                PublicationDate = publicationDate,
                ReadingAge = readingAge,
                PrintLength = printLength,
                Dimensions = dimension,
                Image = image
            };
            _booksRepository.CreateBook(book);
            Session[Constants.Success] = "Create book success";
            Response.Redirect("AdminHome.aspx");
        }
    }
}