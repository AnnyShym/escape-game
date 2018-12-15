namespace EscapeGame.Interfaces
{
    /// <summary>
    /// Public interface for creating Observable-Observers pattern
    /// </summary>
    public interface IObserver
    {

        int X { get; }
        int Y { get; }

        int Step { get; }
        int ThreatRadius { get; }

        bool GaveUp { get; }

        /// Method for changing the condition of the observer after getting the <param name="message"/>
        /// </summary>
        /// <param name="message">Message from observable</param>
        void Update(IMessage message);

    }
}
