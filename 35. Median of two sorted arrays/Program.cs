

double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    int[] final = new int[nums1.Length + nums2.Length];
    int i = 0;
    int j = 0;
    int k = 0;

    while(i<nums1.Length && j < nums2.Length)
    {
        if (nums1[i] < nums2[j])
            final[k++] = nums1[i++];
        else
            final[k++] = nums2[j++];
    }

    while(i<nums1.Length)
        final[k++] = nums1[i++];

    while(j<nums2.Length)
        final[k++] = nums2[j++];

   
    if (final.Length % 2 == 0)
    {
        return ((double)final[final.Length / 2] + (double)final[final.Length / 2 - 1])/ (double)2;
    }

    return final[final.Length / 2];
}