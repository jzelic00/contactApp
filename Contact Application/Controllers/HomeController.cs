using AutoMapper;
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
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        [Route("Home/GetAllContacts")]
        [HttpGet]
        public async Task<ActionResult> GetAllContacts()
        {
            return Ok(await _service.getAllContact());
        }

        [Route("Home/TagOptions")]
        [HttpGet]
        public async Task<ActionResult> TagOptions()
        {
            return Ok(await _service.getAllTags());
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/{filter}/{value}")]
        [HttpGet]
        public async Task<ActionResult> GetFilterData(string filter, string value)
        {
            if (filter == null && value == null)
                return BadRequest();

            IEnumerable<ContactHomePageDTO> _filterData = await _service.getFilterData(filter, value);

            return Ok(_filterData);
        }

        [Route("Home/delete")]
        [HttpDelete]
        public async Task<ActionResult> DeleteContact(int? contactId)
        {           
            try
            {
                await _service.deleteContact(contactId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        public ActionResult contactPartialView()
        {
            return PartialView();
        }
    }
}
