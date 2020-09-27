using System;
using NUnit.Framework;
using QuadraticEquation;

namespace QuadraticEquationTest
{
    [TestFixture]
    public class TestIncompleteQuadraticEquation
    {
        [Test]
        public void Test_IncompleteQuadraticEquation_A_B_C_Not_Zero()
        {
            double a = 1;
            double b = -8;
            double c = 12;

            double[] expected = {0, 0};

            Assert.Throws<Exception>
            (
                code: () => IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord
                    (a: a, b: b, c: c)
            );
            Assert.Throws<Exception>
            (
                code: () => IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c)
            );
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_A_B_C_Zero()
        {
            double a = 0;
            double b = 0;
            double c = 0;

            double[] expected = {0, 0};

            ResultFullQuadraticEquation actual =
                IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a: a, b: b, c: c);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c),
                actual: expected
            );
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_B_C_Zero()
        {
            double a = 7;
            double b = 0;
            double c = 0;

            double[] expected = {0, 0};

            ResultFullQuadraticEquation actual =
                IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a: a, b: b, c: c);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c),
                actual: expected
            );
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_B_Zero()
        {
            double a = 2;
            double b = 0;
            double c = -32;

            double[] expected = {4, -4};

            ResultFullQuadraticEquation actual =
                IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a: a, b: b, c: c);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c),
                actual: expected
            );

            a = 2;
            b = 0;
            c = 8;

            actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord
                (a: a, b: b, c: c);

            Assert.IsTrue(condition: actual.IsEmpty);
            Assert.IsNull
            (
                anObject: IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c)
            );
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_C_Zero()
        {
            double a = 3;
            double b = -12;
            double c = 0;

            double[] expected = {0, 4};

            ResultFullQuadraticEquation actual =
                IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a: a, b: b, c: c);

            Assert.IsTrue(condition: actual.IsDoobleX);
            CollectionAssert.AreEqual
            (
                expected: IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray
                    (a: a, b: b, c: c),
                actual: expected
            );
        }
    }
}