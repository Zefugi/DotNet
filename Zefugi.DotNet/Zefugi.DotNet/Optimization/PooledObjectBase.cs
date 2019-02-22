using System;
using System.Collections.Generic;

namespace Zefugi.DotNet.Optimization
{
    public abstract class PooledObjectBase<T> : IPooledObject
        where T : class, IPooledObject, new()
    {
        private static readonly Queue<IPooledObject> _pool = new Queue<IPooledObject>();

        public static T CreateOrReuse()
        {
            if (_pool.Count != 0)
                return (T)_pool.Dequeue();
            else
                return new T();
        }

        public void Recycle()
        {
            _pool.Enqueue(this);
        }
    }
}
