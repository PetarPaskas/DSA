// See https://aka.ms/new-console-template for more information

Console.WriteLine(IsPalyndrome("kitaxakit"));
bool IsPalyndrome(string s)
{
    System.Text.StringBuilder sb = new System.Text.StringBuilder();

    foreach (var letter in s)
        sb.Append(Filter(letter.ToString()));

    var final = sb.ToString();
    var size = final.Length;
    
    int half = size / 2;
    int middle = (size % 2) == 0 ? half : half + 1;

    string partOne = final.Substring(0, half);
    string partTwo = final.Substring(middle, half);

    sb.Clear();
    for (int i = partTwo.Length - 1; i >= 0; i--)
        sb.Append(partTwo[i]);

    return partOne.Equals(sb.ToString());
}

string Filter(string strToCheck)
{
    System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z0-9]*$");

    if (rg.IsMatch(strToCheck))
        return strToCheck.ToLower();

    return string.Empty;
}