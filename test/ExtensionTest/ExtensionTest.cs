using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extension;
using NUnit.Framework;

namespace ExtensionTest
{
    public sealed class ExtensionTest
    {
        [Test]
        public void Foreach_Test()
        {
            Stopwatch stopwatch = new Stopwatch();

            TimeSpan[] exsensionTimeSpans = new TimeSpan[2];
            TimeSpan[] liqnSelec = new TimeSpan[2];

#region Type T input and outout

            stopwatch.Start();
            IEnumerable<int> list = new List<int>
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            IEnumerable<int> expected = new List<int>
                {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

            CollectionAssert.AreEqual(expected: expected, actual: list.ToList().Foreach(action: res => res * res));
            stopwatch.Stop();
            exsensionTimeSpans[0] = stopwatch.Elapsed;
            Console.WriteLine(value: $"Время работы {typeof(Extension.Extension)} с одним и тем же типом входа и выхода: {stopwatch.Elapsed}");
            stopwatch.Reset();

#endregion

#region Type T input, Type Q output

            stopwatch.Start();
            IList<string> listStr = expected.ToList().Foreach(action: res => res.ToString()).ToList();

            IEnumerable<string> expectedStr = list.ToList().Foreach(action: res => (res * res).ToString());

            CollectionAssert.AreEqual(expected: expectedStr, actual: listStr);
            stopwatch.Stop();

            exsensionTimeSpans[1] = stopwatch.Elapsed;
            Console.WriteLine(value: $"Время работы {typeof(Extension.Extension)} с разным типом входа и выхода: {stopwatch.Elapsed}");
            stopwatch.Reset();

#endregion

#region LINQ

            stopwatch.Start();
            IEnumerable<int> test = list.Select(selector: item => item * item);
            CollectionAssert.AreEqual(expected: expected, actual: test);
            stopwatch.Stop();
            liqnSelec[0] = stopwatch.Elapsed;
            Console.WriteLine(value: $"Время работы LINQ.SELECT с одним и тем же типом входа и выхода: {stopwatch.Elapsed}");
            stopwatch.Reset();

            stopwatch.Start();
            IEnumerable<string> testStr = list.Select(selector: item => (item * item).ToString());
            CollectionAssert.AreEqual(expected: expectedStr, actual: testStr);
            stopwatch.Stop();
            liqnSelec[1] = stopwatch.Elapsed;
            Console.WriteLine(value: $"Время работы LINQ.SELECT с разным типом входа и выхода: {stopwatch.Elapsed}");
            stopwatch.Reset();

#endregion

            for (int index = 0; index < 2; index++)
            {
                string res = exsensionTimeSpans[index] <= liqnSelec[index] ? "Да" : "Нет";
                Console.WriteLine($"Лучше ли метод Extension от LINQ Select? {res}");
            }


            Assert.DoesNotThrow(code: () => expected.Select(selector: item => item.ToString()).ToList().ForEach(action: res => Console.Write(value: $"{res} ")));
        }
    }
}