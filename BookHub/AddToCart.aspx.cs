using System;
using System.Web.UI;
using BookHub.data.Repository;
using BookHub.Ultis;
using Mysqlx.Datatypes;

namespace BookHub
{
    public partial class AddToCart : Page
    {
        private String _bookId;
        private Int32? _userId;
        private BooksRepository _booksRepository;
        private CartRepository _cartRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _booksRepository = new BooksRepository();
            _cartRepository = new CartRepository();
            _userId = Convert.ToInt32(Session[Constants.Authenticated]);
            _bookId = Request.QueryString["id"];
            if (_bookId ==null)
            {
                Session[Constants.Error]="Some thing went wrong";
                Response.Redirect("Home.aspx");
            }
            if(Session[Constants.Authenticated] == null)
            {
                Session[Constants.Error] = "Please login to add to cart";
                Session[Constants.Cart] = _bookId;
                Response.Redirect("Login.aspx");
            }
            String quantity = Request.Form.Get("quantity");
            if (quantity == null)
            {
                Session[Constants.Error] = "Please login to add to cart";
                Response.Redirect($"BookDetails.aspx?id={_bookId}");
            }
            else
            {
                _cartRepository.AddToCart(Convert.ToInt32(_userId), Convert.ToInt32(_bookId), Convert.ToInt32(quantity));
                Session[Constants.Success] = "Add to cart success";
                Response.Redirect($"BookDetails.aspx?id={_bookId}");
            }
            

        }
    }
}