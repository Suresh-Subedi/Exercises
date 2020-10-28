List<int[]> GetPossibleKnightMoves(int horizontal, int vertical) {
    var moves = new List<int[]>();
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 2, vertical + 1); 
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 2, vertical - 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 2, vertical + 1);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 2, vertical + 1);
    
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 1, vertical + 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal + 1, vertical - 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 1, vertical + 2);
    moves = GetPossibleKnightMovesHelper(moves, horizontal - 1, vertical - 2);
    return moves;
}

List<int[]> GetPossibleKnightMovesHelper(List<int[]> moves, int horizontal, int vertical) {
    int[] position = new int[2] { horizontal, vertical};
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

var moves = GetPossibleKnightMoves(1, 1);
foreach(var move in moves) {
    Console.WriteLine($"horizontal: {move[0]}, vertical: {move[1]}");
}
