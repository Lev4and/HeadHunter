﻿using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers
{
    [ApiController]
    [Area("HeadHunter")]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.HeadHunterSpecializationsPath)]
    public class SpecializationsController : ControllerBase
    {
        private readonly HttpClients.HttpContext _context;

        public SpecializationsController(HttpClients.HttpContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route(ResourceRoutes.HeadHunterSpecializationsAllQuery)]
        [ProducesResponseType(typeof(ResponseModel<Specialization[]>), 200)]
        public async Task<IActionResult> GetAllSpecializationsAsync()
        {
            var responseModel = await _context.HeadHunter.Specializations.GetAllSpecializationsAsync();

            return StatusCode(Convert.ToInt32(responseModel.Status.Code), responseModel);
        }
    }
}
