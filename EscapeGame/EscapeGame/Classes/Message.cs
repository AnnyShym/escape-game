using EscapeGame.Interfaces;

namespace EscapeGame.Classes
{
    public class Message : IMessage
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public int ActionRadius { get; private set; }

        public Message(int x, int y, int windowWidth, int windowHeight, int actionRadius)
        {

            X = x;
            Y = y;

            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

            ActionRadius = actionRadius;

        }

    }
}
