
int target = 10;
int[] positions = [6,8];
int[] speeds = [3,2];

var result = CarFleet(target, positions, speeds);
Console.WriteLine(result);
int CarFleet(int target, int[] positions, int[] speeds)
{
    //position on the road
    //speed at which is going
    int[][] vehicles = new int[positions.Length][];


    for (int i = 0; i < positions.Length; i++)
    {
        var position = positions[i];
        var mphSpeed = speeds[i];
        vehicles[i] = new int[2] { position, mphSpeed };
    }

    Array.Sort(vehicles, (vh1, vh2) => {
        var position1 = vh1[0];
        var position2 = vh2[0];

        return position2.CompareTo(position1);
    });

    Stack<double> stack = new Stack<double>();

    for (int j = 0; j < vehicles.Length; j++)
    {
        double position = vehicles[j][0];
        double speed = vehicles[j][1];
        double distanceToCover = target - position;

        double timeToCoverDistance = distanceToCover / speed;

        if(stack.Count > 0)
        {
            var theOneInFront = stack.Peek();

            stack.Push(timeToCoverDistance);

            if (timeToCoverDistance <= theOneInFront)
                stack.Pop();
        }
        else
        {
            stack.Push(timeToCoverDistance);
        }


    }

    return stack.Count;


}