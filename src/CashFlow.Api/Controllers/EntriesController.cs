using CashFlow.Domain.Features.Entries.Commands;
using CashFlow.Domain.Features.Entries.Repositories;
using CashFlow.Domain.Features.Entries.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("entries")]
public class WeatherForecastController : ControllerBase
{
    private readonly IEntryRepository _entryRepository;
    private readonly IMediator _mediator;

    public WeatherForecastController(IEntryRepository entryRepository, IMediator mediator)
    {
        _entryRepository = entryRepository;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Find([FromQuery] EntryParameters parameters)
    {
        var items = await _entryRepository.Find(parameters);

        return Ok(items);
    }

    [HttpGet("balance")]
    public async Task<IActionResult> GetBalance([FromQuery] EntryParameters parameters)
    {
        var sum = await _entryRepository.GetBalance(parameters);

        return Ok(sum);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEntry request)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var entry = await _mediator.Send(request);

        var entryDetails = new EntryDetails
        {
            Id = entry.Id,
            Type = entry.Type,
            Date = entry.Date,
            Value = entry.Value
        };

        return Created($"entries/{entryDetails.Id}", entryDetails);
    }

    [HttpDelete("{entryId}")]
    public async Task<IActionResult> Remove(Guid entryId)
    {
        if (!await _entryRepository.AnyEntry(entryId))
            return NotFound(new
            {
                Code = "Lançamento",
                Message = "Lançamento não encontrado"
            });

        await _mediator.Send(new RemoveEntry(entryId));

        return NoContent();
    }
}
