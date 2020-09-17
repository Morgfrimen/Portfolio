﻿using NUnit.Framework;
using QuadraticEquation;
using System;

namespace QuadraticEquationTest
{
    [TestFixture]
    public class TestIncompleteQuadraticEquation
    {
        [Test]
        public void Test_IncompleteQuadraticEquation_B_Zero()
        {
            double a = 2;
            double b = 0;
            double c = -32;

            var expected = new double[] { 4, -4 };

            var actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c),
                expected);

            a = 2;
            b = 0;
            c = 8;

            actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c);

            Assert.IsTrue(actual.IsEmpty);
            Assert.IsNull(IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c));
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_C_Zero()
        {
            double a = 3;
            double b = -12;
            double c = 0;

            var expected = new double[] { 0, 4 };

            var actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c),
                expected);
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_B_C_Zero()
        {
            double a = 7;
            double b = 0;
            double c = 0;

            var expected = new double[] { 0, 0 };

            var actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c),
                expected);
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_A_B_C_Zero()
        {
            double a = 0;
            double b = 0;
            double c = 0;

            var expected = new double[] { 0, 0 };

            var actual = IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c);

            Assert.IsTrue(actual.IsDoobleX);
            CollectionAssert.AreEqual(IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c),
                expected);
        }

        [Test]
        public void Test_IncompleteQuadraticEquation_A_B_C_Not_Zero()
        {
            double a = 1;
            double b = -8;
            double c = 12;

            var expected = new double[] { 0, 0 };

            Assert.Throws<Exception>(() => IncompleteQuadraticEquation.IncompleteQuadraticEquationReqcord(a, b, c));
            Assert.Throws<Exception>(() => IncompleteQuadraticEquation.IncompleteQuadraticEquationDoubleArray(a, b, c));
        }

    }
}