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
    private readonly LowestCommonAncestor _lca;
    private readonly BuildBTFromPreAndInOrder _buildTree;
    private readonly MaximumPathSumOfBT _maxSumOfBT;
    private readonly BinaryTreeSymmetry _btSymmetry;
    private readonly BinaryTreeColumns _btColums;
    private readonly KthSmallestInBinaryTree _kthSmallest;
    private readonly SerializeAndDeserializeBT _serializeDeserializeBT;

    public TreesTests()
    {
        _dfs = new Dfs();
        _bfs = new Bfs();
        _invertBT = new InvertBinaryTree();
        _balancedBT = new BalancedBinaryTreeValidation();
        _rightMostNodes = new RightmostNodesOfBinaryTree();
        _widestBinaryTreeLevel = new WidestBinaryTreeLevel();
        _bstSearchValidation = new BinarySearchTreeValidation();
        _lca = new LowestCommonAncestor();
        _buildTree = new BuildBTFromPreAndInOrder();
        _maxSumOfBT = new MaximumPathSumOfBT();
        _btSymmetry = new BinaryTreeSymmetry();
        _btColums = new BinaryTreeColumns();
        _kthSmallest = new KthSmallestInBinaryTree();
        _serializeDeserializeBT = new SerializeAndDeserializeBT();
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

    [TestMethod]
    public void LcaTest()
    {
        // Arrange
        BTTreeNode node7 = new BTTreeNode(7);
        BTTreeNode node8 = new BTTreeNode(8);

        BTTreeNode root = new BTTreeNode(1)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(4),
                Right = new BTTreeNode(5)
            },
            Right = new BTTreeNode(3)
            {
                Left = new BTTreeNode(6)
                {
                    Left = node8,
                    Right = new BTTreeNode(9)
                },
                Right = node8
            }
        };

        // Act
        BTTreeNode lca = _lca.Lca(root, node7, node8);

        // Assert
        Assert.IsNotNull(lca);
        Assert.AreEqual(3, lca.Value);
    }

    [TestMethod]
    public void BuildTreeFromPreorderAndInorderTest()
    {
        // Arrange
        List<int> preorder = [5, 9, 2, 3, 4, 7];
        List<int> inorder = [2, 9, 5, 4, 3, 7];

        // Act
        BTTreeNode root = _buildTree.BinaryTreeFromPreOrderAndInOrderTraversal(preorder, inorder);

        // Assert
        Assert.IsNotNull(root);
        Assert.AreEqual(5, root.Value);
        Assert.AreEqual(9, root.Left.Value);
        Assert.AreEqual(3, root.Right.Value);
        Assert.AreEqual(2, root.Left.Left.Value);
        Assert.AreEqual(4, root.Right.Left.Value);
        Assert.AreEqual(7, root.Right.Right.Value);
    }

    [TestMethod]
    public void MaxPathSumTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(-10)
            {
                Left = new BTTreeNode(1)
                {
                    Left = new BTTreeNode(11)
                },
                Right = new BTTreeNode(-7)
                {
                    Left = new BTTreeNode(-1)
                }
            },
            Right = new BTTreeNode(8)
            {
                Left = new BTTreeNode(9),
                Right = new BTTreeNode(7)
                {
                    Left = new BTTreeNode(6),
                    Right = new BTTreeNode(-3)
                }
            }
        };

        // Act
        int maxSum = _maxSumOfBT.MaxPathSum(root);

        // Assert
        Assert.AreEqual(30, maxSum);
    }

    [TestMethod]
    public void IsBinaryTreeSymmetryicTest()
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
            Right = new BTTreeNode(2)
            {
                Left = new BTTreeNode(4)
                {
                    Right = new BTTreeNode(3)
                },
                Right = new BTTreeNode(1)
            }
        };

        // Act
        bool isSymmetric = _btSymmetry.IsBinaryTreeSymmetryic(root);

        // Assert
        Assert.IsTrue(isSymmetric);
    }

    [TestMethod]
    public void TraverseBTColumnwiseTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(9)
            {
                Left = new BTTreeNode(2),
                Right = new BTTreeNode(1)
            },
            Right = new BTTreeNode(3)
            {
                Left = new BTTreeNode(4),
                Right = new BTTreeNode(7)
            }
        };

        // Act
        List<List<int>> result = _btColums.TraverseBTColumnwise(root);

        // Assert
        Assert.AreEqual("2", string.Join(",", result[0]));
        Assert.AreEqual("9", string.Join(",", result[1]));
        Assert.AreEqual("5,1,4", string.Join(",", result[2]));
        Assert.AreEqual("3", string.Join(",", result[3]));
        Assert.AreEqual("7", string.Join(",", result[4]));
    }

    [TestMethod]
    public void FindKthSmallestInBT_RecursiveTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(4)
            },
            Right = new BTTreeNode(7)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(9)
            }
        };
        
        int k = 5;

        // Act
        int result = _kthSmallest.FindKthSmallestInBT_Recursive(root, k);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void FindKthSmallestInBT_IterativeTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(2)
            {
                Left = new BTTreeNode(1),
                Right = new BTTreeNode(4)
            },
            Right = new BTTreeNode(7)
            {
                Left = new BTTreeNode(6),
                Right = new BTTreeNode(9)
            }
        };

        int k = 5;

        // Act
        int result = _kthSmallest.FindKthSmallestInBT_Iterative(root, k);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void SerializeBTTest()
    {
        // Arrange
        BTTreeNode root = new BTTreeNode(5)
        {
            Left = new BTTreeNode(9)
            {
                Left = new BTTreeNode(2)
                {
                    Left = new BTTreeNode(11)
                }
            },
            Right = new BTTreeNode(3)
            {
                Left = new BTTreeNode(4)
                {
                    Right = new BTTreeNode(6)
                },
                Right = new BTTreeNode(7)
            }
        };

        // Act
        string result = _serializeDeserializeBT.Serialize(root);

        // Assert
        Assert.AreEqual("5,9,2,11,#,#,#,#,3,4,#,6,#,#,7,#,#", result);
    }

    [TestMethod]
    public void DeserializeBTTest()
    {
        // Arrange
        string data = "5,9,2,11,#,#,#,#,3,4,#,6,#,#,7,#,#";

        // Act
        BTTreeNode root = _serializeDeserializeBT.Deserialize(data);

        // Assert
        Assert.IsNotNull(root);
        Assert.AreEqual(5, root.Value);
        Assert.AreEqual(9, root.Left.Value);
        Assert.AreEqual(3, root.Right.Value);
        Assert.AreEqual(2, root.Left.Left.Value);
        Assert.AreEqual(11, root.Left.Left.Left.Value);
        Assert.AreEqual(4, root.Right.Left.Value);
        Assert.AreEqual(7, root.Right.Right.Value);
        Assert.AreEqual(6, root.Right.Left.Right.Value);
    }
}
  