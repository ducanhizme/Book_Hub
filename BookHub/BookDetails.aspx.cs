using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using BookHub.data.Models;
using BookHub.data.Repository;
using BookHub.Ultis;

namespace BookHub
{
    public partial class BookDetails : Page
    {
        private BooksRepository _booksRepository;
        private String _bookId;
        private Book _book;
        private List<int> _categoriesIds;
        protected void Page_Load(object sender, EventArgs e)
        {
            _booksRepository = new BooksRepository();
            _bookId = Request.QueryString["id"];
            if (_bookId ==null)
            {
                Session[Constants.Error]="Book not found";
                Response.Redirect("Home.aspx");
            }
            _book = _booksRepository.GetBookById(Convert.ToInt32(_bookId));
            _categoriesIds = _book.BookCategories?.Select((bc) => bc.CategoryId).ToList();
            if (!IsPostBack)
            {
                if (_bookId != null)
                {
                    BindBookDetails();
                    BindBookRelate();
                }
            }
        }

        private void BindBookRelate()
        {
            List<Book> relatedBooks = _booksRepository.GetBooksByCategoryIds(_categoriesIds);
            foreach (var book in relatedBooks)
            {
                 string html = $@"
                        <a class='product-item swiper-slide' href='BookDetails.aspx?id={book.BookId}'>
                            <img src='{book.Image}' alt=''>
                            <h4>{book.BookName}</h4>
                            <p>{book.Author}</p>
                            <div class='fav-price-container'>
                                <h4>{book.Price}</h4>
                                <button>
                                    <svg xmlns='http://www.w3.org/2000/svg' width='33' height='33' viewBox='0 0 33 33' fill='none'>
                                        <path d='M28.3631 9.79689C27.9902 8.91341 27.4526 8.11281 26.7802 7.43991C26.1073 6.765 25.314 6.22865 24.4434 5.86005C23.5406 5.4763 22.5722 5.27988 21.5946 5.28219C20.2231 5.28219 18.885 5.66648 17.7222 6.39236C17.444 6.566 17.1797 6.75672 16.9293 6.96453C16.6789 6.75672 16.4146 6.566 16.1364 6.39236C14.9736 5.66648 13.6355 5.28219 12.264 5.28219C11.2764 5.28219 10.3194 5.47575 9.41524 5.86005C8.54171 6.2301 7.75441 6.76242 7.0784 7.43991C6.40516 8.11205 5.86735 8.91284 5.49547 9.79689C5.10877 10.7163 4.91125 11.6927 4.91125 12.6976C4.91125 13.6455 5.10043 14.6333 5.47599 15.6381C5.79035 16.4779 6.24103 17.3489 6.81689 18.2285C7.72938 19.6205 8.98404 21.0723 10.5419 22.544C13.1236 24.9835 15.6802 26.6687 15.7887 26.737L16.448 27.1697C16.7401 27.3604 17.1157 27.3604 17.4078 27.1697L18.0671 26.737C18.1756 26.6658 20.7294 24.9835 23.3139 22.544C24.8718 21.0723 26.1264 19.6205 27.0389 18.2285C27.6148 17.3489 28.0682 16.4779 28.3798 15.6381C28.7554 14.6333 28.9446 13.6455 28.9446 12.6976C28.9473 11.6927 28.7498 10.7163 28.3631 9.79689ZM16.9293 24.918C16.9293 24.918 7.02554 18.4249 7.02554 12.6976C7.02554 9.79689 9.37073 7.4456 12.264 7.4456C14.2976 7.4456 16.0613 8.60701 16.9293 10.3036C17.7973 8.60701 19.561 7.4456 21.5946 7.4456C24.4879 7.4456 26.8331 9.79689 26.8331 12.6976C26.8331 18.4249 16.9293 24.918 16.9293 24.918Z' fill='#937DC2'/>
                                    </svg>
                                </button>
                            </div>
                            <button class='filled-button'>Add to cart</button>
                        </a>";
                 relatedBook.InnerHtml += html;
            }
        }
        private void BindBookDetails()
        {
            string html = $@"<div class=""detail-product-image"">
                    <img src={_book.Image} alt=""Book image"">
                </div>
                <div class=""detail-product-info column space-between"">
                    <div class=""main-detail-product-info column"">
                        <h3 class=""detail-product-title"">{_book.BookName}</h3>
                        <p class=""detail-product-author"">{_book.Author}</p>
                        <p class=""detail-product-price"">{_book.Price}</p>
                        <p class=""detail-product-description"">{_book.Description}</p>
                        <div class=""quantity"">
                            <button class=""outline-button"" type=""button"" id=""decrease"">-</button>
                            <input type=""text"" value=""1"" name=""quantity"" id=""quantity"">
                            <button  class=""outline-button"" type=""button"" id=""increase"">+</button>
                        </div>
                        <div  class=""detail-product-button-group"">
                            <button class=""filled-button"" type=""submit"">Add to cart</button>
                            <button class=""outline-button"">Favourite</button>
                        </div>
                    </div>
                </div>
                <div class=""more-detail-product-info-container grid grid-2 column-gap-5"">
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Publisher: </p>
                                            <p class=""more-detail-product-info"">{_book.Publisher.PublisherName}</p>
                                        </div>
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Language: </p>
                                            <p class=""more-detail-product-info"">{_book.Language}</p>
                                        </div>
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Print length: </p>
                                            <p class=""more-detail-product-info"">{_book.PrintLength}</p>
                                        </div>
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Publication date: </p>
                                            <p class=""more-detail-product-info"">{_book.DateToString()}</p>
                                        </div>
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Reading age: </p>
                                            <p class=""more-detail-product-info"">{_book.ReadingAge}</p>
                                        </div>
                                        <div class=""more-details-group"">
                                            <p class=""more-detail-product-title"">Dimensions: </p>
                                            <p class=""more-detail-product-info"">{_book.Dimensions}</p>
                                        </div>
                                    </div>";
            BookDetailContainer.InnerHtml = html;
            BookDetailContainer.Action = $"CartAction.aspx?id={_bookId}&action=add";
            BookDetailContainer.Method = "post";
        }
    }
}