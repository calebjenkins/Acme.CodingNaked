namespace BDD_Tests.Given_AccountService_;

public class When_CalculateTripPriceForAccount_SilverStatus_
{
    IDateTimeProvider _dtProvider;
    Func<DateTime> _funcDt = () => DateTime.Now;

    // When
    public When_CalculateTripPriceForAccount_SilverStatus_()
    {
        _dtProvider = new DateTimeProvider();
    }

    [Fact]
    public void with_NoWeekendDiscount_Should_return_BaseSilverAmount()
    {
        // No Weekend Discount // Silver Status * 500 points
        var serv = new AccountService(_dtProvider, () => TestCommon.Wednesday);
        var acct = TestCommon.SilverAccount;
        var trip = TestCommon.TripToBuy;

        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(Ref.SilverPricePerPoint * trip.Points);
    }

    [Fact]
    public void with_WeekendDiscount_Should_return_BaseSilverAmount_Less_DiscountAmount()
    { 
        // Weekend Discount - Set Account Service to Weekend for testing
        var serv = new AccountService(_dtProvider, () => TestCommon.Sunday);

        var acct = TestCommon.SilverAccount;
        var trip = TestCommon.TripToBuy;

        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(Ref.SilverPricePerPoint * trip.Points - Ref.WeekendDiscountAmount);
    }
}
