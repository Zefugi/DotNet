using System;
using System.Collections.Generic;

namespace Zefugi.DotNet.Optimization
{
    public abstract class ThreadsafePooledObjectBase<T> : IPooledObject
        where T : class, IPooledObject, new()
    {
        private static readonly Queue<IPooledObject> _pool = new Queue<IPooledObject>();

        public static T CreateOrReuse()
        {
            lock (_pool)
            {
                if (_pool.Count != 0)
                    return (T)_pool.Dequeue();
            }
            return new T();
        }

        public void Recycle()
        {
            lock(_pool)
                _pool.Enqueue(this);
        }
    }
}
