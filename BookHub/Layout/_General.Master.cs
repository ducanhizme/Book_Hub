using BookHub.Ultis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookHub.Layout
{
    public partial class _General : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ShowToastMessage(Constants.Error, "red");
            ShowToastMessage(Constants.Success, "green");
            UpdateAuthenticationStatus();
        }

        private void ShowToastMessage(string sessionKey, string backgroundColor)
        {
            if (Session[sessionKey] != null)
            {
                string message = Session[sessionKey].ToString();
                simpleToast.InnerHtml = $"<span>{message}</span>";
                simpleToast.Attributes.Add("class", "show");
                if (!string.IsNullOrEmpty(backgroundColor))
                {
                    simpleToast.Style.Add("background-color", backgroundColor);
                }
                Session.Remove(sessionKey);
            }
        }

        private void UpdateAuthenticationStatus()
        {
            if (Session[Constants.Authenticated] != null)
            {
                authentication.HRef = "Profile.aspx";
                authentication.InnerText = "Profile";
            }
        }
    }
}