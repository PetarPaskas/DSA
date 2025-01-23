



//1. Each row must contain the digits 1-9 without duplicates
//2. each column must contain the digits 1-9 without duplicates
//3. each of the nine 3x3 sub boxes of the grid msut contain 1-9 without duplicates

using System.Linq;

string[][] board = [
    [".", ".", ".", ".", "5", ".", ".", "1", "."],
    [".", "4", ".", "3", ".", ".", ".", ".", "."],
    [".", ".", ".", ".", ".", "3", ".", ".", "1"],
    ["8", ".", ".", ".", ".", ".", ".", "2", "."],
    [".", ".", "2", ".", "7", ".", ".", ".", "."],
    [".", "1", "5", ".", ".", ".", ".", ".", "."],
    [".", ".", ".", ".", ".", "2", ".", ".", "."],
    [".", "2", ".", "9", ".", ".", ".", ".", "."],
    [".", ".", "4", ".", ".", ".", ".", ".", "."]];


Console.WriteLine(IsValidSudoku(board));

bool IsValidSudoku(string[][] board)
{
    int[][] boardInt = GetBoard(board);

    return AreRowsValid(boardInt)
        && AreColumnsValid(boardInt)
        && AreBoxesValid(boardInt);

}

int[][] GetBoard(string[][] board)
{
    var result = new int[9][];

    for(int i = 0; i < board.Length; i++)
    {
        result[i] = new int[9];
        for (int j = 0; j < board[i].Length; j++)
        {
            if(int.TryParse(board[i][j], out int value))
            result[i][j] = value;
            else result[i][j] = 0;
        }
    }

    return result;
}

bool AreRowsValid(int[][] boardInt)
{
    HashSet<int> values = new HashSet<int>();

    for (int i = 0; i < 9; i++)
    {
        var row = boardInt[i];

        for(int j = 0; j< 9; j++)
        {
            if (row[j] == 0) continue;

            if (values.Contains(row[j]))
                return false;

            values.Add(row[j]);
        }

        values.Clear();
    }

    return true;
}

bool AreColumnsValid(int[][] boardInt)
{
    HashSet<int> values = new HashSet<int>();

    for (int i = 0; i < 9; i++)
    {
        for(int j = 0; j < 9; j++)
        {
            if (boardInt[j][i] == 0) continue;

            if (values.Contains(boardInt[j][i]))
                return false;

            values.Add(boardInt[j][i]);
        }
        values.Clear();
    }

    return true;
}

bool AreBoxesValid(int[][] board)
{
    HashSet<int> seen = new HashSet<int>();

    for (int box = 0; box < 9; box++)
    {
        for (int rowStep = 0; rowStep < 3; rowStep++)
        {
            for (int colStep = 0; colStep < 3; colStep++)
            {
                int row = (box / 3) * 3 + rowStep;
                int col = (box % 3) * 3 + colStep;

                if (board[row][col] == 0) continue;

                if (seen.Contains(board[row][col])) 
                    return false;

                seen.Add(board[row][col]);
            }
        }
        seen.Clear();
    }
    return true;
}



//(int, int) DecideRowAndColumnForBox(int box)
//{

//    var column = box * 3;
//    var row = (3 / box) * box;

//    1 => (3, 3)
//    2 => (3, 6)
//    3 => (3, 9)

//    4 => (6, 3)
//    5 => (6, 6)
//    6 => (6, 9)

//    7 => (9, 3)
//    8 => (9, 6)
//    9 => (9, 9)

//}