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

        // Рандом
        public Observer()
        {
            X = 30;
            Y = 30;
        }

        public void Update(IMessage message)
        {
            
            if (Math.Abs(message.X - X) < Math.Abs(observablePrevX - X) ||
                Math.Abs(message.Y - Y) < Math.Abs(observablePrevY - Y))
                RunAway(message.Direction);

            observablePrevX = message.X;
            observablePrevY = message.Y;

        } 

        private void RunAway(DirectionType observableDirection)
        {
            switch (observableDirection)
            {
                case DirectionType.Up:
                    Y--;
                    break;
                case DirectionType.Down:
                    Y++;
                    break;
                case DirectionType.Right:
                    X--;
                    break;
                case DirectionType.Left:
                    X++;
                    break;
            }
        }
        
        // Сохранить границы

    }
}
