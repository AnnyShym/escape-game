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
            publisher.AddObserver(new Observer(0, 0, 1, 30));

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
            IObserver observer1 = new Observer(0, 0, 1, 30);
            IObserver observer2 = new Observer(0, 0, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer1);
            publisher.AddObserver(observer1);

            publisher.RemoveObserver(observer1);

            Assert.AreEqual(1, publisher.ObserverList.Count);

        }

        [TestMethod]
        public void Publisher_Where_NotifyObserversAsync_Parameter_WindowWidth_LessThan_X_OfSome_Observers()
        {

            Publisher publisher = new Publisher();
            IObserver observer1 = new Observer(100, 50, 1, 30);
            IObserver observer2 = new Observer(50, 100, 3, 40);
            IObserver observer3 = new Observer(10, 110, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => publisher.NotifyObserversAsync(5, 5, 30, 200, 5));

        }

        [TestMethod]
        public void Publisher_Where_NotifyObserversAsync_Parameter_WindowHeight_LessThan_Y_OfSome_Observers()
        {

            Publisher publisher = new Publisher();
            IObserver observer1 = new Observer(100, 50, 1, 30);
            IObserver observer2 = new Observer(50, 100, 3, 40);
            IObserver observer3 = new Observer(10, 110, 3, 40);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => publisher.NotifyObserversAsync(5, 5, 200, 70, 5));

        }

        [TestMethod]
        public void Publisher_Where_NotifyObserversAsync_Parameters_WindowWidth_And_WindowHeight_MoreOrEqualTo_X_And_Y_OfAllThe_Observers_Respectively()
        {

            Publisher publisher = new Publisher();
            IObserver observer1 = new Observer(0, 0, 1, 30);
            IObserver observer2 = new Observer(0, 0, 3, 40);
            IObserver observer3 = new Observer(10, 100, 5, 70);

            publisher.AddObserver(observer1);
            publisher.AddObserver(observer2);
            publisher.AddObserver(observer3);

            try {
                publisher.NotifyObserversAsync(5, 5, 10, 100, 5);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

    }
}
