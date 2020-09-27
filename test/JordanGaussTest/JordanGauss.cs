using System;
using NUnit.Framework;

namespace JordanGaussTest
{
    [TestFixture]
    public class JordanGauss
    {
        [Test]
        public void Test_FullJordanGauss()
        {
            //шаг 1
            double[,] except =
                {{0, 1, -2, 3}, {1, -2, 5.0 / 2, -13.0 / 2}, {0, 5, 17.0 / 2, -7.0 / 2}};
            Jordan_Gauss.Jordan_Gauss actual = Jordan_Gauss.StepMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss
                (
                    table: new double[,] {{4, -7, 8, -23}, {2, -4, 5, -13}, {-3, 11, 1, 16}},
                    resultTable: null
                ),
                indexRow: 1,
                indexColumn: 0
            );
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);

            //шаг 2
            except = new[,] {{0, 1, -2, 3}, {1, 0, -1.5D, -0.5D}, {0, 0, 18.5D, -18.5D}};
            actual = Jordan_Gauss.StepMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss
                    (table: actual.Table, resultTable: actual.ResultTable),
                indexRow: 0,
                indexColumn: 1
            );
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);

            //шаг 3
            except = new double[,] {{0, 1, 0, 1}, {1, 0, 0, -2}, {0, 0, 1, -1}};
            actual = Jordan_Gauss.StepMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss
                    (table: actual.Table, resultTable: actual.ResultTable),
                indexRow: 2,
                indexColumn: 2
            );
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);

            //Метод с подным расчетом
            except = new double[,] {{1, 0, 0, -2}, {0, 1, 0, 1}, {0, 0, 1, -1}};
            actual = Jordan_Gauss.RunMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss
                (
                    table: new double[,] {{4, -7, 8, -23}, {2, -4, 5, -13}, {-3, 11, 1, 16}},
                    resultTable: null
                )
            );
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);
        }

        [Test]
        public void Test_StepJordanGauss()
        {
            //Проверка запуска воозе шага метода
            double[,] except = new double[3, 4];
            Jordan_Gauss.Jordan_Gauss actual = Jordan_Gauss.StepMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss(table: new double[3, 4], resultTable: null),
                indexRow: 1,
                indexColumn: 0
            );
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));

            //Шаг метода
            except = new[,]
                {{0, 1, -2, 3}, {1, -2, 5.0 / 2, -13.0 / 2}, {0, 5, 17.0 / 2, -7.0 / 2}};
            actual = Jordan_Gauss.StepMethod
            (
                data: new Jordan_Gauss.Jordan_Gauss
                (
                    table: new double[,] {{4, -7, 8, -23}, {2, -4, 5, -13}, {-3, 11, 1, 16}},
                    resultTable: null
                ),
                indexRow: 1,
                indexColumn: 0
            );
            Console.WriteLine(value: Jordan_Gauss.PrintJordan_Gauss(data: actual));
            CollectionAssert.AreEqual(expected: except, actual: actual.ResultTable);
        }
    }
}