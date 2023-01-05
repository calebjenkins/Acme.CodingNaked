using BDD_ExampleLib.Models;

namespace BDD_Tests.Given_AccountService_;

public class When_CalculateTripPriceForAccount_StandardStatus_NoDiscount_
{
    private AccountService _serv;
    IDateTimeProvider _dtProvider;
    Func<DateTime> _funcDt = () => DateTime.Now;

    // When
    public When_CalculateTripPriceForAccount_StandardStatus_NoDiscount_()
    {
        _dtProvider = new DateTimeProvider();
        _serv = new AccountService(_dtProvider, _funcDt);
    }

    [Fact]
    public void Should_return_TwentyThousand()
    {
        // No Discount
        var acct = new Account("123", new List<Trip>());
        var trip = new Trip(500, "abc", Common.Wednesday, Common.Wednesday);
        var results = _serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(20000.00m);
    }
}

public static class Common
{
    public static DateTime Sunday = new DateTime(2023, 1, 1);
    public static DateTime Wednesday = new DateTime(2023, 1, 4);
}


