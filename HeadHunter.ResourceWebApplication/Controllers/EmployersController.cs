﻿using HeadHunter.HttpClients.Resource;
using HeadHunter.Model.Common;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using Collections = HeadHunter.Database.MongoDb.Collections;
using Employer = HeadHunter.Database.MongoDb.Features.Employer;

namespace HeadHunter.ResourceWebApplication.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route(ResourceRoutes.EmployersPath)]
    public class EmployersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<Collections.Employer>), 200)]
        public async Task<IActionResult> GetEmployerByHeadHunterId([Required][FromRoute(Name = "id")] long id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            return Ok(new ResponseModel<Collections.Employer>(await _mediator.Send(new Employer.Find.Command(id)), ResponseStatuses.Success));
        }

        [HttpGet]
        [Route("{id}/info")]
        [ProducesResponseType(typeof(ResponseModel<object?>), 400)]
        [ProducesResponseType(typeof(ResponseModel<Collections.Employer>), 200)]
        public async Task<IActionResult> GetEmployerById([Required][FromRoute(Name = "id")] string id)
        {
            if (!ObjectId.TryParse(id, out var _))
            {
                return BadRequest(new ResponseModel<object?>(null, ResponseStatuses.BadRequest));
            }

            return Ok(new ResponseModel<Collections.Employer>(await _mediator.Send(new Employer.Info.Command(ObjectId.Parse(id))), ResponseStatuses.Success));
        }

        [HttpGet]
        [Route(ResourceRoutes.EmployersCountQuery)]
        [ProducesResponseType(typeof(ResponseModel<long>), 200)]
        public async Task<IActionResult> GetCountEmployers()
        {
            return Ok(new ResponseModel<long>(await _mediator.Send(new Employer.Count.Command()), ResponseStatuses.Success));
        }
    }
}
