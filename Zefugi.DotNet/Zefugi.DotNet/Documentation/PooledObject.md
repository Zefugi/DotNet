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
class MyObj : PooledObjectBase {
	static int _idSpinner = 0;
	public int ID { get; internal set; }
	public MyObj() {
		if(++_idSpinner == int.MaxValue)
			_idSpinner = 1;
		ID = _idSpinner;
	}
}

class MyTest {
	public void Run() {
		var a = MyObj.CreateOrReuse();
		Debug.WriteLine("A has ID " + a.ID);
		var b = MyObj.CreateOrReuse();
		Debug.WriteLine("B has ID " + b.ID);
		a.Recycle();
		var c = MyObj.CreateOrReuse();
		Debug.WriteLine("C has ID " + c.ID);
	}
}

```
