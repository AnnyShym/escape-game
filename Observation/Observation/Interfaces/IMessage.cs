using Observation.Types;

namespace Observation
{
    public interface IMessage
    {

        int X { get; }
        int Y { get; }
        DirectionType Direction { get; }

        int WindowWidth { get; }
        int WindowHeight { get; }

    }
}
