using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace EscapeGame.Classes
{
    public class VectorObserver : IObserver
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ThreatRadius { get; private set; }

        public bool GaveUp { get; private set; }

        public VectorObserver(int x, int y, int step, int threatRadius)
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

        public void Update(IMessage message)
        {

            if (!GaveUp)
            {

                if (message.WindowWidth < X || message.WindowHeight < Y)
                    throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

                if (Math.Abs(message.X - X) <= message.ActionRadius && Math.Abs(message.Y - Y) <= message.ActionRadius)
                    GaveUp = true;
                else
                    if (Math.Abs(message.X - X) <= ThreatRadius && Math.Abs(message.Y - Y) <= ThreatRadius)
                    RunAway(message);

            }

        }

        private delegate void ShiftCoordinateDelegate();

        private void RunAway(IMessage message)
        {

            int moveX, moveY, preciseMoveX;
            double tgA;

            tgA = (message.Y - Y) / (message.X - X);

            moveX = (int)Math.Sqrt((Step * Step) / (tgA * tgA + 1));
            preciseMoveX = moveX;
            moveY = (int)Math.Abs(tgA) * moveX;

            if (message.X < X && message.Y > Y) {

                if (X + moveX < message.WindowWidth)
                    X = X + moveX;
                else {
                    moveX = message.WindowWidth - X;
                    X = message.WindowWidth;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y - moveY > 0)
                    Y = Y - moveY;
                else {
                    moveY = Y;
                    Y = 0;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X + (moveX - preciseMoveX) < message.WindowWidth) ? X + (moveX - preciseMoveX) : message.WindowWidth;
                }

            }
            if (message.X > X && message.Y > Y) {

                if (X - moveX > 0)
                    X = X - moveX;
                else {
                    moveX = X;
                    X = 0;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y - moveY > 0)
                    Y = Y - moveY;
                else {
                    moveY = Y;
                    Y = 0;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X - (moveX - preciseMoveX) > 0) ? X - (moveX - preciseMoveX) : 0;
                }

            }
            if (message.X > X && message.Y < Y)
            {

                if (X - moveX > 0)
                    X = X - moveX;
                else {
                    moveX = X;
                    X = 0;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y + moveY < message.WindowHeight)
                    Y = Y + moveY;
                else {
                    moveY = message.WindowHeight - Y;
                    Y = message.WindowHeight;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X - (moveX - preciseMoveX) > 0) ? X - (moveX - preciseMoveX) : 0;
                }

            }
            if (message.X < X && message.Y < Y) {

                if (X + moveX < message.WindowWidth)
                    X = X + moveX;
                else  {
                    X = message.WindowWidth;
                    moveX = message.WindowWidth - X;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y + moveY < message.WindowHeight)
                    Y = Y + moveY;
                else {
                    moveY = message.WindowHeight - Y;
                    Y = message.WindowHeight;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X + (moveX - preciseMoveX) > 0) ? X + (moveX - preciseMoveX) : 0;
                }

            }

        }

    }
}
