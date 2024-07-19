using BookHub.data.Repository;
using BookHub.Ultis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace BookHub
{
    public partial class Register : System.Web.UI.Page
    {
        private UserRepository _userRepository;
        private String _username;
        private String _password;
        private String _email;
        private String _confirmPassword;
        public const String AuthenticationError = "AuthenticationError";
        protected void Page_Load(object sender, EventArgs e)
        {

        _userRepository = new UserRepository();
            if (IsPostBack)
            {
                _username = Request.Form["user_name"];
                _email = Request.Form["email"];
                _password = Request.Form["password"];
                _confirmPassword = Request.Form["confirm_password"];
                if (UserRegister(_username,_password,_confirmPassword,_email))
                {
                    if (IsValidEmail(_email) && IsValidPassword(_password, _confirmPassword))
                    {
                        if (!_userRepository.RegisterUser(_email, _password, _username))
                        {
                            Session[Constants.Error] = "Email already exists";
                            Response.Redirect("Register.aspx");
                        }
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Response.Redirect("Register.aspx");
                    }
                }
            }
        }

        public bool UserRegister(String username, String password, String confirmPassword, String email)
        {
            return !(username.IsEmpty() && password.IsEmpty() && confirmPassword.IsEmpty() && email.IsEmpty());

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
                Session[Constants.Error] = "Invalid Email";
                return false;

            }
        }

        private bool IsValidPassword(string password, string confirmPassword)
        {
            if (password.Length < 8)
            {
                Session[Constants.Error] = "Password must be at least 8 characters long";
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                Session[Constants.Error] = "Password must contain at least one uppercase letter";
                return false;
            }
            if (!password.Any(char.IsLower))
            {
                Session[AuthenticationError] = "Password must contain at least one lowercase letter";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Session[Constants.Error] = "Password must contain at least one digit";
                return false;
            }
            if (password.All(char.IsLetterOrDigit))
            {
                Session[Constants.Error] = "Password must contain at least one special character";
                return false;
            }
            if(password != confirmPassword)
            {
                Session[Constants.Error] = "Passwords do not match";
                return false;
            }
            return true;
        }
    }
}
