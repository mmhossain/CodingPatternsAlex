using Domain;

namespace CodingPatterns.Tests;

[TestClass]
public class SortAndSearchTests
{
    private readonly SortAndSearch _sortAndSearch;

    public SortAndSearchTests()
    {
        _sortAndSearch = new SortAndSearch();
    }

    [TestMethod]
    public void SortLinkedList_MergeSortTest()
    {
        // Arrange
        ListNode head = new ListNode(3)
        {
            Next = new ListNode(2)
            {
                Next = new ListNode(4)
                {
                    Next = new ListNode(5)
                    {
                        Next = new ListNode(1)
                    }
                }
            }
        };

        // Act
        ListNode mergedHead = _sortAndSearch.SortLinkedList_MergeSort(head);

        // Assert
        Assert.IsNotNull(mergedHead);
        Assert.AreEqual(1, mergedHead.Val);
        Assert.AreEqual(2, mergedHead.Next.Val);
        Assert.AreEqual(3, mergedHead.Next.Next.Val);
        Assert.AreEqual(4, mergedHead.Next.Next.Next.Val);
        Assert.AreEqual(5, mergedHead.Next.Next.Next.Next.Val);
    }

    [TestMethod]
    public void SortArray_QuickSortTest()
    {
        // Arrange
        List<int> nums = [6, 8, 4, 2, 7, 3, 1, 5];

        // Act
        List<int> sortedNums = _sortAndSearch.SortArray_QuickSort(nums);

        // Assert
        Assert.AreEqual("1,2,3,4,5,6,7,8", string.Join(",", sortedNums));
    }

    [TestMethod]
    public void SortArray_QuickSort_OptimizedTest()
    {
        // Arrange
        List<int> nums = [6, 8, 4, 2, 7, 3, 1, 5];

        // Act
        List<int> sortedNums = _sortAndSearch.SortArray_QuickSort_Optimized(nums);

        // Assert
        Assert.AreEqual("1,2,3,4,5,6,7,8", string.Join(",", sortedNums));
    }

    [TestMethod]
    public void SortArray_CountingSortTest()
    {
        // Arrange
        List<int> nums = [2, 1, 0, 0, 2, 4, 2];

        // Act
        List<int> sortedNums = _sortAndSearch.SortArray_CountingSort(nums);

        // Assert
        Assert.AreEqual("0,0,1,2,2,2,4", string.Join(",", sortedNums));
    }

    [TestMethod]
    public void KthLargestNumber_MinHeapTest()
    {
        // Arrange
        List<int> nums = [5, 2, 4, 3, 1, 6];

        // Act
        int result = _sortAndSearch.KthLargestNumber_MinHeap(nums, 3);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void KthLargestNumber_QuickSelectTest()
    {
        // Arrange
        List<int> nums = [5, 2, 4, 3, 1, 6];

        // Act
        int result = _sortAndSearch.KthLargestNumber_QuickSelect(nums, 3);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void DutchNationalFlagTest()
    {
        // Arrange
        List<int> nums = [2, 0, 1, 2, 0, 0, 1];

        // Act
        _sortAndSearch.DutchNationalFlag(nums);

        // Assert
        Assert.AreEqual("0,0,0,1,1,2,2", string.Join(",", nums));
    }
}
  