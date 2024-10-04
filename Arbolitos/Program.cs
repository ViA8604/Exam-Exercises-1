public class BinaryTree
{
    public int Value { get; set; }
    public BinaryTree Left { get; set; }
    public BinaryTree Right { get; set; }

    public BinaryTree(BinaryTree? left = null, BinaryTree? right = null)
    {
        if (left.Value > right.Value)
        {
            throw new ArgumentException("Left value must be less than right value");
        }
        Left = left;
        Right = right;
    }

    public BinaryTree SearchValue(int x)
    {
        if (this.Value == x)
        {
            return this;
        }

        else
        {
            if (x < this.Value)
            {
                if (Left == null)
                {
                    return this;
                }
                return Left.SearchValue(x);
            }
            else
            {
                if (Right == null)
                {
                    return this;
                }
                return Right.SearchValue(x);
            }
        }
    }

    public void InsertValue(int x)
    {
        BinaryTree nodeToInsert = SearchValue(x);
        if (x < nodeToInsert.Value)
        {
            nodeToInsert.Left = new BinaryTree();
            nodeToInsert.Left.Value = x;
        }
        if (x > nodeToInsert.Value)
        {
            nodeToInsert.Right = new BinaryTree();
            nodeToInsert.Right .Value = x;
        }
    }
}

public class Tree
{
    public List<Tree> Children { get; set; }

    public Tree(List<Tree>? children = null)
    {
        Children = children ?? new List<Tree>();
    }

    public int CountSize()
    {
        int totalSize = 1;
        foreach (var child in Children)
        {
            totalSize += child.CountSize();
        }
        return totalSize;
    }

    public int GetHeight()
    {
        int totalHeight = 0;
        if (Children.Count == 0)
        {
            return 0;
        }
        else
        {
            foreach (var child in Children)
            {
                totalHeight = Math.Max(totalHeight, child.GetHeight() + 1);
            }
        }
        return totalHeight;
    }
}