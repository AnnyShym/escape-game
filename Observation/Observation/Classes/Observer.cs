using Observation.Types;
using System;

namespace Observation.Classes
{
    public class Observer : IObserver
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        private int observablePrevX;
        private int observablePrevY;

        public Observer(int x, int y)
        {

            if (x < 0)
                throw new ArgumentOutOfRangeException("Abscissa value can't be a negative number!");

            if (y < 0)
                throw new ArgumentOutOfRangeException("Ordinate value can't be a negative number!");

            X = x;
            Y = y;

        }

        public void Update(IMessage message)
        {
            
            if (Math.Abs(message.X - X) < Math.Abs(observablePrevX - X) ||
                Math.Abs(message.Y - Y) < Math.Abs(observablePrevY - Y))
                RunAway(message);

            observablePrevX = message.X;
            observablePrevY = message.Y;

        } 

        private void RunAway(IMessage message)
        {
            // Magic
        }

    }
}
