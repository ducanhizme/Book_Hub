using System;
using System.Web.UI;
using BookHub.data.Repository;
using BookHub.Ultis;

namespace BookHub
{
    public partial class CartProduct : Page
    {
        private BooksRepository _booksRepository;
        private CartRepository _cartRepository;
        private Int32? _userId;

        protected void Page_Load(object sender, EventArgs e)
        {
            _booksRepository = new BooksRepository();
            _cartRepository = new CartRepository();
            _userId = Convert.ToInt32(Session[Constants.Authenticated]);
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            var cart = _cartRepository.GetCartByUserId(Convert.ToInt32(_userId));   
            var cartItems = _cartRepository.GetCartItemsByUserId(Convert.ToInt32(_userId));
            decimal sum = 0;

            foreach (var cartItem in cartItems)
            {
                var book = _booksRepository.GetBookById(cartItem.BookId);
                decimal itemTotal = book.Price * cartItem.Quantity; 
                sum += itemTotal; 
                Console.WriteLine("quanity: "+cartItem.Quantity);
                Console.WriteLine("sum: "+sum);
                string html = $@"
            <div class=""cart-item"">
                <img src={book.Image} alt={book.BookName} class=""cart-item-image"">
                <div class=""cart-item-content-wrapper"">
                    <div class=""cart-item-describe"">
                        <div class=""cart-item-detail"">
                            <h4 class=""cart-item-title"">{book.BookName}</h4>
                            <p class=""cart-item-author"">{book.Author}</p>
                            <div class=""quantity"">
                                <button class=""outline-button"" type=""button"" id=""decrease"">-</button>
                                <input type=""text"" value={cartItem.Quantity} name=""quantity"" id=""quantity"">
                                <button class=""outline-button"" type=""button"" id=""increase"">+</button>
                            </div>
                        </div>
                        <p class=""cart-item-price"">{book.Price * cartItem.Quantity}</p>
                    </div>
                    <button class=""cart-item-remove outline-button"" type=""button"">Remove</button>
                </div>
            </div>";
                cartList.InnerHtml += html;
            }
            totalPrice.InnerHtml = $"{sum}";
            checkOut.HRef=$"/Checkout.aspx?id={cart.CartId}";
        }
    }
}