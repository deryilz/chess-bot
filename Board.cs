namespace ChessBot;

class Board
{
    public Int64 white_pawns;
    public Int64 white_rooks;
    public Int64 white_knights;
    public Int64 white_bishops;
    public Int64 white_king;
    public Int64 white_queen;

    public Int64 black_pawns;
    public Int64 black_rooks;
    public Int64 black_knights;
    public Int64 black_bishops;
    public Int64 black_king;
    public Int64 black_queen;

    public void PrintBoard()
    {
        char[] chars = new string('-', 64).ToCharArray();
        void SetChar(char c, Int64 bits) {
            for (var i = 0; i < 64; i++)
            {
                if ((bits & 1) == 1) {
                    if (chars[63-i] != '-') {
                        throw new Exception("Um, multiple pieces in the same place.");
                    }
                    chars[63 - i] = c;
                }
                bits >>= 1;
            }
        }
        SetChar('P', this.white_pawns);
        SetChar('R', this.white_rooks);
        SetChar('N', this.white_knights);
        SetChar('B', this.white_bishops);
        SetChar('K', this.white_king);
        SetChar('Q', this.white_queen);
        SetChar('p', this.black_pawns);
        SetChar('r', this.black_rooks);
        SetChar('n', this.black_knights);
        SetChar('b', this.black_bishops);
        SetChar('k', this.black_king);
        SetChar('q', this.black_queen);
        for (int i = 0; i < 64;i++)
        {
            var c = ((i + 1) % 8 == 0) ? "\n" : " ";
            Console.Write(chars[i] + c);
        }
    }
}
