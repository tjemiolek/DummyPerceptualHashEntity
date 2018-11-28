namespace DummyPerceptualProj.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class DummyPerceptualCont : DbContext
    {
        public DummyPerceptualCont()
            : base("name=DummyPerceptualCont")
        {
        }

        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }
        public string path { get; set; }
        public string dph { get; set; }
        public string md5 { get; set; }
        public virtual User User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual List<Image> Images { get; set; }
    }

}