﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Extension
{
    /// <summary>
    ///     Класс расширений для удобства работы
    /// </summary>
    public static class Extension
    {
        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="T">TInput</typeparam>
        /// <typeparam name="TQ">TOutput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TQ> Foreach<T, TQ>(this IList<T> enumerable, Func<T, TQ> action)
        {
            IList<TQ> newList = new List<TQ>();
            for (int index = 0; index < enumerable.Count; index++)
                newList.Add(item: action.Invoke(arg: enumerable[index: index]));

            return newList;
        }

        /// <summary>
        ///     Перебирает коллекцию IEnumerable и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="T">TInput</typeparam>
        /// <typeparam name="TQ">TOutput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<TQ> Foreach<T, TQ>(this IEnumerable<T> enumerable, Func<T, TQ> action)
        {
            return enumerable.ToList().Foreach(action: action);
        }

        /// <summary>
        ///     Перебирает коллекцию IList и применяет к каждому элементу делегат Func
        /// </summary>
        /// <typeparam name="T">TInput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<T> Foreach<T>(this IList<T> enumerable, Action<T> action)
        {
            for (int index = 0; index < enumerable.Count; index++)
                action.Invoke(obj: enumerable[index: index]);

            return enumerable;
        }

        /// <summary>
        ///     Перебирает коллекцию IEnumerable и применяет к каждому элементу делегат Action
        /// </summary>
        /// <typeparam name="T">TInput</typeparam>
        /// <param name="enumerable">Коллекция</param>
        /// <param name="action">Действие, которое нужно сделать с каждым элементом коллекции</param>
        /// <returns>Преобразованную коллекцию</returns>
        public static IEnumerable<T> Foreach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            return enumerable.ToList().Foreach(action: action);
        }
    }
}