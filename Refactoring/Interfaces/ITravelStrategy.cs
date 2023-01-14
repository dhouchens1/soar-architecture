namespace Refactoring.Interfaces
{
    public interface ITravelStrategy
    {
        TimeSpan CalculateTravelTime(double miles);
    }
}
