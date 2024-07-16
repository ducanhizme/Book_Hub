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
        private UserRepository userRepository;
        protected void Page_Load(object sender, EventArgs e)
        {
            userRepository= new UserRepository();
            if (IsPostBack)
            {
                string email = Request.Form.Get("email");
                string password = Request.Form.Get("password");
                bool isAuthenticated = userRepository.AuthenticateUser(email, password);

                if (isAuthenticated)
                {
                    
                    Session[Constants.Success] = "Login success. Welcome to BookHub";
                    var userAuthenticated = userRepository.FindUserByEmail(email);
                    Session[Constants.Authenticated] = userAuthenticated.UserId;
                    if (userAuthenticated.Role == "Admin")
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
                    Session[Constants.Error] = "Bad Credential";
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}