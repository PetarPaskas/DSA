
var nums = new int[]{1,2,3,4,4};
Console.WriteLine("Has duplicate: " + hasDuplicate(nums));


bool hasDuplicate(int[] nums){
    var inputSet = new HashSet<int>();
    for(int i = 0; i<nums.Length;i++){
        if(!inputSet.Add(nums[i]))
        return true;
    }
    return false;
}