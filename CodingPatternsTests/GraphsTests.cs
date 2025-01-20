using CodingPatterns.Trees;
using Domain;
using System.Diagnostics;

namespace CodingPatterns.Tests;

[TestClass]
public class GraphsTests
{
    private readonly GraphDeepCopy _deepCopy;
    private readonly CountIslands _islands;
    private readonly MatrixInfection _matrixInfection;
    private readonly BipartiteGraph _bipartiteGraph;
    private readonly LongestIncreasingPath _longestIncreasingPath;
    private readonly ShortestTransformationSequence _shortestTransformationSequence;
    private MergingCommunities _mergingCommunities = null;
    private readonly Prerequisites _prerequisites;

    public GraphsTests()
    {
        _deepCopy = new GraphDeepCopy();
        _islands = new CountIslands();
        _matrixInfection = new MatrixInfection();
        _bipartiteGraph = new BipartiteGraph();
        _longestIncreasingPath = new LongestIncreasingPath();
        _shortestTransformationSequence = new ShortestTransformationSequence();
        _prerequisites = new Prerequisites();
    }

    [TestMethod]
    public void DeepCopyOfAGraphTest()
    {
        // Arrange
        GraphNode node0 = new GraphNode(0);
        GraphNode node1 = new GraphNode(1);
        GraphNode node2 = new GraphNode(2);
        GraphNode node3 = new GraphNode(3);
        node0.Neighbors = [node1, node2];
        node1.Neighbors = [node0, node2];
        node2.Neighbors = [node0, node1, node3];
        node3.Neighbors = [node2];

        // Act
        GraphNode clonedGraph = _deepCopy.DeepCopyOfAGraph(node0);

        // Assert
        Assert.AreEqual(0, clonedGraph.Value);
        Assert.AreEqual(1, clonedGraph.Neighbors[0].Value);
        Assert.AreEqual(2, clonedGraph.Neighbors[1].Value);
        Assert.AreEqual(0, clonedGraph.Neighbors[1].Neighbors[0].Value);
        Assert.AreEqual(1, clonedGraph.Neighbors[1].Neighbors[1].Value);
        Assert.AreEqual(3, clonedGraph.Neighbors[1].Neighbors[2].Value);
    }

    [TestMethod]
    public void CountNumberOfIslandsTest()
    {
        // Arrange
        int[][] matrix = [
            [1, 1, 0, 0],    
            [1, 1, 0, 0],    
            [0, 0, 1, 1],    
            [0, 0, 0, 1]
        ];

        // Act
        int islandCount = _islands.CountNumberOfIslands(matrix);

        // Assert
        Assert.AreEqual(2, islandCount);
    }

    [TestMethod]
    public void CountNumberOfSecondsTest()
    {
        // Arrange
        int[][] matrix = [
            [1, 1, 1, 0],
            [0, 0, 2, 1],
            [0, 1, 1, 0]
        ];

        // Act
        int seconds = _matrixInfection.CountNumberOfSeconds(matrix);

        // Assert
        Assert.AreEqual(3, seconds);
    }

    [TestMethod]
    public void IsBipartiteGraphTest()
    {
        // Arrange
        List<List<int>> graph = [
            [1, 4],
            [0, 2],
            [1],
            [4],
            [0, 3]
        ];

        // Act
        bool isBipartite = _bipartiteGraph.IsBipartiteGraph(graph);

        // Assert
        Assert.IsTrue(isBipartite);
    }

    [TestMethod]
    public void LongestIncreasingPathLengthTest()
    {
        // Arrange
        int[][] matrix = [
            [1, 5, 8],    
            [3, 4, 4],    
            [7, 9, 2]
        ];

        // Act
        int maxPathLen = _longestIncreasingPath.LongestIncreasingPathLength(matrix);

        // Assert
        Assert.AreEqual(5, maxPathLen);
    }

    [TestMethod]
    public void ShortestTransformationSequenceLengthTest()
    {
        // Arrange
        string start = "red", end = "hit";
        List<string> dictionary = ["red", "bed", "hat", "rod", "rad", "rat", "hit", "bad", "bat"];

        // Act
        int maxLen = 
            _shortestTransformationSequence.ShortestTransformationSequenceLength(
                start, end, dictionary);

        // Assert
        Assert.AreEqual(5, maxLen);
    }

    [TestMethod]
    public void ShortestTransformationSequenceLength_OptimizedTest()
    {
        // Arrange
        string start = "red", end = "hit";
        List<string> dictionary = ["red", "bed", "hat", "rod", "rad", "rat", "hit", "bad", "bat"];

        // Act
        int maxLen =
            _shortestTransformationSequence.ShortestTransformationSequenceLength_Optimized(
                start, end, dictionary);

        // Assert
        Assert.AreEqual(5, maxLen);
    }

    [TestMethod]
    public void MergingCommunitiesTest()
    {
        // Arrange
        _mergingCommunities = new MergingCommunities(5);

        // Act & Assert
        _mergingCommunities.Connect(0, 1);
        _mergingCommunities.Connect(1, 2);
        Assert.AreEqual(1, _mergingCommunities.GetCommunitySize(3));
        Assert.AreEqual(3, _mergingCommunities.GetCommunitySize(0));

        _mergingCommunities.Connect(3, 4);
        Assert.AreEqual(2, _mergingCommunities.GetCommunitySize(4));
    }

    [TestMethod]
    public void CanEnrollInAllCoursesTest()
    {
        // Arrange
        int n = 6;
        List<List<int>> prerequisites = [[0, 1], [0, 2], [3, 2], [1, 4], [2, 4], [4, 5]];

        // Act
        bool canEnroll = _prerequisites.CanEnrollInAllCourses(n, prerequisites);

        // Assert
        Assert.IsTrue(canEnroll);
    }
}
  