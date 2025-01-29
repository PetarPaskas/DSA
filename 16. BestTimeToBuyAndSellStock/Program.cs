
int[] prices = [3, 2, 6, 5, 0, 3];
Console.WriteLine(MaxProfitBruteForce(prices));

    int MaxProfitBruteForce(int[] prices)
    {
        int total = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {

            for (int j = i + 1; j < prices.Length; j++)
            {
                int calc = prices[j] - prices[i];
                if (calc > total)
                    total = calc;
            }
        }
        return total;
    }

int MaxProfitIncompleteOptimal(int[] prices)
{
    int dayToBuy = 0;
    int leftMin = prices[0];
    for (int i = dayToBuy; i < prices.Length; i++)
    {
        if (prices[i] < leftMin)
        {
            dayToBuy = i;
            leftMin = prices[i];
        }
    }

    int dayToSell = prices.Length - 1;
    int rightMax = prices[dayToSell];

    for (int j = dayToSell; j > dayToBuy; j--)
    {
        if (prices[j] > rightMax)
        {
            rightMax = prices[j];
            dayToSell = j;
        }
    }

    int expectedProfit = rightMax - leftMin;

    if (expectedProfit < 0)
        return 0;

    return expectedProfit;
}