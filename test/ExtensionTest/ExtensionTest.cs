using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace ExtensionTest
{
    [TestFixture]
    public sealed class ExtensionTest
    {
        [Test]
        public void Foreach_Test()
        {
            Stopwatch stopwatch = new Stopwatch();

            IEnumerable<int> list = new List<int>
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            IEnumerable<int> expected = new List<int>
                {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};
            CollectionAssert.AreEqual(expected: expected, actual: list.ToList().Foreach(action: item => item * item));

            IEnumerable<string> listStr = list.Foreach(action: item => item.ToString());
            IEnumerable<string> expectedStr = list.Foreach(action: item => item.ToString());
            CollectionAssert.AreEqual(expected: expectedStr, actual: listStr);

            stopwatch.Start();
            IEnumerable<int> test = list.Foreach(action: item => item * item);
            CollectionAssert.AreEqual(expected: expected, actual: test);
            stopwatch.Stop();

            TimeSpan extension = stopwatch.Elapsed;
            stopwatch.Reset();

            stopwatch.Start();
            test = list.Select(selector: item => item * item);
            CollectionAssert.AreEqual(expected: expected, actual: test);
            stopwatch.Stop();

            TimeSpan linqSelect = stopwatch.Elapsed;
            stopwatch.Reset();

            string res = extension <= linqSelect ? "��" : "���";
            Console.WriteLine
                (value: $"����� �� ����� Extension �� LINQ Select? {res}{Environment.NewLine}����� Extension.Foreach = {extension} ; ����� LINQ.Select = {linqSelect}");

            stopwatch.Start();
            Assert.DoesNotThrow(code: () => listStr.ToList().ForEach(action: item => Console.Write(value: string.Empty)));
            stopwatch.Stop();

            TimeSpan forEach = stopwatch.Elapsed;
            stopwatch.Reset();

            stopwatch.Start();
            Assert.DoesNotThrow(code: () => listStr.Foreach(action: item => Console.Write(value: string.Empty)));
            stopwatch.Stop();

            Console.Write(value: Environment.NewLine);
            res = stopwatch.Elapsed <= forEach ? "��" : "���";
            Console.WriteLine(value: $"����� �� � ������ Action ��� ����� ����������? {res}{Environment.NewLine}����� List.ForEach : {forEach} ; Extension.Foreach : {stopwatch.Elapsed} ");
            stopwatch.Reset();
        }
    }
}