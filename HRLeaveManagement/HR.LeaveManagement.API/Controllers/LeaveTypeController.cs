using HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<List<LeaveTypesDto>> Get()
        {
            var query = await _mediator.Send(new GetLeaveTypeQuery());
            return query;
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<GetLeaveTypesDetailsDto> Get(int id)
        {
            var result = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
            return result;
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<bool> Post([FromBody] CreateLeaveTypeDto request)
        {
            var result = await _mediator.Send(new CreateLeaveTypeCommand(request));
            return result.IsSuccess;
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
