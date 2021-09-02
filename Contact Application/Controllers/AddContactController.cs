using Contact_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
   
    public class AddContactController : Controller
    {       
        public PartialViewResult AddContact()
        {
            return PartialView();
        }
    }
}
