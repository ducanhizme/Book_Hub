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
        private UserRepository userRepository;
        private String username;
        private String password;
        private String email;
        private String confirmPassword;
        public const String AUTHENTICATION_ERROR = "AuthenticationError";
        protected void Page_Load(object sender, EventArgs e)
        {

        userRepository = new UserRepository();
            if (IsPostBack)
            {
                username = Request.Form["user_name"];
                email = Request.Form["email"];
                password = Request.Form["password"];
                confirmPassword = Request.Form["confirm_password"];
                if (UserRegister(username,password,confirmPassword,email))
                {
                    if (IsValidEmail(email) && IsValidPassword(password, confirmPassword))
                    {
                        if (!userRepository.RegisterUser(email, password, username))
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
                Session[AUTHENTICATION_ERROR] = "Password must contain at least one lowercase letter";
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Session[Constants.Error] = "Password must contain at least one digit";
                return false;
            }
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
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
