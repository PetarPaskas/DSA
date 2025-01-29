

//1. if we are inside a container, we should add all heights of the left most height
//2. we are exiting the container once the right bar height is larger then the left most height bar
//3. if there are still bars left then we will add more heights
//4. we are not yet sure what the heights will be because we don't know if the next bar is higher or lower
//5. if the bar is lower, we will have to know how many steps we've went through,
//  we multiply those steps by the lowest height and subtract that by the other heights
//  then we will get the max hegiht


int[] heights = [0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1];
heights = [0, 2, 0, 3, 1, 0, 1, 3, 2, 1];
heights = [4,2,3];

Console.WriteLine(WRONGTrap(heights));

int WRONGTrap(int[] heights)
{
    int total = 0;
    var (leftTotal, delimiter)= TrapPrivate(heights);
    total += leftTotal;

    if(delimiter != -1)
    {
        var skipped = heights.Skip(delimiter+1).ToArray();
        var (rightTotal, delimiterRight) = TrapPrivate(skipped);
        total += rightTotal;
    }

    return total;
}

(int,int) TrapPrivate(int[] heights)
{
    int currentLowestPoint = 0;
    int currentContainerSize = 0;
    int totalToSubtract = 0;
    bool isInContainer = false;
    int total = 0;
    int indexOfDelimiter = -1;

    for (int i = 0; i < heights.Length; i++)
    {
        bool hasNext = i + 1 < heights.Length;
        bool nextBarIsHigherThanCurrent = hasNext && heights[i + 1] > heights[i];
        if (!isInContainer)
        {

            if (nextBarIsHigherThanCurrent)
                continue;

            if (heights[i] > 0) //container counting initiated
            {
                isInContainer = true;
                currentLowestPoint = heights[i];
                currentContainerSize = 0;
                continue;
            }
        }

        //let's decide if we should still be inside a container
        if (isInContainer)
        {
            int currentHeight = heights[i];
            if (currentHeight >= currentLowestPoint)
            {
                //we should exit container and calculate
                var addition = currentLowestPoint * currentContainerSize - totalToSubtract;
                if (addition > 0)
                    total += addition;

                currentLowestPoint = currentHeight;
                indexOfDelimiter = i;
                currentContainerSize = 0;
                continue;
            }

            currentContainerSize++;
            totalToSubtract += heights[i];
        }
    }

    return (total, indexOfDelimiter);
}