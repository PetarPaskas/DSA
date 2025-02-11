






using System.Text;

string s = "ABAB";

var res = CharacterReplacement(s, 2);
Console.WriteLine(res);

int CharacterReplacement(string s, int k)
{
    int maxTotal = 0;

    for (int currLetter = 65; currLetter <= 90; currLetter++)
    {
        string mask = GetMask(currLetter, k);

        int maxForCurrentLetter = 0;
        for(int i = 0; i+k <= s.Length; i++)
        {
            string beginning = s.Substring(0,i);
            string ending = s.Substring(i+k);

            string countingString = $"{beginning}{mask}{ending}";
            int uniqueCountForCurrent = GetUniqueCount(countingString);

            if(uniqueCountForCurrent > maxForCurrentLetter)
                maxForCurrentLetter = uniqueCountForCurrent;
        }   


        if(maxForCurrentLetter > maxTotal)
            maxTotal = maxForCurrentLetter;
    }

    return maxTotal;
}
int GetUniqueCount(string s)
{
    Dictionary<char, int> charCounts = new Dictionary<char, int>();

    foreach(char x in s)
    {
        if (charCounts.ContainsKey(x))
        {
            charCounts[x] = charCounts[x] + 1;
        }
        else
        {
            charCounts.Add(x, 1);
        }
    }

    return charCounts.Values.OrderByDescending(x => x).First();
}
string GetMask(int currentAsciiCharUppercase, int length)
{
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    for (int i = 0; i < length; i++) 
        sb.Append((char)currentAsciiCharUppercase);

    return sb.ToString();
}