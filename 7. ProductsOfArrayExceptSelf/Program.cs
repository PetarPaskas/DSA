




var res = ProductExceptSelf([-1, 1, 0, -3, 3]);


Console.WriteLine(String.Join(", ",res));


int[] ProductExceptSelf(int[] nums)
{
    int max = 1;
    bool hadZero = false;
    int indexOfZero = -1;


    for (int i = 0; i < nums.Length; i++)
    {
        int current = nums[i];


        if (current == 0 && hadZero)
        {
            return new int[nums.Length];
        }

        if (current == 0 && !hadZero)
        {
            hadZero = true;
            indexOfZero = i;
            continue;
        }

        max *= current;
    }

    int[] result = new int[nums.Length];

    if(indexOfZero != -1)
    {
        result[indexOfZero] = max;
        return result;
    }

    for (int i = 0; i < nums.Length; i++)
    {
        int current = nums[i];

        result[i] = max / current;
    }

    return result;
}