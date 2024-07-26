using System;
using System.Web.UI;
using BookHub.Ultis;

namespace BookHub.Layout
{
    public partial class _AdminLayout : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateAuthenticationStatus();
        }
        
        private void UpdateAuthenticationStatus()
        {
            if (Session[Constants.Authenticated] != null)
            {
                authentication.InnerText = "Log Out";
                Console.WriteLine("Layout: "+Session[Constants.Authenticated]);
            }
        }
    }
}