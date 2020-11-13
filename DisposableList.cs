using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageGridCreator
{
    public sealed class DisposableList<T> : List<T>, IDisposable where T : IDisposable
    {
        public DisposableList() : base() { }
        public DisposableList(IEnumerable<T> list) : base(list) { }

        public void Dispose()
        {
            foreach (var item in this)
            {
                item.Dispose();
            }
        }
    }

    public static class IEnumerableExtensions
    {
        public static DisposableList<T> ToDisposableList<T>(this IEnumerable<T> list) where T : IDisposable
            => new DisposableList<T>(list);
    }
}
