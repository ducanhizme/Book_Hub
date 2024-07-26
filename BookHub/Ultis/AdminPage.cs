using System;
using System.Web.UI;
using BookHub.data.Models;

namespace BookHub.Ultis
{
    public class AdminPage :Page
    {
        public object AuthenticatedUserId;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            User authenticatedUser = Session[Constants.Authenticated] as User;
            AuthenticatedUserId = authenticatedUser?.UserId;
            if (AuthenticatedUserId == null)
            {
                Session[Constants.Error] = "You need to login to continue";
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (authenticatedUser != null)
                {
                    if (authenticatedUser.Role != "Admin")
                    {
                        Session[Constants.Error] = "You are not authorized to access this page";
                        Response.Redirect("Home.aspx");
                    }
                }
            }
        }
    }
}