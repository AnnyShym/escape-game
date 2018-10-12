using Observation.Types;
using System.Collections.Generic;

namespace Observation
{
    public interface IObservable
    {

        List<IObserver> ObserverList { get; }

        int X { get; }
        int Y { get; }

        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        void Move(DirectionType direction);

    }
}
