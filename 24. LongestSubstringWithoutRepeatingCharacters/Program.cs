using System;

string s = "au";
Console.WriteLine(LengthOfLongestSubstring(s));
int LengthOfLongestSubstring(string s)
{
    if (String.IsNullOrEmpty(s))
        return 0;

    for (int i = 0; i < s.Length; i++)
    {
        int itemsSinceStart = s.Length - i;
        for (int j = 0; itemsSinceStart + j <= s.Length; j++)
        {
            int startIndex = j;

            var subString = s.Substring(startIndex, itemsSinceStart);
            HashSet<char> charHash = new HashSet<char>(subString);

            if (subString.Length == charHash.Count)
                return subString.Length;

        }

    }

    return 1;


}