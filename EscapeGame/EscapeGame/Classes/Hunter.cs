using EscapeGame.Interfaces;
using EscapeGame.Types;
using System;

namespace EscapeGame.Classes
{
    /// <summary>
    /// The A point
    /// </summary>
    public class Hunter : IHunter, IDisposable
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ActionRadius { get; private set; }

        public IPublisher PublisherObject { get; private set; }

        private bool isDisposed;

        public Hunter(int x, int y, int windowWidth, int windowHeight, int step, int actionRadius, IPublisher publisher)
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

            isDisposed = false;

        }

        /// <summary>
        /// Public method for moving the point
        /// </summary>
        /// <param name="direction">The direction of the movement</param>
        /// <param name="windowWidth">Current window width</param>
        /// <param name="windowHeight">Current window height</param>
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
                    if (Y > Step)
                        Y = Y - Step;
                    else
                        Y = 0;
                    break;
                case DirectionType.Down:
                    if (Y < windowHeight - Step)
                        Y = Y + Step;
                    else
                        Y = windowHeight;
                    break;
                case DirectionType.Right:
                    if (X < windowWidth - Step)
                        X = X + Step;
                    else
                        X = windowWidth;
                    break;
                case DirectionType.Left:
                    if (X > Step)
                        X = X - Step;
                    else
                        X = 0;
                    break;
            }

            PublisherObject.NotifyObservers(new ThreatMessage(X, Y, windowWidth, windowHeight, ActionRadius));

        }

        public void Move(int windowWidth, int windowHeight, int x, int y)
        {

            if (windowWidth < 0)
                throw new ArgumentOutOfRangeException("Window width can't be a negative number!");

            if (windowHeight < 0)
                throw new ArgumentOutOfRangeException("Window height can't be a negative number!");

            if (windowWidth < X || windowHeight < Y)
                throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

            int moveX, moveY;
            double tgA;

            tgA = (y - Y) / (x - X);

            moveX = (int)Math.Sqrt((Step * Step) / (tgA * tgA + 1));
            moveY = (int)Math.Abs(tgA) * moveX;

            if (x > X && y < Y) {

               if (X + moveX <= windowWidth)
                    X = X + moveX;
                else
                    X = windowWidth;

                if (Y - moveY > 0)
                    Y = Y - moveY;
                else
                    Y = 0;

            }
            if (x < X && y < Y) {

                if (X - moveX > 0)
                    X = X - moveX;
                else
                    X = 0;

                if (Y - moveY > 0)
                    Y = Y - moveY;
                else
                    Y = 0;

            }
            if (x < X && y > Y) {

                if (X - moveX > 0)
                    X = X - moveX;
                else
                    X = 0;

                if (Y + moveY < windowHeight)
                    Y = Y + moveY;
                else
                    Y = windowHeight;

            }
            if (x > X && y > Y) {

                if (X + moveX < windowWidth)
                    X = X + moveX;
                else
                    X = windowWidth;

                if (Y + moveY < windowHeight)
                    Y = Y + moveY;
                else
                    Y = windowHeight;

            }

            PublisherObject.NotifyObservers(new ThreatMessage(X, Y, windowWidth, windowHeight, ActionRadius));

        }

        protected virtual void Dispose(bool flag)
        {

            if (isDisposed) return;

            if (flag)
                GC.SuppressFinalize(PublisherObject);

            PublisherObject = null; 

            isDisposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~Hunter()
        {
            Dispose(false);
        }

    }
}
