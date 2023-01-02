namespace BDD_ExampleLib
{
    public class DateTimeProvider : IDateTime
    {
        public DateTime Now () => DateTime.Now;
    }
    public interface IDateTime
    {
        DateTime Now();
    }
}