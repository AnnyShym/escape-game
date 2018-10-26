using System.Collections.Generic;

namespace EscapeGame.Interfaces
{
    public interface IPublisher
    {

        List<IObserver> ObserverList { get; }

        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        void NotifyObserversAsync(int x, int y, int windowWidth, int windowHeight, int actionRadius);

    }
}
