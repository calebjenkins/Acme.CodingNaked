namespace BDD_ExampleLib;

public class TripService : ITripService
{
    public Func<DateTime> DateNow { private get; init; } = () => DateTime.Now;
    public Trip Purchase(int Points)
    {
        string conf = new Guid().ToString().Substring(0, 5);
        return new Trip(Points, conf, DateNow());
    }
}
