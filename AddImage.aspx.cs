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
    public partial class AddImage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveFileButton_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                FileUpload.SaveAs(Server.MapPath("appends\\" + FileUpload.FileName));

                string md5 = Md5Encoder.EncodeMD5(Server.MapPath("appends\\" + FileUpload.FileName));
                byte randomDPH = DPHGenerator.GenerateDPH();
                string stringRandomDPH = ByteConverter.ByteToBinaryString(randomDPH);

                ImageContent.SaveImage(userID, "appends\\" + FileUpload.FileName, stringRandomDPH, md5);

                Response.Redirect("MyGallery.aspx");
            }
        }
    }
}