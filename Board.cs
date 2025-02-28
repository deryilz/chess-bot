namespace ChessBot;

class Board
{
    public static char[] PieceChars = { '-', 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };

    public Piece[] GameBoard;
    // bits in order:
    // ?, ?, ?, is white move, K castle, Q castle, k castle, q castle
    // public byte TurnAndCastlingInfo = 0;

    public bool IsWhiteTurn;
    public int EnPassantSquare;
    public int MovesSinceCapture;
    public int MoveCount;

    public CastlingRights CastlingRights = new CastlingRights();

    Board(Board other)
    {
        GameBoard = new Piece[8 * 8];
        Array.Copy(other.GameBoard, GameBoard, 64);
        CastlingRights = other.CastlingRights;
        IsWhiteTurn = other.IsWhiteTurn;
        EnPassantSquare = other.EnPassantSquare;
        MovesSinceCapture = other.MovesSinceCapture;
        MoveCount = other.MoveCount;
    }

    public Board(string inputFen) {
        Piece[] pieces = new Piece[8 * 8];
        int index = 0;

        string[] fen = inputFen.Split(" ");

        foreach (var c in fen[0])
        {
            if (PieceChars.Contains(c))
            {
                pieces[index] = (Piece)Array.IndexOf(PieceChars, c);
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
        IsWhiteTurn = fen[1] == "w";
        CastlingRights.CanWhiteCastleK = fen[2].Contains("K");
        CastlingRights.CanWhiteCastleQ = fen[2].Contains("Q");
        CastlingRights.CanBlackCastleK = fen[2].Contains("k");
        CastlingRights.CanBlackCastleQ = fen[2].Contains("q");
        EnPassantSquare = SquareFromAlgNotation(fen[3]);
        MovesSinceCapture = int.Parse(fen[4]);
        MoveCount = int.Parse(fen[5]);
    }

    public Piece PieceAt(int row, int col) {
        return GameBoard[row * 8 + col];
    }

    public void PrintBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Console.Write(PieceChars[(int)GameBoard[row * 8 + col]] + " ");
            }
            Console.Write("\n");
        }

        Console.WriteLine();
        Console.WriteLine("White to move: " + IsWhiteTurn);
        Console.WriteLine("En passant square: " + EnPassantSquare);
        Console.WriteLine("Moves since capture: " + MovesSinceCapture);
        Console.WriteLine("Move count: " + MoveCount);
        Console.WriteLine("White can castle kingside: " + CastlingRights.CanWhiteCastleK);
        Console.WriteLine("White can castle queenside: " + CastlingRights.CanWhiteCastleQ);
        Console.WriteLine("Black can castle kingside: " + CastlingRights.CanBlackCastleK);
        Console.WriteLine("Black can castle queenside: " + CastlingRights.CanBlackCastleQ);

    }

    public int SquareFromAlgNotation(string square)
    {
        if (square == "-")
        {
            return -1;
        }
        int index = char.ToUpper(square[0]) - 64;
        index += (int)(char.GetNumericValue(square[1]) - 1) * 8;
        return index;
    }

    public Board CloneBoard()
    {
        Board newBoard = new Board(this);
        return newBoard;
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

public struct Move
{
    public int StartSquare;
    public int EndSquare;
}

public struct CastlingRights
{
    public bool CanBlackCastleQ;
    public bool CanBlackCastleK;
    public bool CanWhiteCastleQ;
    public bool CanWhiteCastleK;
}
