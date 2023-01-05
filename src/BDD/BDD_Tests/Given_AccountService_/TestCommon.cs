namespace BDD_Tests.Given_AccountService_;

public static class TestCommon
{
    public static readonly DateTime Sunday = new DateTime(2023, 1, 1);
    public static readonly DateTime Wednesday = new DateTime(2023, 1, 4);
    public static readonly Account StandardAccount = new Account("123", new List<Trip>());
    public static readonly Account SilverAccount = new Account("123", new List<Trip>()
    { new Trip(550, "abc", Wednesday, Wednesday) });

    public static readonly Account GoldAccount = new Account("123", new List<Trip>()
    { new Trip(1100, "abc", Wednesday, Wednesday) });

    public static readonly Trip TripToBuy = new Trip(500, "abc", Wednesday, Wednesday);
    public static readonly decimal BasePrice = 20000.00m;
}


