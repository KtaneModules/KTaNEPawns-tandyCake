using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChessPiece
{
    public int PieceType { get; set; } 
    public int Row { get; set; }
    public int Col { get; set; }
    public PawnsScript script = new PawnsScript();
    private int[,] chessboard;

    public ChessPiece(int row, int col, int type = 0)
    {
        PieceType = type;
        Row = row;
        Col = col;
    }

    public List<int[]> GetCaptures()
    {
        chessboard = script.chessboard;
        List<int[]> captures = new List<int[]>();
        int[][] offsets;

        switch (PieceType)
        {
            case (int)PieceNames.Knight:
                captures = KNmoves(new int[][] { new int[] { -2, -1 }, new int[] { -2, 1 }, new int[] { -1, -2 }, new int[] { -1, 2 }, new int[] { 1, -2 }, new int[] { 1, 2 }, new int[] { 2, -1 }, new int[] { 2, 1 } });
                break;
            case (int)PieceNames.King:
                captures = KNmoves(new int[][] { new int[] { -1, -1 }, new int[] { -1, 0 }, new int[] { -1, 1 }, new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, -1 }, new int[] { 1, 0 }, new int[] { 1, 1 } });
                break;
            case (int)PieceNames.Rook:
                captures = RBQmoves(new int[][] { new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, 0 } });
                break;
            case (int)PieceNames.Bishop:
                captures = RBQmoves(new int[][] { new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 } });
                break;
            case (int)PieceNames.Queen:
                captures = RBQmoves(new int[][] { new int[] { -1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { 1, 1 } });
                break;
        }
        return captures;
    }

    private List<int[]> KNmoves(int[][] offsets)
    {
        return offsets.Where(x => CheckBounds(Row + x[0], Col + x[1])).ToList();
    }
    private List<int[]> RBQmoves(int[][] offsets)
    {
        List<int[]> captures = new List<int[]>();
        foreach (int[] movement in offsets)
        {
            int number = 1;
            while (CheckBounds(Row + number * movement[0], Col + number * movement[1]))
            {
                captures.Add(new int[] { Row + number * movement[0], Col + number * movement[1] });
                if (chessboard[Row + number * movement[0], Col + number * movement[1]] != -1) //If we hit a space which has a piece, stop adding spaces.
                    break;
                number++;
            }
        }
        return captures;
    }

    private bool CheckBounds(int row, int col)
    {
        if (row >= 0 && row <= 7 && col >= 0 && col <= 7) return false;
        else return true;
    }

}
