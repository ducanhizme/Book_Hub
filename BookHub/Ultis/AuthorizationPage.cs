﻿using System;
using System.Web.UI;
using BookHub.data.Models;

namespace BookHub.Ultis
{
    public class AuthorizationPage : Page
    {
        public object AuthenticatedUserId;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            User authenticatedUser = Session[Constants.Authenticated] as User;
            AuthenticatedUserId = authenticatedUser?.UserId;
            if (AuthenticatedUserId == null)
            {
                Console.WriteLine("In AuthorizationPage");
                Session[Constants.Error] = "You need to login to continue";
                Response.Redirect("Login.aspx");
            }
        }
    }
}