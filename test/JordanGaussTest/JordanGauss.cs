using NUnit.Framework;
using System;

namespace JordanGaussTest
{
    public class JordanGauss
    {
        [Test]
        public void Test_StepJordanGauss()
        {
            //Проверка запуска воозе шага метода
            double[,] except = new double[3, 4];
            Jordan_Gauss.Jordan_Gauss actual = Jordan_Gauss.StepMethod(new Jordan_Gauss.Jordan_Gauss(new double[3, 4], null), 1, 0);
            CollectionAssert.AreEqual(except, actual.ResultTable);
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));

            //Шаг метода
            except = new double[,] { { 0, 1, -2, 3 }, { 1, -2, 5.0 / 2, -13.0 / 2 }, { 0, 5, 17.0 / 2, -7.0 / 2 } };
            actual = Jordan_Gauss.StepMethod(new Jordan_Gauss.Jordan_Gauss(new double[,] { { 4, -7, 8, -23 }, { 2, -4, 5, -13 }, { -3, 11, 1, 16 } }, null), 1, 0);
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));
            CollectionAssert.AreEqual(except, actual.ResultTable);
        }

        [Test]
        public void Test_FullJordanGauss()
        {
            //шаг 1
            var except = new double[,] { { 0, 1, -2, 3 }, { 1, -2, 5.0 / 2, -13.0 / 2 }, { 0, 5, 17.0 / 2, -7.0 / 2 } };
            var actual = Jordan_Gauss.StepMethod(new Jordan_Gauss.Jordan_Gauss(new double[,] { { 4, -7, 8, -23 }, { 2, -4, 5, -13 }, { -3, 11, 1, 16 } }, null), 1, 0);
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));
            CollectionAssert.AreEqual(except, actual.ResultTable);

            //шаг 2
            except = new double[,] { { 0, 1, -2, 3 }, { 1, 0, -1.5D, -0.5D }, { 0, 0, 18.5D, -18.5D } };
            actual = Jordan_Gauss.StepMethod(new Jordan_Gauss.Jordan_Gauss(actual.Table, actual.ResultTable), 0, 1);
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));
            CollectionAssert.AreEqual(except, actual.ResultTable);

            //шаг 3
            except = new double[,] { { 0, 1, 0, 1 }, { 1, 0, 0, -2 }, { 0, 0, 1, -1 } };
            actual = Jordan_Gauss.StepMethod(new Jordan_Gauss.Jordan_Gauss(actual.Table, actual.ResultTable), 2, 2);
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));
            CollectionAssert.AreEqual(except, actual.ResultTable);

            //Метод с подным расчетом
            except = new double[,] { { 1, 0, 0, -2 }, { 0, 1, 0, 1 }, { 0, 0, 1, -1 } };
            actual = Jordan_Gauss.RunMethod(
                new Jordan_Gauss.Jordan_Gauss(new double[,] { { 4, -7, 8, -23 }, { 2, -4, 5, -13 }, { -3, 11, 1, 16 } }, null));
            Console.WriteLine(Jordan_Gauss.PrintJordan_Gauss(actual));
            CollectionAssert.AreEqual(except, actual.ResultTable);
        }
    }
}