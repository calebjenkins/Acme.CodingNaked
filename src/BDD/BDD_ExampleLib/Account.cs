using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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

        public decimal CalculateTripPrice(Trip trip)
        {
            decimal pricePerPoint = calculateCostPerPoint();
            decimal price = trip.Points * pricePerPoint;

            return price;
        }

        public DateTime Now { private get; set; } = DateTime.Now;
        public Func<DateTime> FunNow { get; set; } = () => DateTime.Now;

        public decimal DiscountAmount()
        {
            var dtNow = DateTime.Now;
            dtNow = Now; // Property Injection
            dtNow = FunNow(); // Public Func

            // On Weekends, there is a $25 discount
            return  (dtNow.DayOfWeek == DayOfWeek.Saturday || dtNow.DayOfWeek == DayOfWeek.Sunday) ?
                25.17m : 0.0m;
        }

        private decimal calculateCostPerPoint()
        {
            var accType = CalculateAccountType();
            var discount = DiscountAmount();

            switch(accType)
            {
                case AccountType.Gold:
                    return 300.00m - discount;
                
                case AccountType.Silver:
                    return 350.00m - discount;

                case AccountType.Standard:
                default:
                    return 400.00m - discount;
            }
        }
    }

    public record Trip (int Points, string Confirmation, DateTime PurchaseDate);

    public enum AccountType
    {
        Standard,
        Silver,
        Gold
    }
}