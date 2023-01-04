using BDD_ExampleLib.Models;

namespace BDD_ExampleLib;

public interface ITripService
{
    Trip Purchase(int Points);
}
