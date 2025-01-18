// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

string[] sts = ["act", "pots", "tops", "cat", "stop", "hat"];

GroupAnagrams(sts);

List<List<string>> GroupAnagrams(string[] strs)
{
    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    foreach(string str in strs)
    {
        var ordered = GetOrdered(str);
        AddOrderedToResult(result, ordered, str);
    }

    return result.Values.ToList();
}

string GetOrdered(string str) => String.Concat(str.OrderBy(x => x));

void AddOrderedToResult(Dictionary<string, List<string>> result, string ordered, string source)
{
    if (!result.ContainsKey(ordered))
        result.Add(ordered, new List<string>());

    result[ordered].Add(source);

}