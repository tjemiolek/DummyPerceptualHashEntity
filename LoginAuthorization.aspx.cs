using DummyPerceptualProj.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DummyPerceptualProj.App_Code;

namespace DummyPerceptualProj
{
    public partial class LoginAuthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (UserVerification.VerifyUser(LoginControl.UserName, LoginControl.Password))
            {
                Response.Redirect("MyGallery.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void Login_LoginError(object sender, EventArgs e)
        {
            LoginControl.FailureText = "Błędne hasło lub login.";
        }
    }
}