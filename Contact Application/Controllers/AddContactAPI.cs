using Contact_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
    
    [ApiController]
    public class AddContactAPI : ControllerBase
    {
        private readonly DatabaseContext _db;
        public AddContactAPI(DatabaseContext db)
        {
            _db = db;
        }

        [Route("api/AddContact")]
        [HttpPost]
        public JsonResult AddContact([FromBody]UserDTO user)
        {
            User newUser = new User
            {
                Name = user.Name,
                Address = user.Address,
                LastName= user.LastName,              
                TagID=user.TagID
                
            };

            newUser.Mail = new List<Mail>();
            newUser.Number = new List<Number>();        

            _db.User.Add(newUser);

            
            _db.SaveChanges();

            int userId = newUser.UserID;

            
            foreach (Mail mail in user.Mail)
            {
                if (mail.MailAddress != null)
                {
                    mail.UserID = newUser.UserID;
                    newUser.Mail.Add(mail);
                }
            }

            foreach (Number number in user.Number)
            {
                if(number.PhoneNumber != null)
                number.UserID = newUser.UserID;
                newUser.Number.Add(number);
            }

            _db.SaveChanges();

            return new JsonResult(user);
        }
    }
}
