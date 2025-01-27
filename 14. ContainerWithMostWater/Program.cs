




using System.ComponentModel;

//int[] height = [2, 2, 2];
//int[] height = [1, 7, 2, 500,500,5, 4, 7, 3, 6];


Console.WriteLine(MaxArea(height));
int MaxArea(int[] heights)
{
    int size = 0;
    int containerSize = heights.Length-1;


    while (containerSize >= 1)
    {
        int area = 1;

        for(int moves = 0; moves < heights.Length - containerSize; moves++)
        {
            int start = moves;
            int end = moves + containerSize;

            if (heights[start] > heights[end])
            {
                area = containerSize * heights[end];
            }
            else
            {
                area = containerSize * heights[start];
            }



            if (area > size)
                size = area;

        }

        containerSize--;
    }

    return size;
}