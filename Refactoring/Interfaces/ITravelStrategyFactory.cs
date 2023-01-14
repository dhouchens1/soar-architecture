namespace Refactoring.Interfaces
{
    public interface ITravelStrategyFactory
    {
        ITravelStrategy ResolveStrategy(string name);
    }
}