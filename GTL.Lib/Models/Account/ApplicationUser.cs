//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Text;

//namespace GTL.Lib.Models.Account
//{
//    public class ApplicationUser : IdentityUser
//    {
//        [MaxLength(256)]
//        public string FirstName { get; set; }
//        [MaxLength(256)]
//        public string LastName { get; set; }

//        [NotMapped]
//        public string FullName { get { return this.FirstName + " " + this.LastName; } }
//    }

//    public class RoleEnum
//    {
//        public const string Admin = "Admin";
//        public const string User = "User";
//        public const string AdminAndUser = "Admin, User";
//    }
//}
