using CodingPatterns.DynamicProgramming;
using Domain;

namespace CodingPatterns.Tests;

[TestClass]
public class DynamicProgrammingTests
{
    private readonly ClimbingStairs _climbingStairs;

    public DynamicProgrammingTests()
    {
        _climbingStairs = new ClimbingStairs();
    }

    [TestMethod]
    public void ClimbingStairs_TopDownTest()
    {
        // Arrange
        int n = 4;

        // Act
        int result = _climbingStairs.ClimbingStairs_TopDown(n);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void ClimbingStairs_BottomUpTest()
    {
        // Arrange
        int n = 4;

        // Act
        int result = _climbingStairs.ClimbingStairs_BottomUp(n);

        // Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public void ClimbingStairs_BottomUp_OptimizedTest()
    {
        // Arrange
        int n = 4;

        // Act
        int result = _climbingStairs.ClimbingStairs_BottomUp_Optimized(n);

        // Assert
        Assert.AreEqual(5, result);
    }
}
  