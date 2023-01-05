using BDD_ConsoleApp;
using BDD_ExampleLib;
using BDD_ExampleLib.Models;

var Sunday = new DateTime(2023, 1, 1);
var Wednesday = new DateTime(2023, 1, 4);

#region "Set Up DI"
    var container = new Lamar.Container((x) =>
    {
        x.Scan((s) => {
            s.WithDefaultConventions();
            s.AssemblyContainingType<Account>();
            });

        //x.For<Func<DateTime>>().Add(() => Sunday);
        //x.For<Func<DateTime>>().Add(() => DateTime.Now);
        x.For<Func<DateTime>>().Add(DateTimeProvider.DateTimeNow);
});
#endregion


var accountServ = container.GetInstance<IAccountService>();
var bookingServ = container.GetInstance<IBookingService>();

ConsoleExt.Label("Trip Calculator");
var trip = bookingServ.Reserve(600);
Console.WriteLine(trip);

Console.ReadLine();


ConsoleExt.Label("Account Calculator");
var act = accountServ.Create("123", new List<Trip>());

Console.WriteLine(act);
ConsoleColor.Red.WriteLine("My Price: " + accountServ.CalculateTripPriceForAccount(act, trip));
ConsoleExt.Line();

act.PurchaseTrip(trip);
Console.WriteLine(act);
ConsoleColor.Green.WriteLine("My Price: " + accountServ.CalculateTripPriceForAccount(act, trip));
ConsoleExt.Line();

List<Trip> trips = new();

for(int x= 1; x <= 10; x++)
{
    trips.Add(bookingServ.Reserve(100 * x));
    Thread.Sleep(1000*x);
    Console.Write(x + "... ");
}
ConsoleExt.Line();
Console.ReadLine();

Console.WriteLine();
ConsoleExt.Label("Trips with TimeStamps");
foreach(Trip tr in trips)
{
    Console.WriteLine(tr.ToString());
    act.PurchaseTrip(tr);
}
Console.ReadLine();
ConsoleExt.Line();
Console.WriteLine(act);
ConsoleColor.Yellow.WriteLine("My Price: " + accountServ.CalculateTripPriceForAccount(act, trip));

Console.ReadLine();
