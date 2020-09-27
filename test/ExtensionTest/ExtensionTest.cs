using System;
using System.Collections.Generic;
using Extension;
using NUnit.Framework;

namespace ExtensionTest
{
    public sealed class ExtensionTest
    {
        [Test]
        public void Foreach_Test()
        {
            IList<int> list = new List<int>
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            IEnumerable<int> expected = new List<int>
                {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

            list.Foreach(action: SquareCollection);
            CollectionAssert.AreEqual(expected: expected, actual: list);
        }

        private int SquareCollection(int item)
        {
            Console.Write($"{item*item} ");
            return item * item;
        }
    }
}