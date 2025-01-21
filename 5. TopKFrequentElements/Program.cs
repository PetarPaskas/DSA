// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

TopKFrequent([1, 2, 2, 3, 3, 3], 2);

int[] TopKFrequent(int[] nums, int k)
{
    var occurances = CountOccurances(nums);
    var ordered = occurances.OrderByDescending(x => x.Value);

    int[] res = new int[k];
    int i = 0;
    foreach(var o in ordered)
    {
        if (i == k)
            break;

        res[i] = o.Key;
        i++;
    }

    return res;
}

Dictionary<int, int> CountOccurances(int[] nums)
{
    Dictionary<int, int> result = new Dictionary<int, int>();
    foreach (int num in nums)
    {
        if (!result.ContainsKey(num))
            result.Add(num, 0);

        result[num]++;
    }
    return result;
}