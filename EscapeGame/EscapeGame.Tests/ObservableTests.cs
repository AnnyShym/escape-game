using EscapeGame.Classes;
using EscapeGame.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EscapeGame.Tests
{
    [TestClass]
    public class ObservableTests
    {

        //////////////////////////////////////////// EXCEPTIONS ///////////////////////////////////////////////

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_X_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(-1, 100, 1000, 500, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_X_MoreOrEqualTo_Zero()
        {
            try {
                Hunter observable = new Hunter(0, 100, 1000, 500, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Y_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, -1, 1000, 500, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Y_MoreOrEqualTo_Zero()
        {
            try {
                Hunter observable = new Hunter(50, 0, 1000, 500, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowWidth_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, -1, 500, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowWidth_MoreOrEqualTo_Zero()
        {
            try {
                Hunter observable = new Hunter(0, 0, 0, 500, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowHeight_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 1000, -1, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowHeight_MoreOrEqualTo_Zero()
        {
            try {
                Hunter observable = new Hunter(0, 0, 1000, 0, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowWidth_LessThan_X()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 10, 100, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowHeight_LessThan_Y()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 50, 10, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowWidth_LessThan_X_And_WindowHeight_LessThan_Y()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 10, 10, 10, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_WindowWidth_MoreOrEqualTo_X_And_WindowHeight_MoreOrEqualTo_Y()
        {
            try {
                Hunter observable = new Hunter(50, 100, 50, 100, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Step_LessThan_One()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 1000, 500, 0, 3, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Step_MoreOrEqualTo_One()
        {
            try {
                Hunter observable = new Hunter(50, 100, 1000, 500, 1, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_ActionRadius_LessThan_Zero()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => new Hunter(50, 100, 1000, 500, 10, -1, new Publisher()));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_ActionRadius_MoreOrEqualTo_Zero()
        {
            try {
                Hunter observable = new Hunter(50, 100, 1000, 500, 10, 0, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Publisher_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => new Hunter(50, 100, 1000, 500, 10, 3, null));
        }

        [TestMethod]
        public void Observable_Where_Constructor_Parameter_Publisher_IsNot_Null()
        {
            try {
                Hunter observable = new Hunter(50, 100, 1000, 500, 10, 3, new Publisher());
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowWidth_LessThan_Zero()
        {
            Hunter observable = new Hunter(0, 0, 1000, 500, 10, 3, new Publisher());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observable.Move(DirectionType.Up, -1, 500));
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowWidth_MoreOrEqualTo_Zero()
        {

            Hunter observable = new Hunter(0, 0, 1000, 500, 10, 3, new Publisher());

            try {
                observable.Move(DirectionType.Up, 0, 500);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowHeight_LessThan_Zero()
        {
            Hunter observable = new Hunter(0, 0, 1000, 500, 10, 3, new Publisher());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observable.Move(DirectionType.Up, 1000, -1));
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowHeight_MoreOrEqualTo_Zero()
        {

            Hunter observable = new Hunter(0, 0, 1000, 500, 10, 3, new Publisher());

            try {
                observable.Move(DirectionType.Up, 1000, 0);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowWidth_LessThan_X()
        {
            Hunter observable = new Hunter(50, 100, 1000, 500, 10, 3, new Publisher());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observable.Move(DirectionType.Up, 10, 500));
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowHeight_LessThan_Y()
        {
            Hunter observable = new Hunter(50, 100, 1000, 500, 10, 3, new Publisher());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observable.Move(DirectionType.Up, 1000, 10));
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowWidth_LessThan_X_And_WindowHeight_LessThan_Y()
        {
            Hunter observable = new Hunter(50, 100, 1000, 500, 10, 3, new Publisher());
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => observable.Move(DirectionType.Up, 10, 10));
        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_WindowWidth_MoreOrEqualTo_X_And_WindowHeight_MoreOrEqualTo_Y()
        {

            Hunter observable = new Hunter(50, 100, 1000, 500, 10, 3, new Publisher());

            try {
                observable.Move(DirectionType.Up, 50, 100);
            }
            catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }

        }

        ////////////////////////////////////////////// MOTION ///////////////////////////////////////////////////

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Up_And_TheBorder_DoesNot_Interfere()
        {

            Hunter observable = new Hunter(50, 10, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Up, 1000, 500);

            Assert.AreEqual(50, observable.X);
            Assert.AreEqual(0, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Up_And_TheBorder_Interferes()
        {

            Hunter observable = new Hunter(50, 9, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Up, 1000, 500);

            Assert.AreEqual(50, observable.X);
            Assert.AreEqual(9, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Down_And_TheBorder_DoesNot_Interfere()
        {

            Hunter observable = new Hunter(50, 490, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Down, 1000, 500);

            Assert.AreEqual(50, observable.X);
            Assert.AreEqual(500, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Down_And_TheBorder_Interferes()
        {

            Hunter observable = new Hunter(50, 491, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Down, 1000, 500);

            Assert.AreEqual(50, observable.X);
            Assert.AreEqual(491, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Right_And_TheBorder_DoesNot_Interfere()
        {

            Hunter observable = new Hunter(990, 100, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Right, 1000, 500);

            Assert.AreEqual(1000, observable.X);
            Assert.AreEqual(100, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Right_And_TheBorder_Interferes()
        {

            Hunter observable = new Hunter(991, 100, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Right, 1000, 500);

            Assert.AreEqual(991, observable.X);
            Assert.AreEqual(100, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Left_And_TheBorder_DoesNot_Interfere()
        {

            Hunter observable = new Hunter(10, 100, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Left, 1000, 500);

            Assert.AreEqual(0, observable.X);
            Assert.AreEqual(100, observable.Y);

        }

        [TestMethod]
        public void Observable_Where_Move_Parameter_Direction_Is_Left_And_TheBorder_Interferes()
        {

            Hunter observable = new Hunter(9, 100, 1000, 500, 10, 3, new Publisher());
            observable.Move(DirectionType.Left, 1000, 500);

            Assert.AreEqual(9, observable.X);
            Assert.AreEqual(100, observable.Y);

        }

    }
}
