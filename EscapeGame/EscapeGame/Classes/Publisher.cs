using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace EscapeGame.Classes
{
    public class Publisher: IPublisher 
    {

        public List<IObserver> ObserverList { get; private set; }

        public Publisher(IObservable observable)
        {
            ObserverList = new List<IObserver>();            
        }

        public void AddObserver(IObserver observer)
        {

            if (observer == null)
                throw new ArgumentNullException("Observer must refer to an object!");

            ObserverList.Add(observer);

        }

        public void RemoveObserver(IObserver observer)
        {

            if (observer == null)
                throw new ArgumentNullException("Observer must refer to an object!");

            while (ObserverList.Remove(observer));

        }

        public void NotifyObservers(int x, int y, int windowWidth, int windowHeight, int actionRadius)
        {
            foreach (IObserver observer in ObserverList)
                observer.Update(new Message(x, y, windowWidth, windowHeight, actionRadius));
        }

    }
}
