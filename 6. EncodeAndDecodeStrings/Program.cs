using System.Text;


var res = Decode(Encode(["neet", "code", "love", "you"]));
Console.WriteLine(res);





string Encode(IList<string> strs)
{
    if (strs == null)
        return string.Empty;

    StringBuilder sb = new StringBuilder();

    foreach(var str in strs)
        sb.Append($"{str.Length}${str}");

    return sb.ToString();
}


List<string> Decode(string s)
{
    if (String.IsNullOrWhiteSpace(s))
        return new List<string>();

    StringBuilder sb = new StringBuilder();

    List<string> result = new List<string>();

    bool isInStringAppendingState = false;
    string targetLengthString = string.Empty;
    int counter = 1;
    int targetLength = 0;

    //You can do this via substring method. You don't have to reinvent the wheel but you're still getting O(n) so that's okay
    foreach(var chr in s)
    {
        if(!isInStringAppendingState && chr != '$')
        {
            targetLengthString = $"{targetLengthString}{chr}";
            continue;
        }
            

        if(!isInStringAppendingState && chr == '$')
        {
            isInStringAppendingState= true;
            counter = 1;
            targetLength = Convert.ToInt32(targetLengthString);
            continue;
        }

        if (isInStringAppendingState && counter <= targetLength)
        {
            sb.Append(chr);
            counter++;
            continue;
        }

        if (isInStringAppendingState && counter >= targetLength)
        {
            targetLengthString = string.Empty;
            targetLengthString = $"{targetLengthString}{chr}";
            isInStringAppendingState = false;
            result.Add(sb.ToString());
            sb.Clear();
        }
    }

    if (sb.Length > 1)
        result.Add(sb.ToString());

    return result;
}

