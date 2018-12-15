using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace EscapeGame.Classes
{
    /// <summary>
    /// Public interface for creating Observable-Observers pattern
    /// </summary>
    public class Avoidant : IAvoidant
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ThreatRadius { get; private set; }

        public bool GaveUp { get; private set; }

        public Avoidant(int x, int y, int step, int threatRadius)
        {

            if (x < 0)
                throw new ArgumentOutOfRangeException("Abscissa value can't be a negative number!");

            if (y < 0)
                throw new ArgumentOutOfRangeException("Ordinate value can't be a negative number!");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("Step value should be a positive number!");

            if (threatRadius <= 0)
                throw new ArgumentOutOfRangeException("Thread radius value should be a positive number!");

            X = x;
            Y = y;

            Step = step;
            ThreatRadius = threatRadius;

            GaveUp = false;

        }

        /// <summary>
        /// Method for changing the condition of the observer after getting the <param name="message"/>
        /// </summary>
        /// <param name="message">Message from observable</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the input coordinates are out of the window borders</exception>
        public void Update(IMessage message)
        {

            IThreatMessage threatMessage = message as IThreatMessage;

            if (message != null)
                if (!GaveUp) {

                    if (threatMessage.WindowWidth < X || threatMessage.WindowHeight < Y)
                        throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

                    if (Math.Abs(threatMessage.X - X) <= threatMessage.ActionRadius && Math.Abs(threatMessage.Y - Y) <= threatMessage.ActionRadius)
                        GaveUp = true;
                    else
                        if (Math.Abs(threatMessage.X - X) <= ThreatRadius && Math.Abs(threatMessage.Y - Y) <= ThreatRadius)
                            RunAway(threatMessage);

                }

        }

        private delegate void ShiftCoordinateDelegate();

        private void RunAway(IThreatMessage message)
        {

            List<ShiftCoordinateDelegate> optimalShifts = new List<ShiftCoordinateDelegate>();
            ShiftCoordinateDelegate shiftCoordinate;

            if (Y - Step >= 0)
                if (Math.Abs((Y - Step) - message.Y) > Math.Abs(Y - message.Y))
                    optimalShifts.Add(shiftCoordinate = (() => Y = Y - Step));
            if (Y + Step <= message.WindowHeight)
                if (Math.Abs((Y + Step) - message.Y) > Math.Abs(Y - message.Y))
                    optimalShifts.Add(shiftCoordinate = (() => Y = Y + Step));
            if (X + Step <= message.WindowWidth)
                if (Math.Abs((X + Step) - message.X) > Math.Abs(X - message.X))
                    optimalShifts.Add(shiftCoordinate = (() => X = X + Step));
            if (X - Step >= 0)
                shiftCoordinate = () => X = X - Step;
                if (Math.Abs((X - Step) - message.X) > Math.Abs(X - message.X))
                    optimalShifts.Add(shiftCoordinate = (() => X = X - Step));

            if (optimalShifts.Count != 0) {

                Random random = new Random();
                int randomIndex = random.Next(optimalShifts.Count);

                optimalShifts[randomIndex]();

            }

        }

    }
}
