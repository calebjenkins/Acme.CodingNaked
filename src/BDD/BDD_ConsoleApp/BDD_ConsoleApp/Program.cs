// See https://aka.ms/new-console-template for more information

using BDD_ExampleLib;
using Lamar;

var Sunday = new DateTime(2023, 1, 1);
var Wednesday = new DateTime(2023, 1, 4);

var container = new Lamar.Container((x) =>
{
    x.Scan((s) => {
        s.WithDefaultConventions();
        s.AssemblyContainingType<Account>();
        });
    x.For<IDateTime>().Use<DateTimeProvider>().Singleton();
    x.For<Func<DateTime>>().Add(() => Sunday);
    //x.For<Func<DateTime>>().Add(() => DateTime.Now);

    //x.For<IAccountService>().Use<AccountService>()
    //  .Setter<Func<DateTime>>().Is(() => Sunday);
    //.Setter<Func<DateTime>>().Is(() => Wednesday);
    //.Setter<Func<DateTime>>().Is(() => DateTime.Now);
});


Console.WriteLine("Account Calculator");

var accountServ = container.GetInstance<IAccountService>();
var tripServ = container.GetInstance<ITripService>();

var act = accountServ.Create("123", new List<Trip>());

Console.WriteLine("Status: " + act.CalculateAccountType().ToString());
Console.WriteLine("Discount: " + act.DiscountAmount()); 
Console.WriteLine("Price: " + act.CalculateTripPrice(tripServ.Purchase(10)));

Console.ReadLine();
