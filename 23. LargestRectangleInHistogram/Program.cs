
using System;
using System.Runtime.CompilerServices;

int[] heights = [7, 1, 7, 2, 2, 4];
Console.WriteLine(LargestRectangleArea(heights));

int LargestRectangleArea(int[] heights)
{
    int observed = 0;
    int totalSum = 0;
    while (observed < heights.Length)
    {
        int rightFurthest = GetRightFurthestIndexForObserved(heights, observed);
        int leftFurthest = GetLeftFurthestIndexForObserved(heights, observed);

        int observedArea = heights[observed] * ((rightFurthest-leftFurthest)+1);

        bool currentObservedHeightLargerThanCalculatedArea = heights[observed] >= observedArea;
        if (currentObservedHeightLargerThanCalculatedArea)
            observedArea = heights[observed];

        if (totalSum < observedArea)
            totalSum = observedArea;

        observed++;
    }
    return totalSum;
}

int GetRightFurthestIndexForObserved(int[] heights, int observed)
{
    int rightFurthestIndex = observed;
    for (int i = observed; i < heights.Length; i++)
    {
        if (heights[i] >= heights[observed])
            rightFurthestIndex = i;
        else break;
    }
    return rightFurthestIndex;
}

int GetLeftFurthestIndexForObserved(int[] heights, int observed)
{
    int rightFurthestIndex = observed;
    for (int i = observed; i >= 0; i--)
    {
        if (heights[i] >= heights[observed])
            rightFurthestIndex = i;
        else break;
    }
    return rightFurthestIndex;
}