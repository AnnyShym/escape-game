namespace EscapeGame.Interfaces
{
    public interface IMessage
    {

        int X { get; }
        int Y { get; }

        int WindowWidth { get; }
        int WindowHeight { get; }

        int ActionRadius { get; }

    }
}
