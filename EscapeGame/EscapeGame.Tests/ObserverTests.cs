using EscapeGame.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EscapeGame.Tests
{
    [TestClass]
    public class ObserverTests
    {

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_X_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Observer(-1, 100, 3, 30));
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_X_MoreOrEqualTo_Zero()
        {
            try {
                Observer observer = new Observer(0, 100, 3, 30);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_Y_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Observer(50, -1, 3, 30));
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_Y_MoreOrEqualTo_Zero()
        {
            try {
                Observer observer = new Observer(50, 0, 3, 30);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_Step_LessOrEqualTo_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Observer(50, 100, 0, 30));
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_Step_MoreThan_Zero()
        {
            try {
                Observer observer = new Observer(50, 100, 1, 30);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_ThreatRadius_LessOrEqualTo_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Observer(50, 100, 3, 0));
        }

        [TestMethod]
        public void Observer_Where_Constructor_Parameter_ThreatRadius_MoreThan_Zero()
        {
            try {
                Observer observer = new Observer(50, 100, 3, 1);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observer_Where_GaveUp_Property_IsTrue()
        {

            Observer observer = new Observer(50, 100, 3, 1);

            observer.Update(new Message(50, 95, 1000, 500, 5));
            observer.Update(new Message(60, 95, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_GaveUp_Property_IsFalse()
        {

            Observer observer = new Observer(50, 100, 5, 50);
            observer.Update(new Message(80, 70, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Update_Parameter_Message_Property_WindowWidth_LessThan_X()
        {
            Observer observer = new Observer(50, 100, 3, 1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observer.Update(new Message(10, 10, 49, 150, 5)));
        }

        [TestMethod]
        public void Observer_Where_Update_Parameter_Message_Property_WindowHeight_LessThan_Y()
        {
            Observer observer = new Observer(50, 100, 3, 1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observer.Update(new Message(10, 10, 150, 99, 5)));
        }

        [TestMethod]
        public void Observer_Where_Update_Parameter_Message_Properties_WindowWidth_LessThan_X_And_WindowHeight_LessThan_Y()
        {
            Observer observer = new Observer(50, 100, 3, 1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observer.Update(new Message(10, 10, 49, 99, 5)));
        }

        [TestMethod]
        public void Observer_Where_Update_Parameter_Message_Properties_WindowWidth_MoreOrEqualTo_X_And_WindowHeight_MoreOrEqualTo_Y()
        {

            Observer observer = new Observer(50, 100, 3, 1);

            try {
                observer.Update(new Message(10, 10, 1000, 500, 5));
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Upper_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(50, 95, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Upper_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(50, 94, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnRight_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(55, 95, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnRight_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(55, 94, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnRight_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(55, 100, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnRight_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(56, 100, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnRight_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(55, 105, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnRight_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(56, 105, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Below_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(50, 105, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Below_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(50, 106, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnLeft_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(45, 105, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnLeft_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(45, 106, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnLeft_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(45, 100, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnLeft_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(44, 100, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnLeft_And_Observer_IsIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(45, 95, 1000, 500, 5));

            Assert.IsTrue(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnLeft_And_Observer_IsNotIn_Observable_ActionRadius()
        {

            Observer observer = new Observer(50, 100, 3, 1);
            observer.Update(new Message(44, 95, 1000, 500, 5));

            Assert.IsFalse(observer.GaveUp);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Upper_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(50, 70, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 55 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Upper_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(50, 69, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnRight_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(80, 70, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnRight_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(81, 70, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnRight_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(80, 100, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 95) ||
                (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnRight_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(81, 100, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnRight_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(80, 130, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 95));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnRight_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(80, 131, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Below_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(50, 130, 1000, 500, 5));

            Assert.IsTrue((observer.X == 45 && observer.Y == 100) ||
                (observer.X == 55 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 95));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_Below_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(50, 131, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnLeft_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(20, 130, 1000, 500, 5));

            Assert.IsTrue((observer.X == 55 && observer.Y == 100) ||
                    (observer.X == 50 && observer.Y == 95));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_BelowAndOnLeft_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(19, 130, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnLeft_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(20, 100, 1000, 500, 5));

            Assert.IsTrue((observer.X == 55 && observer.Y == 100) ||
                (observer.X == 50 && observer.Y == 95) ||
                (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_OnLeft_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(19, 100, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnLeft_And_IsIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(20, 70, 1000, 500, 5));

            Assert.IsTrue((observer.X == 55 && observer.Y == 100) ||
                    (observer.X == 50 && observer.Y == 105));

        }

        [TestMethod]
        public void Observer_Where_Observable_Is_UpperAndOnLeft_And_IsNotIn_Observer_ThreatRadius()
        {

            Observer observer = new Observer(50, 100, 5, 30);
            observer.Update(new Message(20, 69, 1000, 500, 5));

            Assert.IsTrue(observer.X == 50 && observer.Y == 100);

        }



    }
}
