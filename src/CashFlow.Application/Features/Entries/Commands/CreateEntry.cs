using System.ComponentModel.DataAnnotations;

using CashFlow.Application.Features.Entries.Enums;

namespace CashFlow.Application.Features.Entries.Commands;

public class CreateEntry
{
    [Required]
    public EntryType Type { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Range(0.0, double.MaxValue)]
    public decimal Value { get; set; }
}
