using BookHub.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookHub
{
    public partial class BookDetail : System.Web.UI.Page
    {
        private string bookId;
        private BooksRepository booksRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            booksRepository = new BooksRepository();
            bookId = Request.QueryString["id"];
            Response.Write(booksRepository.GetBookByID(int.Parse(bookId)).BookName);
           
        }
    }
}