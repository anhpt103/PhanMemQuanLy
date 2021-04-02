using Application.Features.Masters.Commands.CreateMaster;
using Application.Features.Masters.Commands.DeleteMasterById;
using Application.Features.Masters.Commands.UpdateMaster;
using Application.Features.Masters.Queries.GetAllMaster;
using Application.Features.Masters.Queries.GetMasterById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SM.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class MasterController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllMastersParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllMastersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMasterByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMasterCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMasterCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMasterByIdCommand { Id = id }));
        }
    }
}
