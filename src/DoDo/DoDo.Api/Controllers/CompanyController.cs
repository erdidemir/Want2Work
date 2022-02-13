using DoDo.Application.Models.Companies;
using DoDo.Application.Queries.Companies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<CompanyViewModel>>> Search([FromQuery] CompanyQuery search)
        {
            

            return null;
        }

    }
}
