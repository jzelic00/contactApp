using AutoMapper;
using Contact_Application.Models;
using Contact_Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Application.Controllers
{
   
    public class AddContactController : Controller
    {
        private readonly IService _service;
        public AddContactController(IService service)
        {
            _service = service;
        }

        [Route("AddContactController/AddContact")]
        [HttpPost]
        public async Task<ActionResult> AddNewContact([FromBody]ContactDTO newContact)
        {
            if (newContact == null)
                return BadRequest();

            try
            {
                await _service.addNewContactAsync(newContact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
        public PartialViewResult AddContact()
        {
            return PartialView();
        }
    }
}
