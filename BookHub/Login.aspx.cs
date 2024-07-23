using BookHub.data.Repository;
using BookHub.Ultis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookHub
{
    public partial class Login : System.Web.UI.Page
    {
        private UserRepository _userRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userRepository= new UserRepository();
            if (IsPostBack)
            {
                string email = Request.Form.Get("email");
                string password = Request.Form.Get("password");
                bool isAuthenticated = _userRepository.AuthenticateUser(email, password);

                if (isAuthenticated)
                {
                    
                    Session[Constants.Success] = "Login success. Welcome to BookHub";
                    var userAuthenticated = _userRepository.FindUserByEmail(email);
                    Session[Constants.Authenticated] = userAuthenticated.UserId;
                    
                    Console.WriteLine("Login Page - Session Authenticated set: " + Session[Constants.Authenticated]);

                    if (userAuthenticated.Role == "Admin")
                    {
                       
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                        if(Session[Constants.Cart] != null)
                        {
                            Response.Redirect($"AddToCart.aspx?id={Session[Constants.Cart]}");
                        }
                        else
                        {
                            Response.Redirect("Home.aspx");
                        }
                    }
                }
                else
                {
                    Session[Constants.Error] = "Bad Credential";
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}