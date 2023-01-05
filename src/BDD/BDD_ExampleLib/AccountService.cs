using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public class AccountService : IAccountService
{
    private IDateTimeProvider dtProvider;
    private Func<DateTime> funcDt;

    public AccountService(IDateTimeProvider DateProvider, Func<DateTime> FuncDt)
    {
        dtProvider = DateProvider ?? throw new ArgumentNullException(nameof(DateProvider));
        funcDt = FuncDt ?? (() => DateTime.Now);
    }

    public Account Create(string AccountNumber, List<Trip> Trips)
    {
         var acct = new Account(AccountNumber, Trips);
        acct.CalculateAccountType();
        return acct;
    }

    public decimal CalculateTripPriceForAccount(Account acount, Trip trip)
    {
        var accountType = acount.CalculateAccountType();
        var discount = discountForNowPurchases();

        switch (accountType)
        {
            case AccountType.Gold:
                return (Ref.GoldPricePerPoint * trip.Points) - discount;

            case AccountType.Silver:
                return (Ref.SilverPricePerPoint * trip.Points) - discount;

            case AccountType.Standard:
            default:
                return (Ref.StandardPricePerPoint * trip.Points) - discount;
        }
    }

    decimal discountForNowPurchases()
    {
        var dtNow = DateTime.Now;
        dtNow = dtProvider.Now();   // Using a "provider class"
        dtNow = funcDt();           // Passing in a Func
      //-- You would never use both of these - pick one! 

        // On Weekends, there is a $25 discount
        return dtNow.DayOfWeek == DayOfWeek.Saturday || dtNow.DayOfWeek == DayOfWeek.Sunday ?
            Ref.WeekendDiscountAmount : 0.0m;
    }
}