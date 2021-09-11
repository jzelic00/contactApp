using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Models
{
    public class ContactHomePageDTO
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}