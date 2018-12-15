namespace EscapeGame.Interfaces
{
    /// <summary>
    /// Public interface for creating Observable-Observers pattern
    /// </summary>
    public interface IAvoidant : IObserver
    {

        int X { get; }
        int Y { get; }

        int Step { get; }
        int ThreatRadius { get; }

        bool GaveUp { get; }

    }
}
