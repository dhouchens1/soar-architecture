**SOAR Architecture - Refactoring Exercise**

**Problem:** The sample application is a simple Blazor Server app that calculates travel time based on an origin city, destination city, and mode of travel.  It first retrieves the distance between two cities based on an included .csv file, and then calculates travel time using an ugly if/else block that approximates speed based on the mode of travel.  Unfortunately, most of the logic is in a monolith class (`Components/TravelCalculatorBase`) that does many things and is tightly coupled to many dependencies. This violates many SOLID principles and would be very difficult to unit test.

**Solution:** Use dependency injection, as well as the strategy, factory, and repository patterns to clean up the code, make it more readable, and make the components loosely coupled so they can easily be unit tested.

 1. Extract the logic to read from the .csv file into a separate class in the services folder called `CsvDistanceService` that implements the `IDistanceService` interface.

 2. Uncomment the `IDistanceService` injection as the top of the `TravelCalculatorBase` class.  Also uncomment line 7 in `Program.cs`.  By adding these two lines, we've told the .Net dependency injection container to return an instance of `CsvDistanceService` whenever the code asks for an instance of `IDistanceService`.  The service will then automatically be resolved when a `TravelCalculatorBase` instance is created.  We can then use the injected `IDistanceService` to calculate the distance between two cities.
 
 3.  Next, the travel time calculation itself is a good candidate for the strategy pattern, since it represents different ways of doing something based on an input parameter.  Create a separate implementation of `ITravelStrategy` in the strategies folder for each mode of travel.
 
 4.  Now we need a way to resolve the correct strategy based on the mode of travel that the user selected.  We can use the factory pattern here by creating an implementation of `ITravelStrategyFactory`.  This will contain an if/else block (or even better, a switch statement) and return an instance of `ITravelStrategy`.  Similar to what was done to inject `IDistanceService`, we'll need to uncomment the lines in `Program.cs` and `TravelCalculatorBase` to wire up dependency injection for the factory.
 
 5. Finally, the method of looking up distances in a .csv file makes no sense and severely limits the capabilities of this application.  There is another class called `MapQuestDistanceService` that calls an API to determine the distance.  Having two implementations of `IDistanceService` is an example of the repository pattern - the method by which we access data is abstracted away from our child component.  By updating `Program.cs` to return an instance of `MapQuestDistanceService` whenever the code asks for an implementation of `IDistanceService`, we can easily swap out our method of retrieving the distance between two cities.

**Bonus:** Update the `TravelCalculator.razor` class to use text boxes instead of dropdowns so that the user can enter any origin or destination.  Test it using the `MapQuestDistanceService` and verify that it works.
