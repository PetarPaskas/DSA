public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<string> group = new Stack<string>();
        foreach (var item in tokens)
        {
            bool groupSeparator = IsOperation(item.ToString());

            if (!groupSeparator)
            {
                group.Push(item.ToString());
                continue;
            }

            int b = int.Parse(group.Pop());
            int a = int.Parse(group.Pop());

            group.Push(DoOperation(a, b, item).ToString());
        }

        return int.Parse(group.Pop());
    }

    private bool IsOperation(string item)
    {
        return item == "/"
            || item == "*"
            || item == "+"
            || item == "-";
    }
    private int DoOperation(int x, int y, string operation)
    {
        switch (operation)
        {
            case "+": return x + y;
            case "-": return x - y;
            case "*": return x * y;
            case "/": return x / y;
            default: return x / 0;
        }
    }
}
