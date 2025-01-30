// See https://aka.ms/new-console-template for more information

using System.Text;

string testData = "()[]}{}";

Console.WriteLine(IsValid(testData));
bool IsValid(string s)
{
    HashSet<char> chars = new HashSet<char>(new char[] { '(', '[', '{', ')', ']', '}' });

    Dictionary<char, char> openClosePairs = new Dictionary<char, char>();
    openClosePairs.Add('(', ')');
    openClosePairs.Add('[', ']');
    openClosePairs.Add('{', '}');

    StringBuilder sb = new StringBuilder();
    foreach (var x in s)
        if (chars.Contains(x))
            sb.Append(x);

    var filtered = sb.ToString();
    if (filtered.Length % 2 != 0)
        return false;

    Stack<char> stack = new Stack<char>();

    foreach(var c in filtered)
    {
        bool isOpeningCharacter = openClosePairs.ContainsKey(c);
        if (isOpeningCharacter)
        {
            stack.Push(c);
        }
        else
        {
            //it's a closing character
            if (stack.Count > 0 && openClosePairs[stack.Peek()] == c)
                stack.Pop();
            else return false;
        }
    }

    return stack.Count == 0;
}