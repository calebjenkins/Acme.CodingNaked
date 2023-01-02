namespace BDD_ExampleLib;

public interface IAccountService
{
    Account Create(string AccountNumber, List<Trip> Trips);
}