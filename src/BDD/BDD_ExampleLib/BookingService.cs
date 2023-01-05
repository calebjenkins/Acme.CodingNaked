using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public class BookingService : IBookingService
{
    public Func<DateTime> DateNowFunc { private get; init; } = () => DateTime.Now;
    public DateTime DateNowProp { private get; init; } = DateTime.Now;
    public Trip Reserve(int Points)
    {
        string conf = Guid.NewGuid().ToString().Substring(0, 5);
        return new Trip(Points, conf, DateNowProp, DateNowFunc());
    }
}
