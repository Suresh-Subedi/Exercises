class Position
{
    int Horizontal { get; set; }
    int Vertical { get; set; }
    public Position(int horizontal, int vertical)
    {
        TryCreatePosition(horizontal, vertical);
    }

    public Position(string position)
    {
        if (position.Length != 2) throw new Exception("Provide position in chess notation. Exapmles: A5, b1, etc.");
        char x = position[0];
        if ((x < 'a' || x > 'h') && (x < 'A' || x > 'H')) throw new Exception($"First letter must be a, b, c, d, e, f, g or h instead of '{x}'");
        var horizontal = x.ToString().ToUpper()[0] - 64;
        bool isInt = Int32.TryParse(position[1].ToString(), out var vertical);
        if (!isInt) throw new Exception("Second letter must be a digit between 1 and 8.");
        TryCreatePosition(horizontal, vertical);
    }

    void TryCreatePosition(int horizontal, int vertical)
    {
        if (!IsValid(horizontal, vertical)) throw new ArgumentOutOfRangeException($"Position should be between (1, 1) and (8, 8) instead of ({horizontal}, {vertical}).");
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }

    public static bool IsValid(int horizontal, int vertical)
    {
        if (horizontal >= 1 && horizontal <= 8 && vertical >= 1 && vertical <= 8)
        {
            return true;
        }
        return false;
    }

    public override bool Equals(object? obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Position p = (Position)obj;
            return (Horizontal == p.Horizontal) && (Vertical == p.Vertical);
        }
    }
    public override int GetHashCode()
    {
        return Horizontal * 10 + Vertical;
    }
    public override string ToString()
    {
        return $"{(char)(64 + Horizontal)}{Vertical}";
    }
}

List<Position> GetPossibleKnightMoves(int horizontal, int vertical)
{
    var moves = new List<Position>();

    moves = TryAddMove(moves, horizontal + 2, vertical + 1);
    moves = TryAddMove(moves, horizontal + 2, vertical - 1);
    moves = TryAddMove(moves, horizontal - 2, vertical + 1);
    moves = TryAddMove(moves, horizontal - 2, vertical - 1);

    moves = TryAddMove(moves, horizontal + 1, vertical + 2);
    moves = TryAddMove(moves, horizontal + 1, vertical - 2);
    moves = TryAddMove(moves, horizontal - 1, vertical + 2);
    moves = TryAddMove(moves, horizontal - 1, vertical - 2);

    return moves;
}

List<Position> TryAddMove(List<Position> moves, int horizontal, int vertical)
{
    if (Position.IsValid(horizontal, vertical))
    {
        moves.Add(new Position(horizontal, vertical));
    }
    return moves;
}

void TestGetPossibleKnightMoves(int horizontal, int vertical, List<Position> expectedOutput)
{
    var result = GetPossibleKnightMoves(horizontal, vertical);

    if (expectedOutput.Count > result.Count)
    {
        throw new Exception("Expected output contains more positions than result.");
    }
    foreach (var pos in expectedOutput)
    {
        if (!result.Contains(pos))
        {
            throw new Exception($"{pos} is missing from result.");
        }
    }
}

TestGetPossibleKnightMoves(1, 1, new List<Position> { new Position(3, 2), new Position(2, 3) });
TestGetPossibleKnightMoves(1, 1, new List<Position> { new Position(2, 3), new Position(3, 2) });
TestGetPossibleKnightMoves(5, 5, new List<Position> { new Position(4, 3), new Position(3, 4), new Position(3, 6), new Position(4, 7), new Position(6, 7), new Position(7, 6), new Position(6, 3), new Position(7, 4) });

void TestPositionIsValid(int horizontal, int vertical, bool expected)
{
    if (Position.IsValid(horizontal, vertical) != expected)
    {
        throw new Exception();
    }
}

TestPositionIsValid(1, 1, true);
TestPositionIsValid(8, 8, true);
TestPositionIsValid(9, 9, false);
TestPositionIsValid(0, 0, false);
TestPositionIsValid(-1, -1, false);
TestPositionIsValid(1, 9, false);
TestPositionIsValid(-1, 1, false);

new Position("a1");
new Position("A1");
//new Position("i9");

var moves = GetPossibleKnightMoves(4, 4);
foreach (var move in moves)
{
    Console.WriteLine(move);
}
