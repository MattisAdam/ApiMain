using ApiTest.Business.Person.Query;
using ApiTest.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ApiTest.App.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> GetByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetPersonByIdQuery { Id = id });
            return Ok(result);
        }
    }
}
