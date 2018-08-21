# Finite Model Checker

This is a [finite model checker](https://en.wikipedia.org/wiki/Model_checking) for C#. Use it to exhaustively explore all possible sequences of operations against your codebase. Instead of arduously writing unit tests to perform a small series of operations, just define the set of all possible operations and let this library get to work! Example use cases:

* Exhaustively test your custom data structure against reads and writes
* Effectively explore the state space of your concurrency control code
* Simulate events in a multi-replica mockup of your system

Forked from [Azure/RingMaster](https://github.com/Azure/RingMaster/tree/master/src/Tools/FiniteModelChecker); I wrote this tool at Microsoft to test some particularly tricky serialization code for reducing memory usage.

NuGet package: https://www.nuget.org/packages/FiniteModelChecker/

The assemblies distributed in the NuGet package are compiled against .NET Standard 2.0, which means your project must be using .NET Framework 4.6.1+ or .NET Core 2.0+ to reference them (see [here](https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support) for more details).

## Build & Test

1. Install [.NET Core](https://www.microsoft.com/net/download)
2. Clone the repo
3. To build, run `dotnet build` from the root of the repo
4. To test, run `dotnet test` from the FiniteModelChecker.Tests directory
5. To package, run `dotnet pack -c release`

## Usage

In order to model-check your code, you must define the following:
* The set of initial states
* The set of possible state transitions
* The set of safety invariants: things which you want to always be true

The model-checker will then perform a breadth-first search from your initial states using the state transitions, checking the invariants in each state and reporting a full error trace if an invariant fails to hold. This means your model must generate only a finite number of states, as otherwise the model-checker will run forever.

For a simple example, you can see an implementation of the [water jugs puzzle from Die Hard 3](https://www.youtube.com/watch?v=BVtQNK_ZUJg) in the Tests directory.