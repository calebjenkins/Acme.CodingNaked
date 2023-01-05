namespace BDD_Tests.Accounts;

public class When_Calculating_Account_Type_with_no_trips_
{
    private Account _act;

    // When
    public When_Calculating_Account_Type_with_no_trips_()
    {
        _act = new Account("123", new List<Trip>());
    }

    [Fact]
    public void Should_return_Standard()
    {
        var results = _act.CalculateAccountType();
        results.Should().Be(AccountType.Standard);
    }
}
