using EscapeGame.Interfaces;
using System;
using System.Collections.Generic;

namespace EscapeGame.Classes
{
    public class VectorAvoidant : IAvoidant
    {

        public int X { get; private set; }
        public int Y { get; private set; }

        public int Step { get; private set; }
        public int ThreatRadius { get; private set; }

        public bool GaveUp { get; private set; }

        public VectorAvoidant(int x, int y, int step, int threatRadius)
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

            IThreatMessage threatMessage = message as IThreatMessage;

            if (message != null)
                if (!GaveUp) {

                    if (threatMessage.WindowWidth < X || threatMessage.WindowHeight < Y)
                        throw new ArgumentOutOfRangeException("Point can't be outside the window area!");

                    if (Math.Abs(threatMessage.X - X) <= threatMessage.ActionRadius && Math.Abs(threatMessage.Y - Y) <= threatMessage.ActionRadius)
                        GaveUp = true;
                    else
                        if (Math.Abs(threatMessage.X - X) <= ThreatRadius && Math.Abs(threatMessage.Y - Y) <= ThreatRadius)
                            RunAway(message);

                }

        }

        private delegate void ShiftCoordinateDelegate();

        private void RunAway(IMessage message)
        {

            IThreatMessage threatMessage = (IThreatMessage)message;

            int moveX, moveY, preciseMoveX;
            double tgA;

            tgA = (threatMessage.Y - Y) / (threatMessage.X - X);

            moveX = (int)Math.Sqrt((Step * Step) / (tgA * tgA + 1));
            preciseMoveX = moveX;
            moveY = (int)Math.Abs(tgA) * moveX;

            if (threatMessage.X < X && threatMessage.Y > Y) {

                if (X + moveX < threatMessage.WindowWidth)
                    X = X + moveX;
                else {
                    moveX = threatMessage.WindowWidth - X;
                    X = threatMessage.WindowWidth;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y - moveY > 0)
                    Y = Y - moveY;
                else {
                    moveY = Y;
                    Y = 0;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X + (moveX - preciseMoveX) < threatMessage.WindowWidth) ? X + (moveX - preciseMoveX) : threatMessage.WindowWidth;
                }

            }
            if (threatMessage.X > X && threatMessage.Y > Y) {

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
            if (threatMessage.X > X && threatMessage.Y < Y)
            {

                if (X - moveX > 0)
                    X = X - moveX;
                else {
                    moveX = X;
                    X = 0;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y + moveY < threatMessage.WindowHeight)
                    Y = Y + moveY;
                else {
                    moveY = threatMessage.WindowHeight - Y;
                    Y = threatMessage.WindowHeight;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X - (moveX - preciseMoveX) > 0) ? X - (moveX - preciseMoveX) : 0;
                }

            }
            if (threatMessage.X < X && threatMessage.Y < Y) {

                if (X + moveX < threatMessage.WindowWidth)
                    X = X + moveX;
                else  {
                    X = threatMessage.WindowWidth;
                    moveX = threatMessage.WindowWidth - X;
                    moveY = (int)Math.Sqrt(Step * Step - moveX * moveX);
                }

                if (Y + moveY < threatMessage.WindowHeight)
                    Y = Y + moveY;
                else {
                    moveY = threatMessage.WindowHeight - Y;
                    Y = threatMessage.WindowHeight;
                    moveX = (int)Math.Sqrt(Step * Step - moveY * moveY);
                    X = (X + (moveX - preciseMoveX) > 0) ? X + (moveX - preciseMoveX) : 0;
                }

            }

        }

    }
}
