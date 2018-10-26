using EscapeGame.Interfaces;
using EscapeGame.Types;
using System;

namespace EscapeGame.Classes
{
    public class Observable : IObservable
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ActionRadius { get; private set; }

        public IPublisher PublisherObject { get; private set; }

        public Observable(int x, int y, int windowWidth, int windowHeight, int step, int actionRadius, IPublisher publisher)
        {

            if (x < 0)
                throw new ArgumentOutOfRangeException("Abscissa value can't be a negative number!");

            if (y < 0)
                throw new ArgumentOutOfRangeException("Ordinate value can't be a negative number!");

            if (windowWidth < 0)
                throw new ArgumentOutOfRangeException("Window width can't be a negative number!");

            if (windowHeight < 0)
                throw new ArgumentOutOfRangeException("Window height can't be a negative number!");

            if (windowWidth < x || windowHeight < y)
                throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("Step value should be a positive number!");

            if (actionRadius < 0)
                throw new ArgumentOutOfRangeException("Action radius value can't be a negative number!");

            if (publisher == null)
                throw new ArgumentNullException("Publisher must refer to an object!");

            X = x;
            Y = y;

            Step = step;
            ActionRadius = actionRadius;

            PublisherObject = publisher;

        }

        public void Move(DirectionType direction, int windowWidth, int windowHeight)
        {

            if (windowWidth < 0)
                throw new ArgumentOutOfRangeException("Window width can't be a negative number!");

            if (windowHeight < 0)
                throw new ArgumentOutOfRangeException("Window height can't be a negative number!");

            if (windowWidth < X || windowHeight < Y)
                throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

            switch (direction) {
                case DirectionType.Up:
                    if (Y >= Step)
                        Y = Y - Step;
                    break;
                case DirectionType.Down:
                    if (Y <= windowHeight - Step)
                        Y = Y + Step;
                    break;
                case DirectionType.Right:
                    if (X <= windowWidth - Step)
                        X = X + Step;
                    break;
                case DirectionType.Left:
                    if (X >= Step)
                        X = X - Step;
                    break;
            }

            PublisherObject.NotifyObserversAsync(X, Y, windowWidth, windowHeight, ActionRadius);

        }
        
    }
}
