namespace BDD_ExampleLib.Models
{
    public interface IBankingService
    {
        decimal CalculateTripPriceForAccount(Account acount, Trip trip);
    }
}