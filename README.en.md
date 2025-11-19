# Library Robot

_Lisez ceci dans d'autres langues : [Français](README.md)._

## Guidelines

You must provide a working C# implementation of `ILibraryRoutePlanner.cs` (which you cannot modify) that solves all acceptance tests (`AcceptanceTests.cs`).

**The final version of your code must be available/pushed at least 5 hours before you meet with the team.**

After submitting your code, you will join a 90-minute session with development team members in an environment that reflects our daily work. We will work together on your code, with new constraints added to the problem. You must therefore have a well-structured, understandable solution that will allow you and your peers to divide these new tasks easily.

## Problem

A small autonomous robot operates in a library. Its job is to pick up
requested books from the shelves and bring them back to the service
desk.

The library is represented as a rectangular grid of characters:

-   `#` represents a wall or a shelf that the robot cannot pass through.
-   `.` represents an empty floor tile that the robot can walk on.
-   `S` represents the service desk. The robot starts here and must
    finish here.
-   Lowercase letters `a` to `z` represent requested books that must be
    picked up.

There is exactly one `S` in the grid.\
There can be zero or more requested books (letters) in the grid.\
All rows and columns have the same length.

The robot can move in four directions on the grid:

-   Up (`U`)
-   Down (`D`)
-   Left (`L`)
-   Right (`R`)

Each move steps from one tile to an adjacent tile in that direction.

The robot:

-   Cannot move outside the bounds of the grid.
-   Cannot move into `#` tiles.
-   Starts on the `S` tile.
-   Picks up a book automatically when it steps on a tile with a letter.
    -   Once a book has been picked up, that tile effectively becomes
        empty floor for the rest of the route.
	-	The robot can carry all books at once.

If no valid route exists (for example, one of the books is completely
surrounded by walls), you must return an empty string.

## Requirements

-   The software application must implement the `ILibraryRoutePlanner`
    interface and its `Start` method.
-   The software application will calculate a valid route for the robot
    (and ideally the shortest one) that:
    -   Starts and ends at the `S` tile,
    -   Picks up all requested books (`a` to `z` tiles).
-   All acceptance tests in `AcceptanceTests.cs` must succeed.

Feel free to improve the test suite with additional relevant tests, or
introduce new acceptance criteria that are pertinent to the problem.

## Examples

`ILibraryRoutePlanner` is an interface between your code and our unit tests. The solution includes a number of basic tests to help validate your understanding of the business logic.
Here is a simple example of inputs and outputs for this class to get you started.

### Example 1

Input (string array):

```
"#####",
"#Sa.#",
"#...#",
"#.b.#",
"#####"
```

A valid output route string:

    RDDUUL

Explanation:

-   Robot starts at `S` (row 1, col 1).
-   `R` → moves to `a` (row 1, col 2), picks up book `a`.
-   `D` → moves to (row 2, col 2).
-   `D` → moves to `b` (row 3, col 2), picks up book `b`.
-   `U` → moves back to (row 2, col 2).
-   `U` → moves to former `a` tile (now empty) at (row 1, col 2).
-   `L` → moves back to `S` at (row 1, col 1).

All requested books `a` and `b` have been collected, and the robot
finishes at `S`.

There may be several valid shortest routes for a given layout. Any one
shortest route will be accepted.

### Example 2

Input (string array):

``` 
"########",
"#S..a..#",
"#..##..#",
"#..b..##",
"########"
```

One possible valid output:

    RRRRDDLLLUUL

As long as your path:

-   Starts and ends at `S`,
-   Visits `a` and `b` at least once,
-   Never goes through `#`,
-   Stays inside the grid,

it will be considered correct. 
