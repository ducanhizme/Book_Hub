<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookHub.Login" MasterPageFile="~/Layout/_General.Master" %>

<asp:Content runat="server" ID="RegisterContent" ContentPlaceHolderID="MainContent">
    <section>
        <div class="wrapper">
            <form action="Login.aspx" method="post" runat="server">
                <h2>Login</h2>
                <div class="input-field">
                    <input type="text" required name="email">
                    <label>Enter your email</label>
                </div>
                <div class="input-field">
                    <input type="password" required name="password">
                    <label>Enter your password</label>
                </div>
                <div class="option-input">
                    <label for="check">
                        <input type="checkbox" id="check">
                        <p>Remember me</p>
                    </label>
                    <a href="#">Forgot password?</a>
                </div>
                <button type="submit">Log In</button>
                <div class="switch">
                    <p>Don't have an account? <a href="Register.aspx">Register</a></p>
                </div>
            </form>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
/>
     <link href="css/style.css" rel="stylesheet" />
<link href="css/authentication.css" rel="stylesheet" />
</asp:Content>
