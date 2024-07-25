using System;
using System.Web.UI;

namespace BookHub.Ultis
{
    public class AuthorizationPage : Page
    {
        public object AuthenticatedUserId;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            AuthenticatedUserId = Session[Constants.Authenticated];
            if (AuthenticatedUserId == null)
            {
                Console.WriteLine("In AuthorizationPage");
                Session[Constants.Error] = "You need to login to continue";
                Response.Redirect("Login.aspx");
            }
        }
    }
}