# SA-EXERCISE

## Technologies used

* .NET Core 3.1.302
* Console application
* LINQ

## Patterns in use

* Factory
* Command
* Repository (ad hoc implementation)
* ViewModel
* Mediator
  - The `TripCommandOrchestrator` uses an ad hoc version of the Mediator pattern.
  - I would have used [MediatR](https://github.com/jbogard/MediatR) to dispatch the command as actions and have a separate command/handler class operate on the given `CommandToken`.

## Challenges

* The requirement "*Discard any trips that average a speed of less than 5 mph or greater than 100 mph*" was not immediately clear to me.
  - I was not sure whether we were excluding trip speeds of less than 5 MPH or over 100 MPH since the example provided did not showcase this scenario.
  - I tried asking recruiter for clarification but my email was not answered in time.
* I am getting inconsistent results for Dan in example file.
  - The expected output for Dan is: 
    * `Dan: 39 miles @ 47 mph`
  - However, my calculations for the average speed is off by 3:
    * `Dan: 39 miles @ 50 mph`
  - I tried manipulating the distances read in and calculated speeds by obtaining the floor value (`Math.Floor()`) but the least I got was `48 mph`.
  - Having someone to talk to for clarification would have helped me to understand what I was missing.
  - This is just an example of unclear requirements. In a real world situation, I would have spoken with the BA to understand the requirements and possibly worked with a tester during a 3-Amigo session to derive test cases or identify missing scenarios/edge cases.

## What I would do differently

* Implement dependency injection.
* Use asynchronous methods.
* Organize solution into multiple projects:
  - Core
  - Infrastructure
  - Data
  - Main (console app)
  - etc.
* Organize files into folders (models, repositories, services, etc.).
* Add error handling logic.
* Refactor Driver Repository to use Entity Framework Core with an in-memory database.
* Add unit tests.
* Improve `TripFileTokenizer` so that it is testable.

## Executing

From the solution root:

```
dotnet run --project ./src/Mjv.TripReportGenerator
```

When prompted for the file name, enter

```
example-trip.txt
```
