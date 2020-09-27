using System.Collections.Generic;

namespace Extension
{
    /// <summary>
    ///     Класс расширений для удобства работы
    /// </summary>
    public static class Extension
    {
        public delegate Q ExtensionDelegateOutQ<T, Q>(T obj);

        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат ExtensionDelegateOutQ
        /// </summary>
        /// <typeparam name="T">TInput</typeparam>
        /// <typeparam name="Q">TOutput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<Q> Foreach<T, Q>(this IList<T> enumerable, ExtensionDelegateOutQ<T, Q> action)
        {
            IList<Q> newList = new List<Q>();
            for (int index = 0; index < enumerable.Count; index++)
                newList.Add(item: action.Invoke(obj: enumerable[index: index]));

            return newList;
        }
    }
}