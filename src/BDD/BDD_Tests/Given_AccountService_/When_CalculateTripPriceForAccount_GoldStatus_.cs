namespace BDD_Tests.Given_AccountService_;

public class When_CalculateTripPriceForAccount_GoldStatus_
{
    IDateTimeProvider _dtProvider;

    // When
    public When_CalculateTripPriceForAccount_GoldStatus_()
    {
        _dtProvider = new DateTimeProvider();
    }

    [Fact]
    public void with_NoWeekendDiscount_Should_return_Base_GOLD_Amount()
    {
        // No Weekend Discount // Silver Status * 500 points
        var serv = new AccountService(_dtProvider, () => TestCommon.Wednesday);
        var acct = TestCommon.GoldAccount;
        var trip = TestCommon.TripToBuy;
        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(Ref.GoldPricePerPoint * trip.Points);
    }

    [Fact]
    public void with_WeekendDiscount_Should_return_Base_GOLD_Amount_Less_DiscountAmount()
    {
        // Weekend Discount - Set Account Service to Weekend for testing
        var serv = new AccountService(_dtProvider, () => TestCommon.Sunday);

        var acct = TestCommon.GoldAccount;
        var trip = TestCommon.TripToBuy;

        var results = serv.CalculateTripPriceForAccount(acct, trip);
        results.Should().Be(Ref.GoldPricePerPoint * trip.Points - Ref.WeekendDiscountAmount);
    }
}
