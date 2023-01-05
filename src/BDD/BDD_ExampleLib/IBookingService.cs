using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public interface IBookingService
{
    Trip Reserve(int Points);
}
