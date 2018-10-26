namespace EscapeGame.Interfaces
{
    public interface IObserver
    {

        int X { get; }
        int Y { get; }

        int Step { get; }
        int ThreatRadius { get; }

        bool GaveUp { get; }

        void Update(IMessage message);

    }
}
