using EscapeGame.Interfaces;

namespace EscapeGame.Classes
{
    /// <summary>
    /// The message for sending from observable to his observers
    /// </summary>
    public class ThreatMessage : IThreatMessage
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public int ActionRadius { get; private set; }

        public ThreatMessage(int x, int y, int windowWidth, int windowHeight, int actionRadius)
        {

            X = x;
            Y = y;

            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

            ActionRadius = actionRadius;

        }

    }
}
