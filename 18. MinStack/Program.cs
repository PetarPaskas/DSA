
var s = new MinStack();
s.Push(1);
s.Push(2);
s.Push(0);
Console.WriteLine(s.GetMin());
s.Pop();
Console.WriteLine(s.Top());
Console.WriteLine(s.GetMin());

public class MinStack
{
    private List<int> items;
    int indexAtMin = -1;

    public MinStack()
    {
        items = new List<int>();
    }

    public void Push(int val)
    {
        items.Add(val);

        if (indexAtMin == -1)
        {
            indexAtMin = 0;
            return;
        }

        if (val < items[indexAtMin])
            indexAtMin = items.Count-1;
    }

    public void Pop()
    {

        items.RemoveAt(items.Count - 1);

        if (items.Count == indexAtMin)
            OrderSmallest();
    }

    public int Top()
    {
        return items[items.Count - 1];
    }

    public int GetMin()
    {
        if (indexAtMin == -1)
            return 0;

        return items[indexAtMin];
    }

    private void OrderSmallest()
    {
        if (items.Count == 0)
        {
            indexAtMin = -1;
            return;
        }

        int smallest = items[0];
        int index = 0;
        indexAtMin = index;

        foreach(var x in items)
        {
            if (smallest > x)
            {
                smallest = x;
                indexAtMin = index;
            }
            index++;
        }
    }
}
