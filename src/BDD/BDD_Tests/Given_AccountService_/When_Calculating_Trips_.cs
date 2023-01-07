using BDD_ExampleLib.Models;

namespace BDD_Tests.Given_AccountService_;

public class When_CalculateTripPriceForAccount_StandardStatus_
{
    IDateTimeProvider _dtProvider;
    Func<DateTime> _funcDt = () => TestCommon.Wednesday;

    // When
    public When_CalculateTripPriceForAccount_StandardStatus_()
    {
        _dtProvider = new DateTimeProvider();
    }

    [Fact]
    public void with_NoDiscount_Should_return_BaseAmount()
    {
        // No Discount // No Status * 500 points
        var serv = new AccountService(_dtProvider, () => TestCommon.Wednesday);
        var acct = TestCommon.StandardAccount;
        var trip = TestCommon.TripToBuy;
        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(TestCommon.BasePrice);
    }

    [Fact]
    public void with_WeekendDiscount_Should_return_BaseAmount_Less_DiscountAmount()
    {
        // Weekend Discount // No Status * 500 points
        var serv = new AccountService(_dtProvider, ()=> TestCommon.Sunday);
        var acct = TestCommon.StandardAccount;
        var trip = TestCommon.TripToBuy;

        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(TestCommon.BasePrice - Ref.WeekendDiscountAmount);
    }
}
