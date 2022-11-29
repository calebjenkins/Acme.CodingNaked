namespace BDD_ExampleLib
{
    public record Account(string AccountNumber, List<Trip> Trips)
    {
        int CalculateTotalTripPoints()
        {
            // return Trips.Sum(x => x.Points);

            var total = 0;
            foreach (var trip in Trips)
            {
                total += trip.Points;
            }
            return total;
        }

        public AccountType CalculateAccountType()
        {
            var points = CalculateTotalTripPoints();
            switch (points)
            {
                case > 10000:
                    return AccountType.Gold;

                case > 5000:
                    return AccountType.Silver;

                default:
                    return AccountType.Standard;
            }
        }
    }

    public record Trip (int Points);

    public enum AccountType
    {
        Standard,
        Silver,
        Gold
    }
}