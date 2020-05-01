using System.Collections.Generic;

namespace LetterBoard
{
    public static class BoardExtensions
    {
        public static string AsString(this List<char> board)
        {
            return $"[ {string.Join(",", board)} ]";
        }
    }
}