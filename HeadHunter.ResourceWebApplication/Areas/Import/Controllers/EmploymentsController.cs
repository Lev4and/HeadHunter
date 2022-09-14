﻿using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Employment = HeadHunter.Database.MongoDb.Features.Employment;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/employments")]
    public class EmploymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmploymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] Employment.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.Employment>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
