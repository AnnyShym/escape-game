using EscapeGame.Types;

namespace EscapeGame.Interfaces
{
    public interface IHunter
    {

        int X { get; }
        int Y { get; }

        int Step { get; }
        int ActionRadius { get; }

        IPublisher PublisherObject { get; }

        void Move(DirectionType direction, int windowWidth, int windowHeight);
        void Move(int windowWidth, int windowHeight, int x, int y);

    }
}
