List<Position> GetPossibleKnightMoves(int horizontal, int vertical) {
    var moves = new List<Position>();
    
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 2, vertical + 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 2, vertical - 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 2, vertical + 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 2, vertical - 1);
    
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 1, vertical + 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 1, vertical - 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 1, vertical + 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 1, vertical - 2);
    
    return moves;
}

List<Position> GetPossibleKnightMovesHelper(List<Position> moves, int horizontal, int vertical) {
    if(MoveIsValid(horizontal, vertical)) {
        moves.Add(new Position(horizontal, vertical));
    }
    return moves;
}

bool MoveIsValid(int horizontal, int vertical) {
    if(horizontal >= 1 && horizontal <= 8 && vertical >= 1 && vertical <= 8) {
        return true;
    }
    return false;
}

var moves = GetPossibleKnightMoves(4, 4);
foreach(var move in moves) {
    Console.WriteLine(move);
}

class Position {
    int Horizontal { get; set; }
    int Vertical  { get; set; }
    public Position(int horizontal, int vertical) {
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }
    public override bool Equals(object? obj)
    {
          //Check for null and compare run-time types.
          if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
          {
             return false;
          }
            else {
             Position p = (Position) obj;
             return (Horizontal == p.Horizontal) && (Vertical == p.Vertical);
          }
    }
    public override int GetHashCode()
    {
        return Horizontal * 10 + Vertical;
    }
    public override string ToString()
    {
        return $"Horizontal: {Horizontal}, Vertical: {Vertical}";
    }
}


void TestGetPossibleKnightMoves(int horizontal, int vertical, List<Position> expectedOutput) {
      var result = GetPossibleKnightMoves(horizontal, vertical);

      if(result.Count > expectedOutput.Count) {
        throw new Exception();
      }
      foreach(var pos in result) {
          if(!expectedOutput.Contains(pos)) {
            Console.WriteLine(pos);
            throw new Exception();
          }
      }
}

TestGetPossibleKnightMoves(1, 1, new List<Position> {new Position(3, 2), new Position(2, 3)});
TestGetPossibleKnightMoves(1, 1, new List<Position> {new Position(2, 3), new Position(3, 2)});

TestGetPossibleKnightMoves(5, 5, new List<Position> {new Position(4, 3), new Position(3, 4), new Position(3, 6), new Position(4, 7), new Position(6, 7), new Position(7, 6), new Position(6, 3), new Position(7, 4)});

void TestMoveIsValid(int horizontal, int vertical, bool expected) {
    if(MoveIsValid(horizontal, vertical) != expected) {        
        throw new Exception();
    }
}

TestMoveIsValid(1, 1, true);
TestMoveIsValid(8, 8, true);
TestMoveIsValid(9, 9, false);
TestMoveIsValid(0, 0, false);
TestMoveIsValid(-1, -1, false);
TestMoveIsValid(1, 9, false);
TestMoveIsValid(-1, 1, false);
