using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EscapeGame.Classes
{
    /// <summary>
    /// Pubic class for creating Observable-Observers pattern
    /// </summary>
    public class Publisher: IPublisher 
    {

        /// <summary>
        /// All observers of the observable
        /// </summary>
        public List<IObserver> ObserverList { get; private set; }

        public Publisher()
        {
            ObserverList = new List<IObserver>();            
        }

        /// <summary>
        /// Method for adding new observer to the list of observers of the observable
        /// </summary>
        /// <param name="observer">Observer object for adding</param>
        /// <exception cref="ArgumentNullException">Is thrown if input observer if equal to null</exception>
        public void AddObserver(IObserver observer)
        {

            if (observer == null)
                throw new ArgumentNullException("Observer must refer to an object!");

            ObserverList.Add(observer);

        }

        /// <summary>
        /// Method for removing the observer from the list of observers
        /// </summary>
        /// <param name="observer">Observer object for deleting</param>
        /// <exception cref="ArgumentNullException">Is thrown if input observer if equal to null</exception>
        public void RemoveObserver(IObserver observer)
        {

            if (observer == null)
                throw new ArgumentNullException("Observer must refer to an object!");

            while (ObserverList.Remove(observer));

        }

        /// <summary>
        /// Method for informing all observers from the list about movement of the hunter
        /// </summary>
        /// <param name="message">The message to send</param>
        public void NotifyObservers(IMessage message)
        {

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

                throw new ArgumentOutOfRangeException($"Oops... Some errors occured while using NotifyObservers method! ({exceptionsCount})");

            }               

        }

    }
}
