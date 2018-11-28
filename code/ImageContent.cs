using DummyPerceptualProj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DummyPerceptualProj.code
{
    public static class ImageContent
    {
        public static List<Models.Image> GetImages(int userId)
        {
            List<Models.Image> imgs = new List<Image>();

            using (var db = new DummyPerceptualCont())
            {
                var myQry = from image in db.Images
                            where image.User.Id == userId
                            select image;

                foreach (var item in myQry)
                {
                    Models.Image img = new Models.Image {Id = item.Id, path = item.path, md5 = item.md5, dph = item.dph };
                    imgs.Add(img);
                }
                return imgs;
            }
        }

        public static void SaveImage(int userId, string path, string dph, string md5)
        {
            using (var db = new DummyPerceptualCont())
            {
                User user = null;

                var result = from u in db.Users
                             where u.Id == userId
                             select u;

                foreach (var item in result)
                {
                    user = item as User;
                }

                var images = db.Set<Image>();
                images.Add( new Models.Image {  dph = dph, md5 = md5, path = path, User = user });
 
                db.SaveChanges();

            }
        }

        public static List<String> GetSimilarImages(string dummyPerceptualHash)
        {
            List<string> paths = new List<string>();

            using (var db = new DummyPerceptualCont())
            {
                var clientIdParameter = new SqlParameter("@param1", dummyPerceptualHash);

                var procedureResult = db.Database.SqlQuery<String>("sp_get_similar_photo @param1", clientIdParameter);

                foreach (string result in procedureResult)
                {
                    paths.Add(result);
                }
            }
            return paths;
        }

        public static Image GetImage(int imageId)
        {
            List<Models.Image> imgs = new List<Image>();

            using (var db = new DummyPerceptualCont())
            {
                var myQry = from image in db.Images
                            where image.Id == imageId
                            select image;

                foreach (var item in myQry)
                {
                    Models.Image img = new Models.Image { path = item.path, md5 = item.md5, dph = item.dph };
                    imgs.Add(img);
                }

                return imgs.First();
            }
        }
    }
}