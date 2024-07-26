using System;
using System.Web.UI;
using BookHub.data.Repository;
using BookHub.Ultis;
using Mysqlx.Datatypes;

namespace BookHub
{
    public partial class CartAction : AuthorizationPage
    {
        private String _bookId;
        private Int32? _userId;
        private CartRepository _cartRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _cartRepository = new CartRepository();
            _userId = Convert.ToInt32(AuthenticatedUserId);
            _bookId = Request.QueryString["id"];
            if (_bookId ==null)
            {
                Session[Constants.Error]="Some thing went wrong";
                Response.Redirect("Home.aspx");
            }
            String quantity = Request.Form.Get("quantity");
            if (quantity == null && Request.QueryString["action"] != "delete")
            {
                Session[Constants.Error] = "Some thing went wrong";
                Response.Redirect($"BookDetails.aspx?id={_bookId}");
            }
            else
            {
                Console.WriteLine("action: "+Request.QueryString["action"]);
                switch(Request.QueryString["action"])
                {
                    case "add":
                        _cartRepository.AddToCart(Convert.ToInt32(_userId), Convert.ToInt32(_bookId), Convert.ToInt32(quantity),false);
                        Session[Constants.Success] = "Add to cart success"; 
                        Response.Redirect($"BookDetails.aspx?id={_bookId}");
                        break;
                    case "update":
                        _cartRepository.AddToCart(Convert.ToInt32(_userId), Convert.ToInt32(_bookId), Convert.ToInt32(quantity),true);
                        Session[Constants.Success] = "Update to cart success";
                        Response.Redirect("CartProduct.aspx");
                        break;
                    case "delete":
                        _cartRepository.RemoveCartItem(Convert.ToInt32(_userId), Convert.ToInt32(_bookId));
                        Session[Constants.Success] = "Update to cart success";
                        Response.Redirect("CartProduct.aspx");
                        break;
                    default:
                        Session[Constants.Error] = "Some thing went wrong";
                        Response.Redirect($"BookDetails.aspx?id={_bookId}");
                        break;
                }
            }
            

        }
    }
}