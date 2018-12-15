using EscapeGame.Classes;
using EscapeGame.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EscapeGame.Tests
{
    [TestClass]
    public class PublisherTests
    {

        [TestMethod]
        public void Publisher_Where_AddObserver_Parameter_Observer_Is_Null()
        {
            Publisher publisher = new Publisher();
            Assert.ThrowsException<ArgumentNullException>(
                () => publisher.AddObserver(null));
        }

        [TestMethod]
        public void Publisher_Where_AddObserver_Parameter_Observer_IsNot_Null()
        {

            Publisher publisher = new Publisher();
            publisher.AddObserver(new Avoidant(0, 0, 1, 30));

            Assert.AreEqual(1, publisher.ObserverList.Count);

        }

        [TestMethod]
        public void Publisher_Where_RemoveObserver_Parameter_Observer_Is_Null()
        {
            Publisher publisher = new Publisher();
            Assert.ThrowsException<ArgumentNullException>(
                () => publisher.RemoveObserver(null));
        }

        [TestMethod]
        public void Publisher_Where_RemoveObserver_Parameter_Observer_IsNot_Null()
        {

            Publisher publisher = new Publisher();
            IAvoidant observer1 = new Avoidant(0, 0, 1, 30);
            IAvoidant observer2 = new Avoidant(0, 0, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer1);
            publisher.AddObserver(observer1);

            publisher.RemoveObserver(observer1);

            Assert.AreEqual(1, publisher.ObserverList.Count);

        }

        [TestMethod]
        public void Publisher_Where_NotifyObservers_Parameter_WindowWidth_LessThan_X_OfSome_Observers()
        {

            Publisher publisher = new Publisher();
            IAvoidant observer1 = new Avoidant(100, 50, 1, 30);
            IAvoidant observer2 = new Avoidant(50, 100, 3, 40);
            IAvoidant observer3 = new Avoidant(10, 110, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);            

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => publisher.NotifyObservers(new ThreatMessage(5, 90, 30, 200, 5)));

        }

        [TestMethod]
        public void Publisher_Where_NotifyObservers_Parameter_WindowHeight_LessThan_Y_OfSome_Observers()
        {

            Publisher publisher = new Publisher();
            IAvoidant observer1 = new Avoidant(100, 50, 1, 30);
            IAvoidant observer2 = new Avoidant(50, 100, 3, 40);
            IAvoidant observer3 = new Avoidant(10, 110, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);            

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => publisher.NotifyObservers(new ThreatMessage(5, 5, 200, 70, 5)));

        }

        [TestMethod]
        public void Publisher_Where_NotifyObservers_Parameters_WindowWidth_And_WindowHeight_MoreOrEqualTo_X_And_Y_OfAllThe_Observers_Respectively()
        {

            Publisher publisher = new Publisher();
            IAvoidant observer1 = new Avoidant(50, 100, 5, 30);
            IAvoidant observer2 = new Avoidant(50, 100, 5, 30);
            IAvoidant observer3 = new Avoidant(50, 100, 5, 30);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);

            publisher.NotifyObservers(new ThreatMessage(25, 75, 500, 1000, 5));

            Assert.IsTrue(((observer1.X == 55 && observer1.Y == 100) ||
                (observer1.X == 50 && observer1.Y == 105)) &&
                ((observer2.X == 55 && observer2.Y == 100) ||
                (observer2.X == 50 && observer2.Y == 105)) &&
                ((observer3.X == 55 && observer3.Y == 100) ||
                (observer3.X == 50 && observer3.Y == 105)));

        }

    }
}
