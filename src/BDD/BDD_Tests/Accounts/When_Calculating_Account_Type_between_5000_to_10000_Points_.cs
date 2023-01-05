namespace BDD_Tests.Accounts;

public class When_Calculating_Account_Type_between_500_to_1000_Points_
{
    private Account _act;
    private BookingService serv = new BookingService();

    public When_Calculating_Account_Type_between_500_to_1000_Points_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Reserve(100),
            serv.Reserve(50),
            serv.Reserve(200),
            serv.Reserve(300)
        };
        _act = new Account("123", trips);
    }

    [Fact]
    public void Should_Calculate_Silver()
    {
        var results = _act.CalculateAccountType();
        results.Should().Be(AccountType.Silver);
    }

    [Fact]
    public void Should_maintain_AccountNumber()
    {
        _act.AccountNumber.Should().Be("123");
    }
}
