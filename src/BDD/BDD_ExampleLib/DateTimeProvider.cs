namespace BDD_ExampleLib;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now () => DateTime.Now;
}
public interface IDateTimeProvider
{
    DateTime Now();
}