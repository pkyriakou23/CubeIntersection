# Cube Intersection

## Overview
Cube Intersection is a .NET console application that determines whether two cubes overlap in 3D space and calculates the volume of any intersection. The user is guided through console prompts to enter the cube centers and side lengths, and the application reports collision status and overlap volume.

## Implementation Details

### Architecture
The project follows an object-oriented design:
- **Application**: Handles the console prompting and executing the logic.
- **ConsoleHandler & ConsoleErrorHandler**: Handles the Input and Output of the program, whether this is casual prompts or error logs
- **Models**: `Cube` and `Point` represent an entity of the logic.
- **Services**: `CubeIntersectionServiceImpl` implements `IIntersectionService` and encapsulates the mathematical logic for detecting collisions and calculating intersection volume for cubes.
- **Constants**: Shared text like error messages and cube labels live in `Constants` to centralize user-facing strings.

## How It Works
1. `Program.Main` wires the logger, error handler, console handler, and intersection service, then constructs `Application` and calls `Run`.
2. `Application.Run` welcomes the user, requests cube centres (X, Y, Z) and positive sizes, then asks the service to compute collision status and overlap volume.
3. `ConsoleHandler` loops on invalid input, displaying contextual errors via `ConsoleErrorHandler` until valid integers are provided.
4. The service calculates axis overlaps and intersection volume and the results are printed back to the console for immediate feedback.

## Design Decisions
- Separate classes for input, error handling, orchestration, and math's logic keep responsibilities focused and testable.
- Core contains handlers for console input/output, error reporting, and logging that can be used everywhere in the application.
- The system is structured so that adding new shapes and their intersection algorithms requires adding new classes, not rewriting existing ones.
- Models are immutable to avoid state drift during calculations.
- Integer-only, to focus on architecture and not the maths.
- Validation loops prevent crashes, letting users correct mistakes without restarting the app.
- YAGNI and SOLID principles guide the structure.

## Test Data & Results
- **Intersecting Example**
  - Cube 1 center `(0,0,0)`, size `4`
  - Cube 2 center `(1,1,1)`, size `4`
  - Result: cubes collide and the intersection volume is `27`.
- **Non-Overlapping Example**
  - Cube 1 center `(0,0,0)`, size `2`
  - Cube 2 center `(5,5,5)`, size `2`
  - Result: cubes do **not** collide, so the intersection volume is `0`.

### Testing Strategy
- **Unit Tests**: Each component tested in isolation
- **Integration Tests**: End-to-end testing of the service and flow

## Code Quality
- Small, single-purpose classes keep responsibilities clear (I/O, logging, validation, math).
- Dependency injection in `Program` clarifies construction order and enables mocking for tests.
- Centralized constants reduce duplicated text and ease localization or copy changes.

## Technical Stack
- **Framework**: .NET 8.0
- **Language**: C#
- **Testing**: xUnit
