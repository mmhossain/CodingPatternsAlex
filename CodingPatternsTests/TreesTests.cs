using CodingPatterns.Trees;
using Domain;

namespace CodingPatterns.Tests;

[TestClass]
public class TreesTests
{
    private readonly Dfs _dfs;
    private readonly Bfs _bfs;
    private readonly InvertBinaryTree _invertBT;
    private readonly BalancedBinaryTreeValidation _balancedBT;
    private readonly RightmostNodesOfBinaryTree _rightMostNodes;
    private readonly WidestBinaryTreeLevel _widestBinaryTreeLevel;
    private readonly BinarySearchTreeValidation _bstSearchValidation;

    public TreesTests()
    {
        _dfs = new Dfs();
        _bfs = new Bfs();
        _invertBT = new InvertBinaryTree();
        _balancedBT = new BalancedBinaryTreeValidation();
        _rightMostNodes = new RightmostNodesOfBinaryTree();
        _widestBinaryTreeLevel = new WidestBinaryTreeLevel();
        _bstSearchValidation = new BinarySearchTreeValidation();
    }

    [TestMethod]
    public void Dfs_PreorderTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(4)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(3)
            },
            Right = new BTTreeNode(5)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(7)
            }
        };

        // Act
        List<int> result = _dfs.Dfs_Preorder(root);

        // Assert
        Assert.AreEqual("4,2,1,3,5,6,7", string.Join(",", result));
    }

    [TestMethod]
    public void Dfs_InorderTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(4)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(3)
            },
            Right = new BTTreeNode(5)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(7)
            }
        };

        // Act
        List<int> result = _dfs.Dfs_Inorder(root);

        // Assert
        Assert.AreEqual("1,2,3,4,6,5,7", string.Join(",", result));
    }

    [TestMethod]
    public void Dfs_PostorderTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(4)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(3)
            },
            Right = new BTTreeNode(5)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(7)
            }
        };

        // Act
        List<int> result = _dfs.Dfs_Postorder(root);

        // Assert
        Assert.AreEqual("1,3,2,6,7,5,4", string.Join(",", result));
    }

    [TestMethod]
    public void Bfs_Test()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(4)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(3)
            },
            Right = new BTTreeNode(5)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(7)
            }
        };

        // Act
        List<int> result = _bfs.Bfs_Template(root);

        // Assert
        Assert.AreEqual("4,2,5,1,3,6,7", string.Join(",", result));
    }

    [TestMethod]
    public void InvertBinaryTree_Recustive_dfsTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(1)
            {
                Left = new BTTreeNode(7),
                Right = new BTTreeNode(6)
            },
            Right = new BTTreeNode(8)
            {
                Right = new BTTreeNode(4)
            }
        };

        // Act
        BTTreeNode updatedRoot = _invertBT.InvertBinaryTree_Recustive_dfs(root);

        // Assert
        Assert.AreEqual(5, updatedRoot.Value);
        Assert.AreEqual(8, updatedRoot.Left.Value);
        Assert.AreEqual(1, updatedRoot.Right.Value);
        Assert.AreEqual(4, updatedRoot.Left.Left.Value);
        Assert.AreEqual(6, updatedRoot.Right.Left.Value);
        Assert.AreEqual(7, updatedRoot.Right.Right.Value);
    }

    [TestMethod]
    public void InvertBinaryTree_Iterative_dfsTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(1)
            {
                Left = new BTTreeNode(7),
                Right = new BTTreeNode(6)
            },
            Right = new BTTreeNode(8)
            {
                Right = new BTTreeNode(4)
            }
        };

        // Act
        BTTreeNode updatedRoot = _invertBT.InvertBinaryTree_Iterative_dfs(root);

        // Assert
        Assert.AreEqual(5, updatedRoot.Value);
        Assert.AreEqual(8, updatedRoot.Left.Value);
        Assert.AreEqual(1, updatedRoot.Right.Value);
        Assert.AreEqual(4, updatedRoot.Left.Left.Value);
        Assert.AreEqual(6, updatedRoot.Right.Left.Value);
        Assert.AreEqual(7, updatedRoot.Right.Right.Value);
    }

    [TestMethod]
    public void ValidateBalancedBinaryTreeTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(4)
                {
                    Left = new BTTreeNode(3)
                }
            },
            Right = new BTTreeNode(7)
            {
                Right = new BTTreeNode(9)
                {
                    Left = new BTTreeNode(6)
                }
            }
        };

        // Act
        bool isBalanced = _balancedBT.ValidateBalancedBinaryTree(root);

        // Assert
        Assert.IsFalse(isBalanced);
    }

    [TestMethod]
    public void RightmostNodesOfABinaryTreeTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(1)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(4)
                {
                    Left = new BTTreeNode(8),
                    Right = new BTTreeNode(9)
                },
                Right = new BTTreeNode(5)
                {
                    Right = new BTTreeNode(11)
                }
            },
            Right = new BTTreeNode(3)
            {
                Left = new BTTreeNode(6)
            }
        };

        // Act
        List<int> result = _rightMostNodes.RightmostNodesOfABinaryTree(root);

        // Assert
        Assert.AreEqual("1,3,6,11", string.Join(",", result));
    }

    [TestMethod]
    public void WidestLevelOfABinaryTreeTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(1)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(4)
                {
                    Left = new BTTreeNode(8),
                    Right = new BTTreeNode(9)
                },
                Right = new BTTreeNode(5)
                {
                    Right = new BTTreeNode(11)
                }
            },
            Right = new BTTreeNode(3)
            {
                Right = new BTTreeNode(7)
                {
                    Left = new BTTreeNode(14)
                }
            }
        };

        // Act
        int result = _widestBinaryTreeLevel.WidestLevelOfABinaryTree(root);

        // Assert
        Assert.AreEqual(7, result);
    }

    [TestMethod]
    public void ValidateBinarySearchTreeTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(6)
            },
            Right = new BTTreeNode(7)
            {
                Left = new BTTreeNode(7),
                Right = new BTTreeNode(9)
            }
        };

        // Act
        bool isValid = _bstSearchValidation.ValidateBinarySearchTree(root);

        // Assert
        Assert.IsFalse(isValid);
    }
}
  