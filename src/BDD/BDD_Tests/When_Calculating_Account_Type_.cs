namespace Given_an_Account_;

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

public class When_Calculating_Account_Type_less_than_5000_trips_
{
    private Account _act;
    private TripService serv = new TripService();

    public When_Calculating_Account_Type_less_than_5000_trips_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Purchase(1000),
            serv.Purchase(500)
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

public class When_Calculating_Account_Type_between_5000_to_10000_Points_
{
    private Account _act;
    private TripService serv = new TripService();

    public When_Calculating_Account_Type_between_5000_to_10000_Points_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Purchase(1000),
            serv.Purchase(500),
            serv.Purchase(2000),
            serv.Purchase(3000)
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

public class When_Calculating_AccountType_with_more_than_10000_trips_
{
    private Account _act;
    private TripService serv = new TripService();
    public When_Calculating_AccountType_with_more_than_10000_trips_()
    {
        List<Trip> trips = new List<Trip>()
        {
            serv.Purchase(2000),
            serv.Purchase(7000),
            serv.Purchase(10000),
            serv.Purchase(500)
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