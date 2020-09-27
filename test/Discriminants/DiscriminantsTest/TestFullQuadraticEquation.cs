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
            //������ ���������
            double[] exciptOne = {1, -8, 12};
            double[] res1 = {2, 6};

            //�������� ������ � �������� ���������
            ResultFullQuadraticEquation actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]),
                actual: res1
            );

            //������ ���������
            exciptOne = new double[] {1, -2, -3};
            res1 = new double[] {-1, 3};

            //�������� ������ � �������� ���������
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]),
                actual: res1
            );

            //������ ���������
            exciptOne = new double[] {-1, -2, 15};
            res1 = new double[] {3, -5};

            //�������� ������ � �������� ���������
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]),
                actual: res1
            );
        }

        [Test]
        public void Test_FullQuadraticEquation_Empty_Root()
        {
            //������ ���������
            double[] exciptOne = {2, 1, 2};

            //�������� ������ � �������� ���������
            ResultFullQuadraticEquation actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsEmpty);
            Assert.IsNull
            (
                anObject: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2])
            );

            //������ ���������
            exciptOne = new double[] {1, -6, 100};

            //�������� ������ � �������� ���������
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsEmpty);
            Assert.IsNull
            (
                anObject: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2])
            );
        }

        [Test]
        public void Test_FullQuadraticEquation_One_Root()
        {
            //������ ���������
            double[] exciptOne = {1, 12, 36};
            double[] res1 = {-6};

            //�������� ������ � �������� ���������
            ResultFullQuadraticEquation actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsOne);
            CollectionAssert.AreEqual
            (
                expected: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]),
                actual: res1
            );

            //������ ���������
            exciptOne = new double[] {1, -6, 9};
            res1 = new double[] {3};

            //�������� ������ � �������� ���������
            actual = FullQuadraticEquation.FullQuadraticEquationReqcord
                (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]);

            Assert.IsTrue(condition: actual.IsOne);
            CollectionAssert.AreEqual
            (
                expected: FullQuadraticEquation.FullQuadraticEquationDoubleArray
                    (a: exciptOne[0], b: exciptOne[1], c: exciptOne[2]),
                actual: res1
            );
        }
    }
}