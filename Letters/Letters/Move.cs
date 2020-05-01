namespace Letters
{
    public struct Move
    {
        public const char EmptyLetter = (char)0;

        public readonly Direction Direction;
        public readonly char Letter;   // use constant EmptyLetter to represent nothing captured

        public Move(Direction direction, char letter)
        {
            Direction = direction;
            Letter = letter;
        }

        public Move(Direction direction)
        {
            Direction = direction;
            Letter = EmptyLetter;
        }

        public override string ToString()
        {
            return $"{Direction}:{Letter}";
        }
    }
}