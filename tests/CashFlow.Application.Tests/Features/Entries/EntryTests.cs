using CashFlow.Application.Features.Entries;
using CashFlow.Application.Features.Entries.Enums;

namespace CashFlow.Application.Tests.Features.Entries;

public class EntryTests
{
    [Fact]
    public void ShouldReturnNegativeValueWhenCreateDebitEntry()
    {
        // arrange

        var entryvalue = 10;

        // act

        var entry = new Entry(
            type: EntryType.Debit,
            date: DateTime.Now,
            value: entryvalue
            );

        // assert

        var negativeEntryValue = entryvalue * -1;

        Assert.Equal(entry.Value, negativeEntryValue);
    }

    [Fact]
    public void ShouldReturnPositiveValueWhenCreateCreditEntry()
    {
        // arrange

        var entryvalue = 10;

        // act

        var entry = new Entry(
            type: EntryType.Credit,
            date: DateTime.Now,
            value: entryvalue
            );

        // assert

        Assert.Equal(entry.Value, entryvalue);
    }

    [Fact]
    public void ShouldThrowExceptionWhenCreateEntryWithNegativeValue()
    {
        // arrange

        var createEntryWithNegativeValue = () => new Entry(
            type: EntryType.Credit,
            date: DateTime.Now,
            value: -10
            );

        // act

        var exception = Record.Exception(createEntryWithNegativeValue);

        // assert

        Assert.NotNull(exception);
        Assert.Equal("Entry value must be positive", exception.Message);
    }
}
