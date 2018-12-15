namespace EscapeGame.Interfaces
{
    /// <summary>
    /// Public interface for creating Observable-Observers pattern
    /// </summary>
    public interface IObserver
    {
        /// Method for changing the condition of the observer after getting the <param name="message"/>
        /// </summary>
        /// <param name="message">Message from observable</param>
        void Update(IMessage message);
    }
}
