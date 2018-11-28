using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DummyPerceptualProj.App_Code;
using DummyPerceptualProj.code;

namespace DummyPerceptualProj
{
    public partial class MyGallery : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            List<Models.Image> imageList = ImageContent.GetImages(userID);

            Panel imagePanel = new Panel();
            imagePanel.CssClass = "ImageClass";

            if (imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                    img.CssClass = "img-thumbnail";
                    img.ImageUrl = imageList[i].path.Trim();
                    img.Attributes.Add("base-index", imageList[i].Id.ToString());
                    string redirectUrl = "Photo.aspx?id=" + imageList[i].Id.ToString();
                    img.Attributes.Add("onclick", "window.location(" + "'" + redirectUrl + "'" + ")");
                    imagePanel.Controls.Add(img);
                }
            }
            GalleryBodyPanel.Controls.Add(imagePanel);
        }
    }
}