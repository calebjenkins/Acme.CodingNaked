using BDD_ExampleLib.Models;

namespace BDD_Tests.Accounts;

public class When_Calculating_Account_Type_less_than_500_trips_
{
    private Account _act;
    private BookingService serv = new BookingService();

    public When_Calculating_Account_Type_less_than_500_trips_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Reserve(100),
            serv.Reserve(50)
        };
        _act = new Account("123", trips);
    }

    [Fact]
    public void Should_return_Standard()
    {
        var results = _act.CalculateAccountType();
        results.Should().Be(AccountType.Standard);
    }

    [Fact]
    public void Should_maintain_AccountNumber()
    {
        _act.AccountNumber.Should().Be("123");
    }
}
