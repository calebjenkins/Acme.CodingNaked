namespace BDD_ExampleLib.Models;

public record Account
{
    public Account(string AccountNumber, List<Trip> Trips)
    {
        this .AccountNumber = AccountNumber;
        this .Trips = Trips;
        CalculateAccountType();
    }
    public string AccountNumber { get; private init;}
    public List<Trip> Trips { get; private set; }

    public AccountType CalculateAccountType()
    {
        var points = Trips.Sum(x => x.Points);

        switch (points)
        {
            case >= Ref.GoldPointsThreashold:
                Status = AccountType.Gold; break;
            case >= Ref.SilverPointsThreashold:
                Status = AccountType.Silver; break;
            default:
                Status = AccountType.Standard; break;
        }

        return Status;
    }

    public AccountType Status { get; private set; } = AccountType.Standard;

    public void PurchaseTrip(Trip trip)
    {
        // We would reject a trip with an existing conf code.. but demos.

        Trips.Add(trip);
        CalculateAccountType();
    }
}

