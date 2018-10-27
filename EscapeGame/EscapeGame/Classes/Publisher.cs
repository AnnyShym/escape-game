using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscapeGame.Classes
{
    public class Publisher: IPublisher 
    {

        public List<IObserver> ObserverList { get; private set; }

        public Publisher()
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

            IMessage message = new Message(x, y, windowWidth, windowHeight, actionRadius);
            Task[] tasks = new Task[ObserverList.Count];

            try {

                int i = 0;
                foreach (IObserver observer in ObserverList) {
                    tasks[i++] = Task.Run(() => observer.Update(message));
                }

                Task.WaitAll(tasks);

            }
            catch {

                int exceptionsCount = 0;
                foreach (var task in tasks)
                    if (task.Exception != null)
                        exceptionsCount++;

                throw new ArgumentOutOfRangeException($"Point can't be outside the window area! ({exceptionsCount})");

            }               

        }

    }
}
