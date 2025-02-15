public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int correctMatrixIndex = SearchForCorrectMatrix(matrix, target, 0, matrix.Length - 1);

        if (correctMatrixIndex == -1)
            return false;

        return BinarySearch(matrix[correctMatrixIndex], target, 0, matrix[correctMatrixIndex].Length - 1) != -1;
    }

    private int SearchForCorrectMatrix(int[][] matrix, int target, int left, int right)
    {

        if (right < left)
            return -1;

        int middle = (left + right) / 2;
        int[] observingMatrix = matrix[middle];

        bool targetLargerThanFirstItem = observingMatrix[0] <= target;
        bool targetSmallerThanLastItem = observingMatrix[observingMatrix.Length - 1] >= target;

        if (targetLargerThanFirstItem && targetSmallerThanLastItem)
            return middle;

        if (!targetSmallerThanLastItem)
            return SearchForCorrectMatrix(matrix, target, middle + 1, right);
        else return SearchForCorrectMatrix(matrix, target, left, middle - 1);

    }

    private int BinarySearch(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1;

        int middle = (left + right) / 2;

        if (array[middle] == target)
            return middle;

        if (array[middle] > target)
            return BinarySearch(array, target, left, middle - 1);
        else
            return BinarySearch(array, target, middle + 1, right);
    }
}
