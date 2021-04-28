using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChessPiece
{
    public int PieceType { get; set; } 
    public int Row { get; set; }
    public int Col { get; set; }
    public string PieceName { get; private set; }

    private int[,] chessboard;
    private string[] names = new string[] { "Pawn", "Knight", "Bishop", "Rook", "Queen", "King" };


    public ChessPiece(int row, int col, int type = 0)
    {
        PieceType = type;
        Row = row;
        Col = col;
        PieceName = names[type];
    }
    public ChessPiece(int[] coord, int type = 0)
    {
        PieceType = type;
        Row = coord[0];
        Col = coord[1];
        PieceName = names[type];
    }

    public string GetCoordinate()
    {
        return "abcdefg"[Col] + "-" + "1234567"[Row];
    }
    public List<int[]> GetCaptures(int[,] board)
    {
        chessboard = board;
        List<int[]> captures = new List<int[]>();
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
            case (int)PieceNames.Pawn: case (int)PieceNames.Blocker:
                throw new NotImplementedException("Captures were attempted to be obtained of an ineffective piece.");
        }
        return captures;
    }

    private List<int[]> KNmoves(int[][] offsets)
    {
        return offsets.Where(x => CheckBounds(Row + x[0], Col + x[1]))
            .Select(x => new int[] { Row + x[0], Col + x[1] }).ToList();
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
        if (row < 0 || row > 6 || col < 0 || col > 6) return false;
        else return true;
    }

}
