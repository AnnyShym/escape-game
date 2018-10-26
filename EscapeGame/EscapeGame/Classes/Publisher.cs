using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async void NotifyObserversAsync(int x, int y, int windowWidth, int windowHeight, int actionRadius)
        {

            IMessage message = new Message(x, y, windowWidth, windowHeight, actionRadius);
            Task task;
            List<Task> tasks = new List<Task>();
            Task allTasks = null;

            try {

                foreach (IObserver observer in ObserverList)
                {
                    task = Task.Run(() => observer.Update(message));
                    tasks.Add(task);
                }

                allTasks = Task.WhenAll(tasks);
                await allTasks;

            }
            catch {

                foreach (var ex in allTasks.Exception.InnerExceptions)
                    throw ex;

            }

        }

    }
}
