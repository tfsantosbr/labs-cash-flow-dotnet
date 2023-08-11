using CashFlow.Application.Features.Entries.Commands;
using CashFlow.Application.Features.Entries.Repositories;
using CashFlow.Application.Features.Entries.Models;

using Microsoft.AspNetCore.Mvc;
using CashFlow.Application.Base.Models;
using CashFlow.Application.Base.Handlers;
using CashFlow.Application.Features.Entries;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("entries")]
public class EntriesController : ControllerBase
{
    private readonly IEntryRepository _entryRepository;
    private readonly IHandler<CreateEntry, Response<Entry>> _createEntryHandler;
    private readonly IHandler<RemoveEntry, Response<Entry>> _removeEntryHandler;

    public EntriesController(
        IEntryRepository entryRepository,
        IHandler<CreateEntry, Response<Entry>> createEntryHandler,
        IHandler<RemoveEntry, Response<Entry>> removeEntryHandler)
    {
        _entryRepository = entryRepository;
        _createEntryHandler = createEntryHandler;
        _removeEntryHandler = removeEntryHandler;
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

        var response = await _createEntryHandler.Handle(request);
        var entry = response.Data!;

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

        await _removeEntryHandler.Handle(new RemoveEntry(entryId));

        return NoContent();
    }
}
