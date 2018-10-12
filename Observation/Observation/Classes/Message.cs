namespace Observation.Classes
{
    public class Message : IMessage
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public Message(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
