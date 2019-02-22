# PooledObject

## Overview
This framework makes it easy to implement pooled objects. The object pool supports reusability as a better performing pattern than destroying and re-creating objects.

## Classes & Interfaces

### IPooledObject
This interface is nessesary for the PooledObjectBase to be generic.

### PooledObjectBase
An object inheriting this abstract class will have a Recycle method that will pool the object for re-initialization. The object pool is maintained automatically.

### ThreadsafePooledObjectBase
This is a thread-safe version of the PooledObjectBase.

## Example code:
```C#
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
```
#### Output:
```pseudocode
New object created.
A has ID 1
New object created.
B has ID 2
Reusing object that was once named 'A'.
C has ID 1
```