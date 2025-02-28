namespace ChessBot;

public static enum MoveType { Promotion, Capture, FreeSpace }

public static struct Move {
    MoveType type;
    int location;
}

public static class BoardLogic
{
    public static List<int> GetLegalMoves(ref Board board, int position)
    {
        List<int> legalMoves = new List<int>();

        // if (IsCheckmate()) {
        //     return legalMoves;
        // }

        Piece piece = board.GameBoard[position];
        if (piece == Piece.WhitePawn || piece == Piece.BlackPawn)
        {

        }
        else if (piece == Piece.WhiteKnight || piece == Piece.BlackKnight)
        {

        }

        else if (piece == Piece.WhiteBishop || piece == Piece.BlackBishop)
        {

        }
        else if (piece == Piece.WhiteRook || piece == Piece.BlackRook)
        {

        }
        else if (piece == Piece.WhiteQueen || piece == Piece.BlackQueen)
        {

        }
        else if (piece == Piece.WhiteKing || piece == Piece.BlackKing)
        {

        }

        return legalMoves;
    }
}
