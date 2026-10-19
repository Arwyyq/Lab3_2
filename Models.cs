using System.Diagnostics.Contracts;

public class MyString
{
    public string Value { get; set; }
    public int Length => Value?.Length ?? 0;

    public MyString(string value)
    {
        Value = value;
    }

    public void Print(int index = 0)
    {
        if (index > 0)
        {
            Console.WriteLine($"Рядок [{index}]: {Value}, Довжина: {Length}");
        }
        else
        {
            Console.WriteLine($"Рядок: {Value}, Довжина: {Length}");
        }

    }


    public bool searchSub(string sub) //Метод приймає шуканий текст
    {
        return Value.Contains(sub);
    }

    public void insetSub(int index, string sub)
    {
        Value = Value.Insert(index, sub);
    }

    public void replaceSub(string oldValue, string newValue)
    {
        Value = Value.Replace(oldValue, newValue);
    }
}

public class TreeNode
{
    public MyString Data { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(MyString data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    public TreeNode? Root { get; set; }

    public void Insert(MyString data)
    {
        Root = InsertRec(Root, data);
    }

    private TreeNode InsertRec(TreeNode? root, MyString data)
    {
        if (root == null)
        {
            return new TreeNode(data);
        }

        int compareResult = string.Compare(data.Value, root.Data.Value, StringComparison.Ordinal);

        if (compareResult < 0)
            root.Left = InsertRec(root.Left, data);
        else if (compareResult > 0)
            root.Right = InsertRec(root.Right, data);

        return root;
    }

    public void PrintTree(TreeNode? node, string indent = "", string side = "Root", bool isLast = true)
    {
        if (node == null) return;

        Console.Write(indent);
        if (side != "Root")
        {
            Console.Write(isLast ? "└── " : "├── ");
            indent += isLast ? "    " : "│   ";
        }

        string tag = side == "Root" ? "[Корень]" : (side == "L" ? "[Л]" : "[П]");
        Console.WriteLine($"{tag} {node.Data.Value} (Довжина: {node.Data.Length})");

        List<(TreeNode Node, string Side)> children = new List<(TreeNode, string)>();
        if (node.Left != null) children.Add((node.Left, "L"));
        if (node.Right != null) children.Add((node.Right, "R"));

        for (int i = 0; i < children.Count; i++)
        {
            PrintTree(children[i].Node, indent, children[i].Side, i == children.Count - 1);
        }
    }
}