namespace BDD_ExampleLib.Models;

public class BankingCalculator 
{
    public static decimal CalculateTripPriceForAccount(Account acount, Trip trip)
    {
        var accountType = acount.CalculateAccountType();
        var discount = discountForNowPurchases();
       
        switch (accountType)
        {
            case AccountType.Gold:
                return (30.00m * trip.Points) - discount;

            case AccountType.Silver:
                return (35.00m * trip.Points) - discount;

            case AccountType.Standard:
            default:
                return (40.00m * trip.Points) - discount;
        }
    }
    public static DateTime NowProp { private get; set; } = DateTime.Now;
    public static Func<DateTime> FuncNow { get; set; } = () => DateTime.Now;

    static decimal discountForNowPurchases()
    {
        var dtNow = DateTime.Now;
        dtNow = NowProp; // This will fall farther and farther behind, the longer this application runs. 
        dtNow = FuncNow(); // Public Func - this will re-run everytime

        // On Weekends, there is a $25 discount
        return dtNow.DayOfWeek == DayOfWeek.Saturday || dtNow.DayOfWeek == DayOfWeek.Sunday ?
            25.17m : 0.0m;
    }
}

