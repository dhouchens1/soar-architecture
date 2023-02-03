using Refactoring.Enums;

namespace Refactoring.Interfaces
{
    public interface ITravelStrategyFactory
    {
        ITravelStrategy ResolveStrategy(ModeOfTravel travelMode);
    }
}