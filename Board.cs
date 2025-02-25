using System.Runtime.CompilerServices;

namespace ChessBot;

class Board
{
    public Piece[,] GameBoard;
    public char[] PieceChars = { '-', 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };

    public Board(string fen)
    {
        GameBoard = FromFen(fen);
    }

    public void PrintBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Console.Write(PieceChars[(int)GameBoard[row, col]] + " pp");
            }
            Console.Write("\n");
        }
    }

    public Piece[,] FromFen(string fen)
    {
        Piece[,] board = new Piece[8, 8];
        int index = 0;

        foreach (var c in fen)
        {
            if (PieceChars.Contains(c))
            {
                board[index/8, index%8] = (Piece)Array.IndexOf(PieceChars, c);
            }

            else if (char.IsDigit(c))
            {
                index += int.Parse(c.ToString())-1;
            }

            else
            {
                continue;
            }
            index++;
        }
        
        return board;
    }
}

public enum Piece : byte
{
    None = 0,
    
    WhitePawn = 1,
    WhiteRook = 2,
    WhiteKnight = 3,
    WhiteBishop = 4,
    WhiteQueen = 5,
    WhiteKing = 6,
    
    BlackPawn = 7,
    BlackRook = 8,
    BlackKnight = 9,
    BlackBishop = 10,
    BlackQueen = 11,
    BlackKing = 12,
}
