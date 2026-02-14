public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO: Problem 1 - Insert Unique Values Only

        if (value == Data)
        {
            // Value already exists, do nothing
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Check if value matches current node
        if (value == Data)
        {
            return true;
        }

        // Search Left
        if (value < Data)
        {
            if (Left != null)
                return Left.Contains(value);
        }
        // Search Right
        else
        {
            if (Right != null)
                return Right.Contains(value);
        }

        // Not found
        return false;
    }

    public int GetHeight()
    {
        // TODO: Problem 4 - Tree Height
        // Calculate the height of the left and right subtrees
        // If a side is null, its height is 0.
        int leftHeight = (Left == null) ? 0 : Left.GetHeight();
        int rightHeight = (Right == null) ? 0 : Right.GetHeight();

        // The height is 1 (for this node) + the maximum of the children's heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
