using BDD_ExampleLib.Models;

namespace BDD_Tests.Given_AccountService_;

public class When_CalculateTripPriceForAccount_StandardStatus_
{
    private AccountService _serv;
    IDateTimeProvider _dtProvider;
    Func<DateTime> _funcDt = () => DateTime.Now;

    // When
    public When_CalculateTripPriceForAccount_StandardStatus_()
    {
        _dtProvider = new DateTimeProvider();
        _serv = new AccountService(_dtProvider, _funcDt);
    }

    [Fact]
    public void with_NoDiscount_Should_return_BaseAmount()
    {
        // No Discount // No Status * 500 points
        var acct = TestCommon.StandardAccount;
        var trip = TestCommon.TripToBuy;
        var results = _serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(TestCommon.BasePrice);
    }

    [Fact]
    public void with_WeekendDiscount_Should_return_BaseAmount_Less_DiscountAmount()
    {
        // Weekend Discount // No Status * 500 points
        _serv = new AccountService(_dtProvider, ()=> TestCommon.Sunday);
        var acct = TestCommon.StandardAccount;
        var trip = TestCommon.TripToBuy;

        var results = _serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(TestCommon.BasePrice - Ref.WeekendDiscountAmount);
    }
}
