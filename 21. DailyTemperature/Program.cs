int[] DailyTemperatures(int[] temperatures)
{
    int[] result = new int[temperatures.Length];

    for (int i = 0; i < temperatures.Length; i++)
    {
        var currentlyObserved = temperatures[i];

        for (int j = i + 1; j < temperatures.Length; j++)
        {
            var day = temperatures[j];

            if (day > currentlyObserved)
            {
                var daySince = j - i;
                result[i] = daySince;
                break;
            }
        }
    }

    return result;

}