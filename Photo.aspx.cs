using DummyPerceptualProj.App_Code;
using DummyPerceptualProj.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DummyPerceptualProj
{
    public partial class Photo : BasePage
    {
        int photoId = 0;
        List<String> imageList;
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlId = Request.QueryString["Id"];
            if (urlId != null)
            {
                imageList = new List<string>();
                photoId = Int32.Parse(urlId);
                Models.Image choosenImage = ImageContent.GetImage(photoId);

                if(choosenImage != null)
                {
                    System.Web.UI.WebControls.Image mainImg = new System.Web.UI.WebControls.Image();
                    mainImg.ImageUrl = choosenImage.path.Trim();
                    MainPhoto.Controls.Add(mainImg);

                    imageList = ImageContent.GetSimilarImages(choosenImage.dph);
                }

                Panel p = new Panel();
                p.CssClass = "ImageClass";

                if (imageList.Count > 0)
                {
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        img.CssClass = "img-thumbnail";
                        img.ImageUrl = imageList[i].Trim();
                        p.Controls.Add(img);
                    }
                }
                SimilarPhoto.Controls.Add(p);

            }

        }
    }
}
