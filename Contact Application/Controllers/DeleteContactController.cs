using Contact_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
    [ApiController]
    [Route("api/delete")]
    //ovo samo kao api definirat jer nema potrebe za viovom
    public class DeleteContactController : Controller
    {
        private readonly DatabaseContext _db;
        public DeleteContactController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpDelete]
        public JsonResult Delete(int UserID)
        {
            User user = _db.User.Where(p => p.UserID == UserID)
                                .Include(p => p.Mail)
                                .Include(p => p.Number)
                                .FirstOrDefault();

            _db.Remove(user);
            _db.SaveChanges();
                      
            return new JsonResult("");
        }
    }
}
