using CodingPatterns.BinarySearch;

namespace CodingPatterns.Tests;

[TestClass]
public class BinarySearchTests
{
    private readonly InsertionIndex _insertionIndex;
    private readonly FirstLastOccurences _firstLastOccurences;
    private readonly CuttingWood _cuttingWood;
    private readonly RotatedSortedArray _rotatedSortedArray;
    private readonly MedianTwoSortedArrays _medianTwoSortedArrays;
    private readonly MatrixSearch _matrixSearch;
    private readonly LocalMaxima _localMaxima;
    private WeightedRandomSelection _weightedRandomSelection;

    public BinarySearchTests()
    {
        _insertionIndex = new InsertionIndex();
        _firstLastOccurences = new FirstLastOccurences();
        _cuttingWood = new CuttingWood();
        _rotatedSortedArray = new RotatedSortedArray();
        _medianTwoSortedArrays = new MedianTwoSortedArrays();
        _matrixSearch = new MatrixSearch();
        _localMaxima = new LocalMaxima();
    }

    [TestMethod]
    public void FindTheInsertionIndexTest()
    {
        // Arrange
        List<int> nums = [1, 2, 4, 5, 7, 8, 9];
        int target = 6;

        // Act
        int result = _insertionIndex.FindTheInsertionIndex(nums, target);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void FindFirstLastOccurencesOfANumberTest()
    {
        // Arrange
        List<int> nums = [1, 2, 3, 4, 4, 4, 5, 6, 7, 8, 9, 10, 11];
        int target = 4;

        // Act
        int[] result = _firstLastOccurences.FindFirstLastOccurencesOfANumber(nums, target);

        // Assert
        Assert.AreEqual("3,5", string.Join(",", result));
    }

    [TestMethod]
    public void FindMaxHeightTest()
    {
        // Arrange
        List<int> nums = [2, 6, 3, 8];
        int k = 7;

        // Act
        int result = _cuttingWood.FindMaxHeight(nums, k);

        // Assert
        Assert.AreEqual(3, result);
    }

    [TestMethod]
    public void FindInRotatedSortedArrayTest()
    {
        // Arrange
        List<int> nums = [8, 9, 1, 2, 3, 4, 5, 6, 7];
        int target = 1;

        // Act
        int result = _rotatedSortedArray.FindInRotatedSortedArray(nums, target);

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void FindMedianFromTwoSortedArraysTest()
    {
        // Arrange
        List<int> nums1 = [0, 2, 5, 6, 8];
        List<int> nums2 = [1, 3, 7];

        // Act
        double result = _medianTwoSortedArrays.FindMedianFromTwoSortedArrays(nums1, nums2);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void FindInSortedMatrixTest()
    {
        // Arrange
        int[][] matrix = [
            [2, 3, 4, 6],
            [7, 10, 11, 17],
            [20, 21, 24, 33]
        ];

        int target = 21;

        // Act
        bool result = _matrixSearch.FindInSortedMatrix(matrix, target);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void FindLocalMaximaTest()
    {
        // Arrange
        List<int> nums = [1, 4, 3, 2, 3];

        // Act
        int result = _localMaxima.FindLocalMaxima(nums);

        // Assert
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void SelectRandomTest()
    {
        // Arrange
        List<int> nums = [3, 1, 2, 4];
        _weightedRandomSelection = new WeightedRandomSelection(nums);

        // Act
        int result = _weightedRandomSelection.Select();

        // Assert
        Assert.IsTrue(result >= 0 && result < nums.Count);
    }
}
  