<%@ Page Language="C#" CodeBehind="CartProduct.aspx.cs" Inherits="BookHub.CartProduct" MasterPageFile="~/Layout/_General.Master" %>

<asp:Content runat="server" ID="CartContent" ContentPlaceHolderID="MainContent">
    <section class="shopping-cart-container">
        <div class="cart-list" id="cartList" runat="server">
        </div>
        <div class="checkout-box">
            <div class="total-price">
                <h4>Total Price:</h4>
                <p id="totalPrice" runat="server"></p>
            </div>
            <div class="input-field">
                <input type="text" required name="email">
                <label>Address</label>
            </div>
            <div class="input-field">
                <input type="password" required name="password">
                <label>Phone Number</label>
            </div>
            <a id="checkOut" class="filled-button" runat="server">Checkout</a>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="Head" ContentPlaceHolderID="Head">
    <link rel="stylesheet" href="css/cart.css">
</asp:Content>