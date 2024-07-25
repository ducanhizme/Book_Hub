using BookHub.data.Models;
using BookHub.data.Repository;
using System;
using System.Collections.Generic;
using BookHub.Ultis;


namespace BookHub
{
    public partial class Home : System.Web.UI.Page
    {
        private BooksRepository _booksRepository;
        private CategoryRepository _categoryRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _booksRepository = new BooksRepository();
            _categoryRepository = new CategoryRepository();
            if (!IsPostBack)
            {
                
                BindBooks();
                BindCategory();
            }
            
        }

        private void BindBooks()
        {
            List<Book> books = _booksRepository.GetAllBooks();
            foreach (Book book in books)
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
                bookContainer.InnerHtml += html;

            }
        }

        private void BindCategory()
        {
            String wrapper = "";
            String innerProduct = "";
            int maxCategoryDisplay = 3;
            List<Category> categories = _categoryRepository.GetAllCategories();
            Dictionary<int, List<Book>> bookCategory = new Dictionary<int, List<Book>>();
            foreach (Category category in categories)
            {
                List<Book> books = _booksRepository.GetBooksByCategoryId(category.CategoryId);
                bookCategory.Add(category.CategoryId, books);
            }
            for (int i = 0; i < Math.Min(categories.Count, maxCategoryDisplay); i++)
            {
                
                foreach(Book book in bookCategory[categories[i].CategoryId])
                {
                    innerProduct+= $@"
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
                }
                wrapper += $@"<div class=""product-container padding-inline-l"">
                                <h2>{categories[i].CategoryName}</h2>
                                <div class=""slider-wrapper swiper"">
                                    <div id=""{categories[i].CategoryName}_list"" class=""product-list swiper-wrapper"" runat=""server"">
                                        {innerProduct}
                                    </div>
                                </div>
                            </div>";
            }
            catgory_section.InnerHtml = wrapper;
        }

    }
}