
int LongestConsecutive(int[] nums)
{
    HashSet<int> sequences = new HashSet<int>(nums);
    int longest = 0;

    foreach (var num in nums)
    {
        var current = num;
        var count = 1;
        while (sequences.Contains(current + 1))
        {
            current += 1;
            count += 1;
        }

        if (count > longest)
            longest = count;
    }
    return longest;
}


//O(n)
int LongestConsecutive(int[] nums)
{
    HashSet<int> sequences = new HashSet<int>(nums);
    int longest = 0;

    foreach (var num in sequences)
    {
        var current = num;
        var count = 1;

        if (!sequences.Contains(current - 1))
        {
            while(sequences.Contains(current + 1))
            {
                current++;
                count += 1;
            }
        }

        if (count > longest)
            longest = count;
    }
    return longest;
}