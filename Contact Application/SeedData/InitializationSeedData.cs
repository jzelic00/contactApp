using Contact_Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.SeedData
{
    public static class InitializationSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
               new Tag() { TagID = 1,TagName = "Obitelj" },
               new Tag() { TagID = 2,TagName = "Prijatelj" },
               new Tag() { TagID = 3,TagName = "Posao" }
                  );

            modelBuilder.Entity<User>().HasData(
                new User() { UserID=1,Name="Josip", LastName="Zelić", Address="Crikvenička 2/1", TagID=1 },
                new User() { UserID = 2,Name = "Ive", LastName = "Vasiljević", Address = "Ruđera Boškovića 29", TagID = 2 },
                new User() { UserID = 3, Name = "Ivan", LastName = "Torbarina", Address = "Debeljak bb", TagID = 2 },
                new User() { UserID = 4, Name = "Marko", LastName = "Krpan", Address = "Miroslava Kraljevića 20", TagID = 2 },
                new User() { UserID = 5, Name = "Nela", LastName = "Jakešević", Address = "Osječka 18", TagID = 3 },
                new User() { UserID = 6, Name = "Petar", LastName = "Butorac", Address = "S.S Kranjčevića 12", TagID = 3 }
                   );

           

            modelBuilder.Entity<Mail>().HasData(
                new Mail() { MailID=1, UserID= 1, MailAddress="jzelic@gmail.com" },
                new Mail() { MailID = 2, UserID = 1, MailAddress = "zelic@fesb.hr" },
                new Mail() { MailID = 3, UserID = 2, MailAddress = "ivasil@gmail.com" },
                new Mail() { MailID = 4, UserID = 3, MailAddress = "itoroba@fgag.hr" },
                new Mail() { MailID = 5, UserID = 4, MailAddress = "krpica@hotmail.com" },
                new Mail() { MailID = 6, UserID = 5, MailAddress = "nelaj@outlook.com" },
                new Mail() { MailID = 7, UserID = 6, MailAddress = "pbutorac@outlook.com" },
                new Mail() { MailID = 8, UserID = 6, MailAddress = "pb1006@yahoo.com" }

                );

            modelBuilder.Entity<Number>().HasData(
                    new Number() { NumberID=1 ,UserID=  1, PhoneNumber = "0996993858" },
                    new Number() { NumberID = 2,UserID = 2, PhoneNumber = "0991234562"  },
                    new Number() { NumberID = 3,UserID = 3, PhoneNumber = "0984568823" },
                    new Number() { NumberID = 4,UserID = 4, PhoneNumber = "0912213486" },
                    new Number() { NumberID = 5,UserID = 5, PhoneNumber = "0914459121"  },
                    new Number() { NumberID = 6,UserID = 6, PhoneNumber = "0981283221" }
                );

            
        }
    }
}
