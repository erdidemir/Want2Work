using DoDo.Application.Features.Commands.Jobbers.AddJobber;
using DoDo.Application.Features.Commands.Jobbers.DeleteJobber;
using DoDo.Application.Features.Commands.Jobbers.UpdateJobber;
using DoDo.Application.Features.Queries.Jobbers.GetJobber;
using DoDo.Application.Models.Jobbers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DoDo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JobberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobberController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Authorize(Policy = "RequireJobberRole")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<JobberViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<JobberViewModel>> GetJobberByUserName()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var query = new GetJobberByUserIdQuery(userId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "AddJobber")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddJobber([FromBody] AddJobberCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateJobber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateJobber([FromBody] UpdateJobberCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteJobber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteJobber(int id)
        {
            var command = new DeleteJobberCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

