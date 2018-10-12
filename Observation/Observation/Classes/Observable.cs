using Observation.Types;
using System.Collections.Generic;

namespace Observation.Classes
{
    public class Observable : IObservable
    {

        public List<IObserver> ObserverList { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public Observable()
        {

            ObserverList = new List<IObserver>();

            // Рандом
            X = 0;
            Y = 0;

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
                observer.Update(new Message(X, Y));
        }

        public void Move(DirectionType direction)
        {

            switch(direction) {
                case DirectionType.Up:
                    Y++;
                    break;
                case DirectionType.Down:
                    Y--;
                    break;
                case DirectionType.Right:
                    X++;
                    break;
                case DirectionType.Left:
                    X--;
                    break;
            }

            NotifyObservers();

        }

        // Сохранить границы

    }
}
