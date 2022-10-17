using System.ComponentModel.DataAnnotations;

using CashFlow.Domain.Features.Entries.Enums;

using MediatR;

namespace CashFlow.Domain.Features.Entries.Commands;

public class CreateEntry : IRequest<Entry>
{
    [Required]
    public EntryType Type { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    [Range(0.0, Double.MaxValue)]
    public decimal Value { get; set; }
}
