﻿using Mattis.Api.Main.Business.Player.Command;
using Mattis.Api.Main.Business.Player.Query;
using Mattis.Api.Main.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mattis.Api.Main.App.Controllers
{
    [ApiController]
    [Route("api/player")]
    public class PlayerController : ControllerBase
    {
        readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerResponse?>> GetByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetPlayerByIdQuery { Id = id });

            return Ok(result);
        }

        [HttpPost("by-criteria")]
        public async Task<ActionResult<IEnumerable<PlayerResponse>>> GetByCriteriaAsync([FromBody] GetPlayersByCriteriaQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] CreatePlayerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync([FromBody] UpdatePlayerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
