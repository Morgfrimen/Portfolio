using System.Collections.Generic;

namespace Extension
{
    /// <summary>
    ///     Класс расширений для удобства работы
    /// </summary>
    public static class Extension
    {
        public delegate T ExtensionDelegate<T>(T obj);

        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат ExtensionDelegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<T> Foreach<T>(this IList<T> enumerable, ExtensionDelegate<T> action)
        {
            for (int index = 0; index < enumerable.Count; index++)
                enumerable[index: index] = action.Invoke(obj: enumerable[index: index]);

            return enumerable;
        }
    }
}