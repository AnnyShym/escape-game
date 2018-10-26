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

            List<ShiftCoordinateDelegate> optimalShifts = new List<ShiftCoordinateDelegate>();
            List<ShiftCoordinateDelegate> possibleShifts = new List<ShiftCoordinateDelegate>();
            ShiftCoordinateDelegate shiftCoordinate;

            if (Y - Step >= 0) {
                shiftCoordinate = () => Y = Y - Step;
                if (Math.Abs((Y - Step) - message.Y) > Math.Abs(Y - message.Y))
                    optimalShifts.Add(shiftCoordinate);
                else
                    possibleShifts.Add(shiftCoordinate);
            }
            if (Y + Step <= message.WindowHeight) {
                shiftCoordinate = () => Y = Y + Step;
                if (Math.Abs((Y + Step) - message.Y) > Math.Abs(Y - message.Y))
                    optimalShifts.Add(shiftCoordinate);
                else
                    possibleShifts.Add(shiftCoordinate);
            }
            if (X + Step <= message.WindowWidth) {
                shiftCoordinate = () => X = X + Step;
                if (Math.Abs((X + Step) - message.X) > Math.Abs(X - message.X))
                    optimalShifts.Add(shiftCoordinate);
                else
                    possibleShifts.Add(shiftCoordinate);
            }
            if (X - Step >= 0) {
                shiftCoordinate = () => X = X - Step;
                if (Math.Abs((X - Step) - message.X) > Math.Abs(X - message.X))
                    optimalShifts.Add(shiftCoordinate);
                else
                    possibleShifts.Add(shiftCoordinate);
            }

            if (optimalShifts.Count != 0) {

                Random random = new Random();
                int randomIndex = random.Next(optimalShifts.Count);

                optimalShifts[randomIndex]();

            }
            else
                if (Math.Abs(Y - message.Y) > Math.Abs(X - message.X))
                    possibleShifts[0]();
                else
                    possibleShifts[1]();

        }

    }
}
