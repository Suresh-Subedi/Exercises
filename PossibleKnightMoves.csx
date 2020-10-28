List<int[]> GetPossibleKnightMoves(int horizontal, int vertical) {
    var moves = new List<int[]>();
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, 2, 1); 
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, 2, -1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, -2, 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, -2, -1);
    
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, 1, 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, 1, -2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, -1, 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal, vertical, -1, -2);
    return moves;
}

List<int[]> GetPossibleKnightMovesHelper(List<int[]> moves, int horizontal, int vertical, int x, int y) {
    int[] position = new int[2] { horizontal + x, vertical + y };
    if(MoveIsValid(position[0], position[1])) {
        moves.Add(position);
    }
    return moves;
}

bool MoveIsValid(int horizontal, int vertical) {
    if(horizontal >= 1 && horizontal <= 8 && vertical >= 1 && vertical <= 8) {
        return true;
    }
    return false;
}

var positions = GetPossibleKnightMoves(4, 4);
foreach(var position in positions) {
    Console.WriteLine($"x: {position[0]}, y: {position[1]}");
}
