using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DummyPerceptualProj.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
        protected int userID;

        private void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserId"] != null)
            {
                userID = (int)HttpContext.Current.Session["UserId"];
            }
            else
            {
                Response.Redirect("LoginAuthorization.aspx");
            }
        }
        public BasePage()
        {
            this.Load += new EventHandler(Page_Load);
        }
    }
}