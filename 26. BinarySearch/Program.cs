
//[-1,0,2,4,6,8]
//target = 4
public class Solution
{
    public int Search(int[] nums, int target)
    {
        return Search(nums, target, 0, nums.Length - 1);
    }

    private int Search(int[] nums, int target, int left, int right)
    {

        if (left > right)
            return -1;

        int middle = (left + right) / 2;

        if (nums[middle] == target)
            return middle;

        if (nums[middle] > target)
            return Search(nums, target, left, middle - 1);

        return Search(nums, target, middle + 1, right);
    }
}
