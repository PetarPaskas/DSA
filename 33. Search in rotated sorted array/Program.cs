


int[] nums = [1,3];
int target = 3;

Console.WriteLine(Search(nums, target));
int Search(int[] nums, int target)
{
    if (nums[0] <= nums[nums.Length - 1])
        return BinarySearch(nums, target);


    return FindPartitionedSegment(nums, target);
}

int FindPartitionedSegment(int[] nums, int target)
{
    int index = -1;
    int left = 0;
    int right = nums.Length-1;

    while(left < right)
    {
        if (nums[left] == target)
        {
            index = left;
            break;
        }

        if (nums[right] == target)
        {
            index = right;
            break;
        }

        int middle = (left + right) / 2;

        if (nums[middle] == target)
        {
            index = middle;
        }

        if (nums[middle] >= nums[left])
            left = middle + 1;
        else
            right = middle - 1; //target is to the left
    }

    return index;


}


int BinarySearch(int[] nums, int target)
{
    return BinarySearchPrivate(nums, target, 0, nums.Length - 1);
}

int BinarySearchPrivate(int[] nums, int target, int left, int right)
{
    if (left > right)
        return -1;

    int middle = (left + right) / 2;

    if (nums[middle] == target) return middle;

    if (nums[middle] < target)
        return BinarySearchPrivate(nums, target, middle+1, right);
    return BinarySearchPrivate(nums, target, left, middle-1);

}

