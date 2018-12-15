using System.Collections.Generic;

namespace EscapeGame.Interfaces
{
    public interface IPublisher
    {

        List<IObserver> ObserverList { get; }

        /// <summary>
        /// Method for adding new observer to the list of observers of the observable
        /// </summary>
        /// <param name="observer">Observer object for adding</param>
        void AddObserver(IObserver observer);

        /// <summary>
        /// Method for removing the observer from the list of observers
        /// </summary>
        /// <param name="observer">Observer object for deleting</param>
        void RemoveObserver(IObserver observer);

        /// <summary>
        /// Method for informing all observers from the list about movement of the hunter
        /// </summary>
        /// <param name="message">The message to send</param>
        void NotifyObservers(IMessage message);

    }
}
