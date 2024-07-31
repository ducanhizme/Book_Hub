using System;
using System.Web.UI;
using BookHub.Ultis;

namespace BookHub.Layout
{
    public partial class _AdminLayout : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowToastMessage(Constants.Error, "red");
            ShowToastMessage(Constants.Success, "green");
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
        
        private void ShowToastMessage(string sessionKey, string backgroundColor)
        {
            if (Session[sessionKey] != null)
            {
                string message = Session[sessionKey].ToString();
                simpleToast.InnerHtml = $"<span>{message}</span>";
                Session.Remove(sessionKey);
                simpleToast.Attributes.Add("class", "show");
                simpleToast.Style.Add("background-color", backgroundColor);
                
            }
        }
    }
}