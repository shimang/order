using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QCloud.WeApp.Demo.MVC.Models
{
    public class User
    {
        public int ID { get; set; }
        public string OpenID { get; set; }
        public string NickName { get; set; }
        public bool IsValid { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }  
    }
}   