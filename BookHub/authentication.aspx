<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="authentication.aspx.cs" Inherits="BookHub.authentication" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Đăng nhập hoặc đăng ký tài khoản BookHub của bạn.">
    <title>Authentication Page</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Anton&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../css/authentication.css">
</head>
<body>
    <main>
        <div class="container">
            <div class="form-container">
               <div class="form-container">
            <form style="display: flex; width: 100%" runat="server">
                <div id="loginForm" class="form end">
                    <p class="welcome-describe">Login to your account</p>
                    <div class="input-group">
                        <label for="email_login">Email</label>
                        <asp:TextBox ID="email_login" runat="server" placeholder="Email"></asp:TextBox>
                    </div>  
                    <div class="input-group">
                          <label for="password_login">Password</label>
                        <asp:TextBox ID="password_login" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                    </div>
                    <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass="filled-button" OnClick="LoginBtn_Click" />
                    <button type="button" id="switchToRegister" class="outline-button">Register</button>
                </div>
                <div id="registerForm" class="form">
                    <asp:Label ID="errorLabel" runat="server" Text="" CssClass="error_conatainer" Visible="false"></asp:Label>
                    <p class="welcome-describe">Register to continue</p>
                    <div class="input-group">
                        <label for="name">Name</label>
                        <asp:TextBox ID="name" runat="server" placeholder="Your name"></asp:TextBox>
                    </div>
                    <div class="input-group">
                       <label for="email_register">Email</label>
                        <asp:TextBox ID="email_register" runat="server" placeholder="Email"></asp:TextBox>
                    </div>
                    <div class="input-group">
                        <label for="password_register">Password</label>
                        <asp:TextBox ID="password_register" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                    </div>
                    <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="filled-button" OnClick="RegisterBtn_Click" />
                    <button type="button" id="switchToLogin" class="outline-button">Login</button>
                </div>
            </form>
        </div>
            </div>
            <div id="overlay">
                <h1 class="logo">BookHub</h1>
                <div class="welcome-container">
                    <p>Welcome to our book store</p>
                    <p>Sign in or sign up to continue</p>
                </div>
            </div>
        </div>
    </main>
    <script src="../js/authentication.js"></script>
</body>
</html>
