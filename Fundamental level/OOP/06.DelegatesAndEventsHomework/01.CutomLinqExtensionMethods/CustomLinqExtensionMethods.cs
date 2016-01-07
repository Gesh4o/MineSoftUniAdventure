namespace _01.CutomLinqExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CustomLinqExtensionMethods 
    {
        // WhereNot extension
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            List<T> newList = new List<T>();
            foreach (var element in collection)
            {
                if (!condition(element))
                {
                    newList.Add(element);
                }
            }

            return newList;
        }

        // Max extension
        public static TSelector Max<TSource,TSelector>(this IEnumerable<TSource> collection ,Func<TSource,TSelector> getElement)
            where TSelector: IComparable
        {
            List<TSelector> allElements = new List<TSelector>();
            foreach (var source in collection)
            {
                TSelector newElement = getElement(source);
                allElements.Add(newElement);
            }

            TSelector maxValue = allElements[0];
            for (int i = 1; i < allElements.Count; i++)
            {
                if (maxValue.CompareTo(allElements[i])<0)
                {
                    maxValue = allElements[i];
                }
            }

            return maxValue;
        }
    }

}
