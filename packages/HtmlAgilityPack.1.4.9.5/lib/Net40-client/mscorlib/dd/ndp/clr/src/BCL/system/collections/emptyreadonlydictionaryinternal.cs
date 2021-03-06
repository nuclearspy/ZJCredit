﻿// Decompiled with JetBrains decompiler
// Type: System.Collections.EmptyReadOnlyDictionaryInternal
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Collections
{
  [Serializable]
  internal sealed class EmptyReadOnlyDictionaryInternal : IDictionary, ICollection, IEnumerable
  {
    public int Count
    {
      get
      {
        return 0;
      }
    }

    public object SyncRoot
    {
      get
      {
        return (object) this;
      }
    }

    public bool IsSynchronized
    {
      get
      {
        return false;
      }
    }

    public object this[object key]
    {
      get
      {
        if (key == null)
          throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
        return (object) null;
      }
      set
      {
        if (key == null)
          throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
        if (!key.GetType().IsSerializable)
          throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "key");
        if (value != null && !value.GetType().IsSerializable)
          throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "value");
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
      }
    }

    public ICollection Keys
    {
      get
      {
        return (ICollection) EmptyArray<object>.Value;
      }
    }

    public ICollection Values
    {
      get
      {
        return (ICollection) EmptyArray<object>.Value;
      }
    }

    public bool IsReadOnly
    {
      get
      {
        return true;
      }
    }

    public bool IsFixedSize
    {
      get
      {
        return true;
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) new EmptyReadOnlyDictionaryInternal.NodeEnumerator();
    }

    public void CopyTo(Array array, int index)
    {
      if (array == null)
        throw new ArgumentNullException("array");
      if (array.Rank != 1)
        throw new ArgumentException(Environment.GetResourceString("Arg_RankMultiDimNotSupported"));
      if (index < 0)
        throw new ArgumentOutOfRangeException("index", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
      if (array.Length - index < this.Count)
        throw new ArgumentException(Environment.GetResourceString("ArgumentOutOfRange_Index"), "index");
    }

    public bool Contains(object key)
    {
      return false;
    }

    public void Add(object key, object value)
    {
      if (key == null)
        throw new ArgumentNullException("key", Environment.GetResourceString("ArgumentNull_Key"));
      if (!key.GetType().IsSerializable)
        throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "key");
      if (value != null && !value.GetType().IsSerializable)
        throw new ArgumentException(Environment.GetResourceString("Argument_NotSerializable"), "value");
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
    }

    public void Clear()
    {
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
    }

    public IDictionaryEnumerator GetEnumerator()
    {
      return (IDictionaryEnumerator) new EmptyReadOnlyDictionaryInternal.NodeEnumerator();
    }

    public void Remove(object key)
    {
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
    }

    private sealed class NodeEnumerator : IDictionaryEnumerator, IEnumerator
    {
      public object Current
      {
        get
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
        }
      }

      public object Key
      {
        get
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
        }
      }

      public object Value
      {
        get
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
        }
      }

      public DictionaryEntry Entry
      {
        get
        {
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_EnumOpCantHappen"));
        }
      }

      public bool MoveNext()
      {
        return false;
      }

      public void Reset()
      {
      }
    }
  }
}
