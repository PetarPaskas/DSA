




using System.Collections.Generic;
using System.Linq;

int[] testdata = [-1, 0, 1, 2, -1, -4];

//int[] test1 = [-1,0,1];
//int[] test2 = [0,1,-1];

//var test1Ordered = test1.OrderBy(x => x).ToList();
//var test2Ordered = test2.OrderBy(x => x).ToList();

//Console.WriteLine($"({test1Ordered[0]}, {test1Ordered[1]}, {test1Ordered[2]})");
//Console.WriteLine($"({test2Ordered[0]}, {test2Ordered[1]}, {test2Ordered[2]})");

foreach (var x in ThreeSum(testdata))
{
    Console.WriteLine($"({x[0]}, {x[1]}, {x[2]})");
}

List<List<int>> ThreeSum(int[] nums)
{
    HashSet<string> occurances = new HashSet<string>();

    List<List<int>> result = new List<List<int>>();

    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i+1; j < nums.Length; j++)
        {
            for (int k = j+1; k < nums.Length; k++)
            {
                if (nums[i] + nums[j] + nums[k] == 0)
                {
                    //string set = $"({nums[i]}, {nums[j]}, {nums[k]})";
                    var set = new List<int>() { nums[i], nums[j], nums[k] };
                    var orderedSet = set.OrderBy(x=>x).ToList();
                    var orderedSetString = $"({orderedSet[0]}, {orderedSet[1]}, {orderedSet[2]})";

                    if (!occurances.Contains(orderedSetString))
                    {
                        occurances.Add(orderedSetString);
                        result.Add(set);
                    }

                }
            }

        }
    }
    if(result.Count > 0)
    return result;

    return new List<List<int>>()
    {
        new List<int>(){0,0,0 }
    };
   
}
