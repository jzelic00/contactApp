using Contact_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
    //[ApiController]
    //[Route("Home/[Controller]")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _db;
        public HomeController(DatabaseContext db)
        {
            _db = db;
        }

        [Route("Home/GetAllContacts")]
        [HttpGet]
        public JsonResult GetAllContacts()
        {
            //nemoj zab prebacit kasnije u servis ili dataaccess
           
            List<User> allContacts = _db.User.ToList();
            return new JsonResult(allContacts);
        }

        [Route("Home/TagOptions")]
        [HttpGet]
        public JsonResult TagOptions()
        {
            //nemoj zab prebacit kasnije u servis ili dataaccess

            List<Tag> allTags = _db.Tag.ToList();
            return new JsonResult(allTags);
        }

        public IActionResult Index()
        {         
          return View();
        }


        [Route("Home/{filter}/{value}")]
        [HttpGet]
        public JsonResult GetFilterData(string filter,string value)
        {
            List<User> filterData = new List<User>();

            switch (filter)
            {
                case "Name":
                    filterData = _db.User.Where(p => p.Name.Contains(value)).ToList();
                    break;
                case "Lastname":
                    filterData = _db.User.Where(p => p.LastName.Contains(value)).ToList();
                    break;
                case "Tag":
                    filterData = _db.User.Where(p => p.Tag.TagName.Contains(value)).ToList();
                    break;
            }
           
            return new JsonResult(filterData);
        }
        public IActionResult contactPartialView()
        {
            return PartialView();
        }
    }
}
