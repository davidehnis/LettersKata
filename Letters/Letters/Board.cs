using System.Collections.Generic;

namespace Letters
{
    public static class Board
    {
        public static List<Move> CalculateMoves(List<char> board, string word)
        {
            var results = new List<Move>();

            var workingBoard = new List<char>();
            workingBoard.AddRange(board);

            foreach (var letter in word)
            {
                var last = false;
                while (!last) // stay on the letter until it's "popped off"
                {
                    var midPoint = FindMidpointIndex(workingBoard);

                    var locationOnBoard = Index(workingBoard, letter);
                    if (locationOnBoard == 0) // on the left end
                    {
                        results.Add(new Move(Direction.Left, letter));
                        workingBoard.RemoveAt(0);
                        last = true;
                    }
                    else if (locationOnBoard == workingBoard.Count - 1) // on the right end
                    {
                        results.Add(new Move(Direction.Right, letter));
                        workingBoard.RemoveAt(workingBoard.Count - 1);
                        last = true;
                    }
                    else if (locationOnBoard >= midPoint)
                    {
                        results.Add(new Move(Direction.Right));
                        var lastChar = workingBoard[^1];
                        workingBoard.RemoveAt(workingBoard.Count - 1);
                        workingBoard.Insert(0, lastChar);
                    }
                    else
                    {
                        results.Add(new Move(Direction.Left));
                        var firstChar = workingBoard[0];
                        workingBoard.RemoveAt(0);
                        workingBoard.Insert(workingBoard.Count, firstChar);
                    }
                }
            }

            return results;
        }

        public static int Index(List<char> board, char letter)
        {
            var first = board.IndexOf(letter);
            var last = board.LastIndexOf(letter);
            return last > first ? last : first;
        }

        public static int FindMidpointIndex(List<char> board)
        {
            var length = board.Count;
            if (length % 2 == 0) //even
            {
                return (length / 2);
            }

            return ((length + 1) / 2) - 1;
        }
    }
}