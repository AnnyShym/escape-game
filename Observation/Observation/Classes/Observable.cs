using Observation.Types;
using System;
using System.Collections.Generic;

namespace Observation.Classes
{
    public class Observable : IObservable
    {

        public List<IObserver> ObserverList { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }
        public DirectionType Direction { get; private set; }

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public Observable(int x, int y)
        {

            ObserverList = new List<IObserver>();

            if (x < 0)
                throw new ArgumentOutOfRangeException("Abscissa value can't be a negative number!");

            if (y < 0)
                throw new ArgumentOutOfRangeException("Ordinate value can't be a negative number!");

            X = x;
            Y = y;
            Direction = DirectionType.None;

        }

        public void AddObserver(IObserver observer)
        {
            ObserverList.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            ObserverList.Remove(observer);
        }

        private void NotifyObservers()
        {
            foreach (IObserver observer in ObserverList)
                observer.Update(new Message(X, Y, Direction, WindowWidth, WindowHeight));
        }

        public void Move(DirectionType direction, int windowWidth, int windowHeight)
        {

            if (windowWidth < 0)
                throw new ArgumentOutOfRangeException("Window width can't be a negative number!");

            if (windowHeight < 0)
                throw new ArgumentOutOfRangeException("Window height can't be a negative number!");

            Direction = direction;
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

            switch (direction) {
                case DirectionType.Up:
                    if (Y > 0)
                        Y--;
                    break;
                case DirectionType.Down:
                    if (Y < windowHeight)
                        Y++;
                    break;
                case DirectionType.Right:
                    if (X < windowWidth)
                        X++;
                    break;
                case DirectionType.Left:
                    if (X > 0)
                        X--;
                    break;
            }

            NotifyObservers();

        }

    }
}
