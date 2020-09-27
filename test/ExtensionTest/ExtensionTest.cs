using System.Collections.Generic;
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
#region Type T input and outout

            IEnumerable<int> list = new List<int>
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            IEnumerable<int> expected = new List<int>
                {1, 4, 9, 16, 25, 36, 49, 64, 81, 100};

            CollectionAssert.AreEqual(expected: expected, actual: list.ToList().Foreach(action: res => res * res));

#endregion

#region Type T input, Type Q output

            IList<string> listStr = expected.ToList().Foreach(action: res => res.ToString()).ToList();

            IEnumerable<string> expectedStr = list.ToList().Foreach(action: res => (res * res).ToString());

            CollectionAssert.AreEqual(expected: expectedStr, actual: listStr);

#endregion
        }
    }
}