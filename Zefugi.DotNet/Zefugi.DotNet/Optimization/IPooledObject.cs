using System;
using System.Collections.Generic;

namespace Zefugi.DotNet.Optimization
{
    public interface IPooledObject
    {
        void Recycle();
    }
}
