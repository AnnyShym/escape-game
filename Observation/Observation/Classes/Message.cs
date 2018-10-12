using Observation.Types;

namespace Observation.Classes
{
    public class Message : IMessage
    {

        public int X { get; private set; }
        public int Y { get; private set; }
        public DirectionType Direction { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public Message(int x, int y, DirectionType direction, int windowWidth, int windowHeight)
        {

            X = x;
            Y = y;
            Direction = direction;

            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

        }

    }
}
