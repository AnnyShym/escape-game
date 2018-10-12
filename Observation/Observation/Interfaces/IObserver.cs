using Observation.Classes;

namespace Observation
{
    public interface IObserver
    {

        int X { get; }
        int Y { get; }

        void Update(IMessage message);

    }
}
