using Application.Features.UnitCodes.Commands.CreateUnitCode;
using Application.Features.UnitCodes.Commands.DeleteUnitCodeById;
using Application.Features.UnitCodes.Commands.UpdateUnitCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SM.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UnitCodeController : BaseApiController
    {
        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateUnitCodeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateUnitCodeCommand command)
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
            return Ok(await Mediator.Send(new DeleteUnitCodeByIdCommand { Id = id }));
        }
    }
}
