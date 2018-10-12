using Observation.Types;
using System.Collections.Generic;

namespace Observation
{
    public interface IObservable
    {

        List<IObserver> ObserverList { get; }

        int X { get; }
        int Y { get; }
        DirectionType Direction { get; }

        int WindowWidth { get; }
        int WindowHeight { get; }

        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);

        void Move(DirectionType direction, int windowWidth, int windowHeight);

    }
}
