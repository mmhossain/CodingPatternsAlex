using CodingPatterns.DynamicProgramming;

namespace CodingPatterns.Tests;

[TestClass]
public class DynamicProgrammingTests
{
    private readonly ClimbingStairs _climbingStairs;
    private readonly CoinCombination _coinCombination;

    public DynamicProgrammingTests()
    {
        _climbingStairs = new ClimbingStairs();
        _coinCombination = new CoinCombination();
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

    [TestMethod]
    public void MinCoinCombination_TopDownTest()
    {
        // Arrange
        List<int> coins = [1, 2, 3];
        int target = 5;

        // Act
        int result = _coinCombination.MinCoinCombination_TopDown(coins, target);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void MinCoinCombination_BottomUpTest()
    {
        // Arrange
        List<int> coins = [1, 2, 3];
        int target = 5;

        // Act
        int result = _coinCombination.MinCoinCombination_BottomUp(coins, target);

        // Assert
        Assert.AreEqual(2, result);
    }
}
  