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

            modelBuilder.Entity<Contact>().HasData(
                new Contact() { ContactID=1,Name="Josip", LastName="Zelić", Address="Crikvenička 2/1", TagID=1 },
                new Contact() { ContactID = 2,Name = "Ive", LastName = "Vasiljević", Address = "Ruđera Boškovića 29", TagID = 2 },
                new Contact() { ContactID = 3, Name = "Ivan", LastName = "Torbarina", Address = "Debeljak bb", TagID = 2 },
                new Contact() { ContactID = 4, Name = "Marko", LastName = "Krpan", Address = "Miroslava Kraljevića 20", TagID = 2 },
                new Contact() { ContactID = 5, Name = "Nela", LastName = "Jakešević", Address = "Osječka 18", TagID = 3 },
                new Contact() { ContactID = 6, Name = "Petar", LastName = "Butorac", Address = "S.S Kranjčevića 12", TagID = 3 }
                   );

           

            modelBuilder.Entity<Mail>().HasData(
                new Mail() { MailID=1, ContactID= 1, MailAddress="jzelic@gmail.com" },
                new Mail() { MailID = 2, ContactID = 1, MailAddress = "zelic@fesb.hr" },
                new Mail() { MailID = 3, ContactID = 2, MailAddress = "ivasil@gmail.com" },
                new Mail() { MailID = 4, ContactID = 3, MailAddress = "itoroba@fgag.hr" },
                new Mail() { MailID = 5, ContactID = 4, MailAddress = "krpica@hotmail.com" },
                new Mail() { MailID = 6, ContactID = 5, MailAddress = "nelaj@outlook.com" },
                new Mail() { MailID = 7, ContactID = 6, MailAddress = "pbutorac@outlook.com" },
                new Mail() { MailID = 8, ContactID = 6, MailAddress = "pb1006@yahoo.com" }

                );

            modelBuilder.Entity<Number>().HasData(
                    new Number() { NumberID=1 ,ContactID=  1, PhoneNumber = "0996993858" },
                    new Number() { NumberID = 2,ContactID = 2, PhoneNumber = "0991234562"  },
                    new Number() { NumberID = 3,ContactID = 3, PhoneNumber = "0984568823" },
                    new Number() { NumberID = 4,ContactID = 4, PhoneNumber = "0912213486" },
                    new Number() { NumberID = 5,ContactID = 5, PhoneNumber = "0914459121"  },
                    new Number() { NumberID = 6,ContactID = 6, PhoneNumber = "0981283221" }
                );

            
        }
    }
}
