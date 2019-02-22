using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zefugi.DotNet.Optimization;

namespace Zefugi.DotNet.Tests.Unit
{
    [TestClass]
    public class PooledObject
    {
        [TestMethod]
        public void TestMethod1()
        {
            new MyTest().Run();
        }
    }

    #region As seen in PooledObject.md
    class MyObj : PooledObjectBase<MyObj>
    {
        static int _idSpinner = 0;
        public int ID { get; internal set; }
        public string Name;
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
            MyObj obj, objToRecycle;

            objToRecycle = obj = MyObj.CreateOrReuse();
            Debug.WriteLine(obj.Name == null ? "New object created." : "Reusing object that was once named '" + obj.Name + "'.");
            obj.Name = "A";
            Debug.WriteLine(obj.Name + " has ID " + obj.ID);

            obj = MyObj.CreateOrReuse();
            Debug.WriteLine(obj.Name == null ? "New object created." : "Reusing object that was once named '" + obj.Name + "'.");
            obj.Name = "B";
            Debug.WriteLine(obj.Name + " has ID " + obj.ID);
            objToRecycle.Recycle();

            obj = MyObj.CreateOrReuse();
            Debug.WriteLine(obj.Name == null ? "New object created." : "Reusing object that was once named '" + obj.Name + "'.");
            obj.Name = "C";
            Debug.WriteLine(obj.Name + " has ID " + obj.ID);
        }
    }
    #endregion
}
