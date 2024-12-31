using CodingPatterns.TwoPointers;

namespace CodingPatterns.Tests;

[TestClass]
public class TwoPointersTests
{
    private readonly PairSum _pairSum;
    private readonly TripletSum _tripletSum;
    private readonly PalindromeValid _palindromeValid;
    private readonly LargestContainer _largestContainer;
    private readonly ShiftZerosToTheEnd _shiftZerosToTheEnd;
    private readonly NextLexicographicalSequence _nextLexicographicalSequence;

    public TwoPointersTests()
    {
        _pairSum = new PairSum();
        _tripletSum = new TripletSum();
        _palindromeValid = new PalindromeValid();
        _largestContainer = new LargestContainer();
        _shiftZerosToTheEnd = new ShiftZerosToTheEnd();
        _nextLexicographicalSequence = new NextLexicographicalSequence();
    }

    [TestMethod]
    public void PairSum_Sorted_Brute_ForceTest()
    {
        // Arrange
        List<int> nums = [-5, -2, 3, 4, 6];
        int target = 7;

        // Act
        List<int> result = _pairSum.PairSum_Sorted_Brute_Force(nums, target);

        // Assert
        Assert.AreEqual("2,3", string.Join(",", result));
    }

    [TestMethod]
    public void PairSum_SortedTest()
    {
        // Arrange
        List<int> nums = [-5, -2, 3, 4, 6];
        int target = 7;

        // Act
        List<int> result = _pairSum.PairSum_Sorted(nums, target);

        // Assert
        Assert.AreEqual("2,3", string.Join(",", result));
    }

    [TestMethod]
    public void TripletSum_Brute_ForceTest()
    {
        // Arrange
        List<int> nums = [0, -1, 2, -3, 1];

        // Act
        List<List<int>> result = _tripletSum.TripletSum_Brute_Force(nums);

        // Assert
        Assert.AreEqual("-1,0,1", string.Join(",", result[0]));
        Assert.AreEqual("-3,1,2", string.Join(",", result[1]));
    }

    [TestMethod]
    public void TripletSum_OptimizedTest()
    {
        // Arrange
        List<int> nums = [0, -1, 2, -3, 1];

        // Act
        List<List<int>> result = _tripletSum.TripletSum_Optimized(nums);

        // Assert
        Assert.AreEqual("-3,1,2", string.Join(",", result[0]));
        Assert.AreEqual("-1,0,1", string.Join(",", result[1]));
    }

    [TestMethod]
    public void IsPalindomeValidTest()
    {
        // Arrange
        string s = "a dog! a panic in a pagoda";

        // Act
        bool result = _palindromeValid.IsPalindomeValid(s);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void LargestContainer_Brute_ForceTest()
    {
        // Arrange
        List<int> heights = [2, 7, 8, 3, 7, 6];

        // Act
        int result = _largestContainer.LargestContainer_Brute_Force(heights);

        // Assert
        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void LargestContainer_OptimizedTest()
    {
        // Arrange
        List<int> heights = [2, 7, 8, 3, 7, 6];

        // Act
        int result = _largestContainer.LargestContainer_Optimized(heights);

        // Assert
        Assert.AreEqual(24, result);
    }

    [TestMethod]
    public void ShiftZerosToTheEnd_NaiveTest()
    {
        // Arrange
        List<int> nums = [0, 1, 0, 3, 2];

        // Act
        _shiftZerosToTheEnd.ShiftZerosToTheEnd_Naive(nums);

        // Assert
        Assert.AreEqual("1,3,2,0,0", string.Join(",", nums));
    }

    [TestMethod]
    public void ShiftZerosToTheEnd_OptimizedTest()
    {
        // Arrange
        List<int> nums = [0, 1, 0, 3, 2];

        // Act
        _shiftZerosToTheEnd.ShiftZerosToTheEnd_Optimized(nums);

        // Assert
        Assert.AreEqual("1,3,2,0,0", string.Join(",", nums));
    }

    [TestMethod]
    public void NextLexicographicalSequence_OptimizedTest()
    {
        // Arrange
        string str = "abcd";

        // Act
        string result = _nextLexicographicalSequence.NextLexicographicalSequence_Optimized(str);

        // Assert
        Assert.AreEqual("abdc", result);
    }
}
  