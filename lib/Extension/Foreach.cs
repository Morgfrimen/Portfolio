using System.Collections.Generic;

namespace System.Linq
{
    public static class Enumerable
    {
        private static readonly string _tag = nameof(Exception);

        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="TInput">TInput</typeparam>
        /// <typeparam name="TOutput">TOutput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TOutput> Foreach<TInput, TOutput>(this IList<TInput> enumerable, Func<TInput, TOutput> action)
        {
            EnumerableIsNull(enumerable: enumerable);

            IList<TOutput> newList = new List<TOutput>();
            for (int index = 0; index < enumerable.Count; index++)
                newList.Add(item: action.Invoke(arg: enumerable[index: index]));

            return newList;
        }

        /// <summary>
        ///     Перебирает коллекцию IEnumerable и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="TInput">TInput</typeparam>
        /// <typeparam name="TOutput">TOutput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TOutput> Foreach<TInput, TOutput>(this IEnumerable<TInput> enumerable, Func<TInput, TOutput> action)
        {
            return enumerable.ToList().Foreach(action: action);
        }

        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="TInput">TInput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TInput> Foreach<TInput>(this IList<TInput> enumerable, Action<TInput> action)
        {
            EnumerableIsNull(enumerable: enumerable);

            for (int index = 0; index < enumerable.Count; index++)
                action.Invoke(obj: enumerable[index: index]);

            return enumerable;
        }

        /// <summary>
        ///     Перебирает коллекцию IEnumerable и применяет к каждому элементу делегат Action
        /// </summary>
        /// <typeparam name="TInput">TInput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TInput> Foreach<TInput>(this IEnumerable<TInput> enumerable, Action<TInput> action)
        {
            return enumerable.ToList().Foreach(action: action);
        }

        private static void EnumerableIsNull<TInput>(IEnumerable<TInput> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(paramName: $"{_tag}:{nameof(Foreach)} -> enumerable is NULL");
        }
    }
}