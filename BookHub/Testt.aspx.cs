using System;
using System.Web.UI;
using BookHub.Ultis;

namespace BookHub
{
    public partial class Testt : AuthorizationPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("In Testt");
        }
    }
}