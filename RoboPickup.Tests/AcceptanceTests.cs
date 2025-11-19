using Xunit;

namespace RoboPickup.Tests;

public class AcceptanceTests
{
    private readonly ILibraryRoutePlanner _libraryRoutePlanner;

    public AcceptanceTests()
    {
        this._libraryRoutePlanner = new LibraryRoutePlanner();
    }

    [Fact]
    public void SimpleTestCase()
    {
        var test = new[] 
        {
            "#####",
            "#Sa.#",
            "#...#",
            "#.b.#",
            "#####"
        };

        var result = this._libraryRoutePlanner.Start(test);

        Assert.Equal("RDDUUL", result);
    }

    [Fact]
    public void IntermediateTestCase()
    {
        var test = new[] 
        {
            "########",
            "#S..a..#",
            "#..##..#",
            "#..b..##",
            "########"
        };

        var result = this._libraryRoutePlanner.Start(test);

        Assert.Equal("RRRRDDLLLUUL", result);
    }

    [Fact]
    public void ComplexTestCase()
    {
        var test = new[]
        {
            "##################",
            "#S..a........b..##",
            "#.####.#.#.###..##",
            "#..c..#.#...#..d.#",
            "##.#..#.#.#.#.####",
            "#..#..#...#.#....#",
            "#..#######.#.##..#",
            "#e....f..#.#..g..#",
            "##################",
        };

        var result = this._libraryRoutePlanner.Start(test);

        Assert.Equal("[Insert your solution here.]", result);
    }

    [Fact]
    public void ImpossibleTestCase()
    {
        var test = new[]
        {
            "#######",
            "#S....#",
            "#.###.#",
            "#.#a#.#",
            "#.###.#",
            "#.....#",
            "#######"
        };

        var result = this._libraryRoutePlanner.Start(test);

        Assert.Equal(string.Empty, result);
    }
}