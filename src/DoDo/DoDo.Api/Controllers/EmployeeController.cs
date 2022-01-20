using DoDo.Application.Features.Commands.Employees.AddEmployee;
using DoDo.Application.Features.Commands.Employees.DeleteEmployee;
using DoDo.Application.Features.Commands.Employees.UpdateEmployee;
using DoDo.Application.Features.Queries.Employees.GetEmployee;
using DoDo.Application.Models.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DoDo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{userId}", Name = "GetEmployee")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeViewModel>> GetEmployeeByUserName(int userId)
        {
            var query = new GetEmployeeByUserIdQuery(userId);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "AddEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> AddEmployee([FromBody] AddEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

