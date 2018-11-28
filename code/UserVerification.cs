using DummyPerceptualProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DummyPerceptualProj.code
{
    public static class UserVerification
    {
        public static bool VerifyUser(string name, string password)
        {
            int id = 0;

            using (var db = new DummyPerceptualCont())
            {
                var myQry = from user in db.Users
                            where user.Login == name && user.Password == password
                            select user.Id;

                var result = "";
                
                foreach (var item in myQry)
                {
                    result = item.ToString();
                }

                if (result != null)
                {
                    id = Convert.ToInt32(result);
                    HttpContext.Current.Session["UserId"] = id;
                    return true;
                }
            }
            return false;

        }
    }
}