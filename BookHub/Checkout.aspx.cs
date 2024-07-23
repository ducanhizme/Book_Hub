using System;
using System.Web.UI;
using BookHub.data.Repository;

namespace BookHub
{
    public partial class Checkout : Page
    {
        private CartRepository _cartRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _cartRepository = new CartRepository();
            String id = Request.QueryString["id"];
            if(id == null)
            {
                Session["Error"] = "Some thing went wrong";
                Response.Redirect("Cart.aspx");
            }
            else
            {
                _cartRepository.RemoveAllCartItemsByCartId(Convert.ToInt32(id));
                Response.Redirect("Home.aspx");
            }
        }
    }
}