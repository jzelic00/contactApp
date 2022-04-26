using Contact_Application.Models;
using Contact_Application.Services;
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
        private readonly IService _service;

        public EditContactController(IService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<ActionResult> EditContact(int id,[FromBody]Contact contact)
        {
            if (id != contact.ContactID)
                return BadRequest();

            try
            {
                await _service.editContact(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
 
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetContact(int? id)
        {
            if (id == null)
                return BadRequest();
                           
            Contact contact = await _service.getSingleContact(id);
           
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }
        public IActionResult Index()
        {
            return PartialView();
        }
    }
}
