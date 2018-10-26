using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace EscapeGame.Classes
{
    public class Observer : IObserver
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ThreatRadius { get; private set; }

        public bool GaveUp { get; private set; }

        public Observer(int x, int y, int step, int threadRadius)
        {

            if (x < 0)
                throw new ArgumentOutOfRangeException("Abscissa value can't be a negative number!");

            if (y < 0)
                throw new ArgumentOutOfRangeException("Ordinate value can't be a negative number!");

            if (step <= 0)
                throw new ArgumentOutOfRangeException("Step value should be a positive number!");

            if (threadRadius <= 0)
                throw new ArgumentOutOfRangeException("Thread radius value should be a positive number!");

            X = x;
            Y = y;

            Step = step;
            ThreatRadius = threadRadius;

            GaveUp = false;

        }

        public void Update(IMessage message)
        {

            if (!GaveUp)
            {

                if (message.WindowWidth < X || message.WindowHeight < Y)
                    throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

                if (Math.Abs(message.X - X) <= message.ActionRadius || Math.Abs(message.Y - Y) <= message.ActionRadius)
                    GaveUp = true;
                else
                    if (Math.Abs(message.X - X) <= ThreatRadius || Math.Abs(message.Y - Y) <= ThreatRadius)
                    RunAway(message);

            }

        }

        private delegate void ShiftCoordinateDelegate();

        private void RunAway(IMessage message)
        {

            List<ShiftCoordinateDelegate> possibleShifts = new List<ShiftCoordinateDelegate>();
            ShiftCoordinateDelegate shiftCoordinate;

            if (Y - Step >= 0)
                if (Math.Abs((Y - Step) - message.Y) > Math.Abs(Y - message.Y))
                    possibleShifts.Add(shiftCoordinate = (() => Y = Y - Step));
            if (Y + Step <= message.WindowHeight)
                if (Math.Abs((Y + Step) - message.Y) > Math.Abs(Y - message.Y))
                    possibleShifts.Add(shiftCoordinate = (() => Y = Y + Step));
            if (X + Step <= message.WindowWidth)
                if (Math.Abs((X + Step) - message.X) > Math.Abs(X - message.X))
                    possibleShifts.Add(shiftCoordinate = (() => X = X + Step));
            if (X - Step >= 0)
                if (Math.Abs((X - Step) - message.X) > Math.Abs(X - message.X))
                    possibleShifts.Add(shiftCoordinate = (() => X = X - Step));

            Random random = new Random();
            int randomIndex = random.Next(possibleShifts.Count);

            possibleShifts[randomIndex]();

        }

    }
}
