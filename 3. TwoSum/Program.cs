// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] TwoSumBruteForce(int[] nums, int target)
{
    for(int i = 0; i < nums.Length; i++)
    {
        for(int j = 0; j < nums.Length; j++)
        {
            if ((nums[i] + nums[j]) == target)
                return new int[] { i, j };
        }
    }
    return null;
}



int[] TwoSumoN(int[] nums, int target)
{
    //1. hash {value, index}
    //2. for num in nums get difference = target - num
    //3. return if difference exists in hash
    //optimization: try for input ([5,5], 10)

    Dictionary<int, int> kvPairs = new Dictionary<int, int>();
    for(int i = 0; i<nums.Length;i++)
        kvPairs.TryAdd(nums[i], i);
       
    for(int i = 0; i < nums.Length; i++)
    {
        var difference = target - nums[i];
        if(kvPairs.ContainsKey(difference))
            return new int[] { i, kvPairs[difference] };
    }

    return null;
}