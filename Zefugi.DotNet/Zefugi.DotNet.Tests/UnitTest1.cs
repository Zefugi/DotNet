using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zefugi.DotNet.Optimization;

namespace Zefugi.DotNet.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            new MyTest().Run();
        }
    }

    class MyObj : PooledObjectBase<MyObj>
    {
        static int _idSpinner = 0;
        public int ID { get; internal set; }
        public MyObj()
        {
            if (++_idSpinner == int.MaxValue)
                _idSpinner = 1;
            ID = _idSpinner;
        }
    }

    class MyTest
    {
        public void Run()
        {
            var a = MyObj.CreateOrReuse();
            var aid = a.ID;
            var b = MyObj.CreateOrReuse();
            var bid = b.ID;
            a.Recycle();
            var c = MyObj.CreateOrReuse();
            var cid = c.ID;
            Assert.AreEqual(1, aid);
            Assert.AreEqual(2, bid);
            Assert.AreEqual(1, aid);
        }
    }
}
