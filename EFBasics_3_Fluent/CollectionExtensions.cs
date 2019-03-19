using System.Collections.Generic;

namespace EFBasics_3_Fluent
{
    public static class CollectionExtensions
    {
        public static ICollection<T> AddRange<T>(this ICollection<T> @this, params T[] elements)
        {
            foreach (var element in elements)
            {
                @this.Add(element);
            }
            return @this;
        }
    }
}
