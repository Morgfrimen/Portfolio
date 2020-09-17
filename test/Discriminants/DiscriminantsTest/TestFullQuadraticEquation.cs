using NUnit.Framework;
using QuadraticEquation;

namespace QuadraticEquationTest
{
    [TestFixture]
    public class TestFullQuadraticEquation
    {
        [Test]
        public void Test_FullQuadraticEquation_Dooble_Root()
        {
            //Первое уравнение
            double[] exciptOne = { 1, -8, 12 };
            double[] res1 = { 2, 6 };

            //Получаем запись с решением уравнения
            var actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]), res1);

            //Второе уравнение
            exciptOne = new double[] { 1, -2, -3 };
            res1 = new double[] { -1, 3 };

            //Получаем запись с решением уравнения
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]), res1);

            //Третье уравнение
            exciptOne = new double[] { -1, -2, 15 };
            res1 = new double[] { 3, -5 };

            //Получаем запись с решением уравнения
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]), res1);
        }

        [Test]
        public void Test_FullQuadraticEquation_One_Root()
        {
            //Первое уравнение
            double[] exciptOne = { 1, 12, 36 };
            double[] res1 = { -6 };

            //Получаем запись с решением уравнения
            var actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsOne);
            CollectionAssert.AreEqual(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]), res1);

            //Второе уравнение
            exciptOne = new double[] { 1, -6, 9 };
            res1 = new double[] { 3 };

            //Получаем запись с решением уравнения
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsOne);
            CollectionAssert.AreEqual(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]), res1);
        }

        [Test]
        public void Test_FullQuadraticEquation_Empty_Root()
        {
            //Первое уравнение
            double[] exciptOne = { 2, 1, 2 };

            //Получаем запись с решением уравнения
            var actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsEmpty);
            Assert.IsNull(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]));

            //Второе уравнение
            exciptOne = new double[] { 1, -6, 100 };

            //Получаем запись с решением уравнения
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord(exciptOne[0], exciptOne[1], exciptOne[2]);

            Assert.IsTrue(actual.IsEmpty);
            Assert.IsNull(FullQuadraticEquation.FullQuadraticEquationDoubleArray(exciptOne[0], exciptOne[1], exciptOne[2]));
        }
    }
}