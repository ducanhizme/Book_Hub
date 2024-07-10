using BookHub.data.Models;
using BookHub.data;
using BookHub.data.Repository;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace BookHub
{
    public partial class authentication : System.Web.UI.Page
    {
        private UserRepository userRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            userRepository = new UserRepository();
            if (Session["AuthenticationError"] != null)
            {
                errorLabel.Visible = true;
                errorLabel.Text = Session["AuthenticationError"]?.ToString();
                Session.Remove("AuthenticationError");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = email_login.Text.Trim();
            string password = password_login.Text.Trim();
            bool isAuthenticated = userRepository.AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                var userAuthenticated = userRepository.FindUserByEmail(email);
                if(userAuthenticated.Role == "Admin")
                {
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Redirect("Home.aspx");
                }
                
            }
            else
            {
                Response.Redirect("Authentication.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string userName = name.Text.Trim();
            string email = email_register.Text.Trim();
            string password = password_register.Text.Trim();

            if (IsValidEmail(email) && IsValidPassword(password))
            {
                bool registerState = userRepository.RegisterUser(email, password, userName);
                if (!registerState)
                {
                    Session["AuthenticationError"] = "Email already exists";
                    Response.Redirect("Authentication.aspx");
                }
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Authentication.aspx");
            }
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(emailPattern);
           if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                Session["AuthenticationError"] = "Invalid Email";
                return false;

            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
            {
  
                Session["AuthenticationError"] = "Password must be at least 8 characters long";
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                Session["AuthenticationError"] = "Password must contain at least one uppercase letter";
                return false;
            }
            if (!password.Any(char.IsLower))
            {
                Session["AuthenticationError"] = "Password must contain at least one lowercase letter";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Session["AuthenticationError"] = "Password must contain at least one digit";
                return false;
            }
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                Session["AuthenticationError"] = "Password must contain at least one special character";
                return false;
            }

            return true;
        }
    }
}