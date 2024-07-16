<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BookHub.Register" MasterPageFile="~/Layout/_General.Master"%>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <section>
       <div class="wrapper">
    <form action="Register.aspx" method="post" runat="server">
      <h2>Register</h2>
          <div class="input-field">
  <input type="text" required name="user_name">
  <label>Enter your username</label>
</div>
        <div class="input-field">
        <input type="text" required name="email">
        <label>Enter your email</label>
      </div>
      <div class="input-field">
        <input type="password" required name="password">
        <label>Enter your password</label>
      </div>
        <div class="input-field">
  <input type="password" required name="confirm_password">
  <label>Enter your confirm password</label>
</div>
      <div class="option-input">
        <label for="check">
          <input type="checkbox" id="check">
          <p>Agree with terms </p>
        </label>
      </div>
      <button type="submit">Register</button>
      <div class="switch">
        <p>Already have an account? <a href="Login.aspx">Login</a></p>
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