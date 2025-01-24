// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//array of nums sorted in ascending
foreach(var x in TwoSum([1,2,3,4],3))
{
    Console.WriteLine(x);
}
int[] TwoSum(int[] numbers, int target)
{
    for(int i = 0; i < numbers.Length; i++)
    {

        for (int j = i + 1; j < numbers.Length; j++) 
        {

            if ((numbers[i] + numbers[j]) == target)
                return [i + 1, j + 1];
        }

    }

    return [];
}