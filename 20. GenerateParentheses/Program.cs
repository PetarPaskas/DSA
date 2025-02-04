

int n = 3;
foreach(var x in Generate(n))
    Console.WriteLine(x);

List<string> Generate(int n)
{
    List<string> result = new List<string>();
    string stack = string.Empty;

    Backtrack(0,0,n,result, stack);

    return result;
}

void Backtrack(int OpenC, int CloseC, int n, List<string> result, string stack)
{
    if(OpenC == CloseC && OpenC == n)
        result.Add(stack);

    if(OpenC < n)
        Backtrack(OpenC+1, CloseC, n, result, stack + "(");

    if(CloseC < OpenC)
        Backtrack(OpenC, CloseC+1, n, result, stack + ")");


}