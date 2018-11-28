using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DummyPerceptualProj
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserId"] != null)
            {
                Response.Redirect("MyGallery.aspx");
            }
            else
            {
                Response.Redirect("LoginAuthorization.aspx");
            }
        }
    }
}