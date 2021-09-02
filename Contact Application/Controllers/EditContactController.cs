using Contact_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
    public class EditContactController : Controller
    {
        private readonly DatabaseContext _db;
        public EditContactController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpPut]
        public JsonResult EditContact(int id,[FromBody]User user)
        {
            if (id != user.UserID)
                return new JsonResult("Krivi id");

            _db.Entry(user).State = EntityState.Modified;

            _db.SaveChanges();

            return new JsonResult("Sve proslo");
        }
        [HttpGet]
        public IActionResult GetContact(int id)
        {


            User user = _db.User.Where(p => p.UserID == id)
                               .Include(p => p.Mail)
                               .Include(p => p.Number)
                               .FirstOrDefault();

            return new JsonResult(user);
        }
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}
