using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public class TripService : ITripService
{
    public Func<DateTime> DateNow { private get; init; } = () => DateTime.Now;
    public DateTime DateNowProp { private get; init; } = DateTime.Now;
    public Trip Purchase(int Points)
    {
        string conf = Guid.NewGuid().ToString().Substring(0, 5);
        return new Trip(Points, conf, DateNow(), DateNowProp);
    }
}
