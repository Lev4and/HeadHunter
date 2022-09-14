﻿using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Collections = HeadHunter.Database.MongoDb.Collections;
using VacancyType = HeadHunter.Database.MongoDb.Features.VacancyType;

namespace HeadHunter.ResourceWebApplication.Areas.Import.Controllers
{
    [ApiController]
    [Area("Import")]
    [EnableCors("CorsPolicy")]
    [Route("api/import/vacancyTypes")]
    public class VacancyTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacancyTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel<ObjectId>), 200)]
        public async Task<IActionResult> Import([FromBody] VacancyType.Import.Command command)
        {
            return Ok(new ResponseModel<Collections.VacancyType>(await _mediator.Send(command), ResponseStatuses.Success));
        }
    }
}
