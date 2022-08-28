﻿using HeadHunter.HttpClients.Resource;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.HeadHunterDictionariesPath)]
    public class DictionariesController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public DictionariesController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDictionariesAsync()
        {
            var responseModel = await _context.HeadHunter.Dictionaries.GetDictionariesAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
