using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public interface IAccountService
{
    Account Create(string AccountNumber, List<Trip> Trips);
    decimal CalculateTripPriceForAccount(Account acount, Trip trip);
}