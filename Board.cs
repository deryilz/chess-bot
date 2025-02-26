namespace ChessBot;

class Board
{
    public static char[] PieceChars = { '-', 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };

    public Piece[,] GameBoard;
    // bits in order:
    // ?, ?, ?, is white move, K castle, Q castle, k castle, q castle
    public byte TurnAndCastlingInfo = 0;
    public int EnPassantSquare;
    public int MovesSinceCapture;
    public int MoveCount;

    public Board(Board other)
    {
        GameBoard = new Piece[8, 8];
        Array.Copy(other.GameBoard, GameBoard, 64);
        TurnAndCastlingInfo = other.TurnAndCastlingInfo;
        EnPassantSquare = other.EnPassantSquare;
        MovesSinceCapture = other.MovesSinceCapture;
        MoveCount = other.MoveCount;
    }

    public bool CanWhiteCastleQ {
        get { return (TurnAndCastlingInfo & 4) != 0; }
        set { if (value) { TurnAndCastlingInfo |= 4; } else { TurnAndCastlingInfo &= 255 - 4; } }
    }

    Board(string inputFen) {
        Piece[,] pieces = new Piece[8, 8];
        int index = 0;

        string[] fen = inputFen.Split(" ");

        foreach (var c in fen[0])
        {
            if (PieceChars.Contains(c))
            {
                pieces[index / 8, index % 8] = (Piece)Array.IndexOf(PieceChars, c);
            }

            else if (char.IsDigit(c))
            {
                index += int.Parse(c.ToString()) - 1;
            }

            else
            {
                continue;
            }
            index++;
        }

        GameBoard = pieces;

        SetCastlingRights(fen[3].Contains('K'), fen[3].Contains('Q'), fen[3].Contains('k'), fen[3].Contains('q'));
        MovesSinceCapture = int.Parse(fen[4]);
        MoveCount = int.Parse(fen[5]);
    }

    public bool IsWhiteTurn() {
        return (TurnAndCastlingInfo & 16) != 0;
    }

    public bool CanWhiteCastleK() {
        return (TurnAndCastlingInfo & 8) != 0;
    }

    public bool CanWhiteCastleQ() {
        return (TurnAndCastlingInfo & 4) != 0;
    }

    public bool CanBlackCastleK() {
        return (TurnAndCastlingInfo & 2) != 0;
    }

    public bool CanBlackCastleQ() {
        return (TurnAndCastlingInfo & 1) != 0;
    }

    public bool SetCastlingRights(bool K, bool Q, bool k, bool q) {
        int val = 0;
        if (K) {

        }
        return TurnAndCastlingInfo >> 5 != 0;
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
