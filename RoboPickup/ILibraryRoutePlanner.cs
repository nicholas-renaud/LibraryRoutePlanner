namespace RoboPickup;

public interface ILibraryRoutePlanner
{
    /// <summary>
    /// Computes a route for the library robot.
    /// </summary>
    /// <param name="grid">
    /// An array representing the library grid.
    /// </param>
    /// <returns>
    /// A string made only of the characters 'U', 'D', 'L', 'R',
    /// representing the sequence of moves the robot must perform.
    /// </returns>
    string Start(string[] grid);
}