using BDD_ExampleLib.Models;

namespace BDD_Tests.Accounts;

public class When_Calculating_AccountType_with_more_than_10000_trips_
{
    private Account _act;
    private BookingService serv = new BookingService();
    public When_Calculating_AccountType_with_more_than_10000_trips_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Reserve(2000),
            serv.Reserve(7000),
            serv.Reserve(10000),
            serv.Reserve(500)
        };
        _act = new Account("123", trips);
    }

    [Fact]
    public void Should_Calculate_Gold()
    {
        var results = _act.CalculateAccountType();
        results.Should().Be(AccountType.Gold);
    }

    [Fact]
    public void Should_maintain_AccountNumber()
    {
        _act.AccountNumber.Should().Be("123");
    }
}