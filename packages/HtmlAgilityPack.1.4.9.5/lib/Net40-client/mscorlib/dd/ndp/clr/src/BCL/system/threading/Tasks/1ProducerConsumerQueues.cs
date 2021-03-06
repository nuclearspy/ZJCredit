﻿// Decompiled with JetBrains decompiler
// Type: System.Threading.Tasks.SingleProducerSingleConsumerQueue`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Threading.Tasks
{
  [DebuggerDisplay("Count = {Count}")]
  [DebuggerTypeProxy(typeof (SingleProducerSingleConsumerQueue<>.SingleProducerSingleConsumerQueue_DebugView))]
  internal sealed class SingleProducerSingleConsumerQueue<T> : IProducerConsumerQueue<T>, IEnumerable<T>, IEnumerable
  {
    private const int INIT_SEGMENT_SIZE = 32;
    private const int MAX_SEGMENT_SIZE = 16777216;
    private volatile SingleProducerSingleConsumerQueue<T>.Segment m_head;
    private volatile SingleProducerSingleConsumerQueue<T>.Segment m_tail;

    public bool IsEmpty
    {
      get
      {
        SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head;
        if (segment.m_state.m_first != segment.m_state.m_lastCopy || segment.m_state.m_first != segment.m_state.m_last)
          return false;
        return segment.m_next == null;
      }
    }

    public int Count
    {
      get
      {
        int num1 = 0;
        for (SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head; segment != null; segment = segment.m_next)
        {
          int length = segment.m_array.Length;
          int num2;
          int num3;
          do
          {
            num2 = segment.m_state.m_first;
            num3 = segment.m_state.m_last;
          }
          while (num2 != segment.m_state.m_first);
          num1 += num3 - num2 & length - 1;
        }
        return num1;
      }
    }

    internal SingleProducerSingleConsumerQueue()
    {
      this.m_head = this.m_tail = new SingleProducerSingleConsumerQueue<T>.Segment(32);
    }

    public void Enqueue(T item)
    {
      SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_tail;
      T[] objArray = segment.m_array;
      int index = segment.m_state.m_last;
      int num = index + 1 & objArray.Length - 1;
      if (num != segment.m_state.m_firstCopy)
      {
        objArray[index] = item;
        segment.m_state.m_last = num;
      }
      else
        this.EnqueueSlow(item, ref segment);
    }

    private void EnqueueSlow(T item, ref SingleProducerSingleConsumerQueue<T>.Segment segment)
    {
      if (segment.m_state.m_firstCopy != segment.m_state.m_first)
      {
        segment.m_state.m_firstCopy = segment.m_state.m_first;
        this.Enqueue(item);
      }
      else
      {
        int size = this.m_tail.m_array.Length << 1;
        if (size > 16777216)
          size = 16777216;
        SingleProducerSingleConsumerQueue<T>.Segment segment1 = new SingleProducerSingleConsumerQueue<T>.Segment(size);
        segment1.m_array[0] = item;
        segment1.m_state.m_last = 1;
        segment1.m_state.m_lastCopy = 1;
        try
        {
        }
        finally
        {
          Volatile.Write<SingleProducerSingleConsumerQueue<T>.Segment>(ref this.m_tail.m_next, segment1);
          this.m_tail = segment1;
        }
      }
    }

    public bool TryDequeue(out T result)
    {
      SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head;
      T[] array = segment.m_array;
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_lastCopy)
        return this.TryDequeueSlow(ref segment, ref array, out result);
      result = array[index];
      array[index] = default (T);
      segment.m_state.m_first = index + 1 & array.Length - 1;
      return true;
    }

    private bool TryDequeueSlow(ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
    {
      if (segment.m_state.m_last != segment.m_state.m_lastCopy)
      {
        segment.m_state.m_lastCopy = segment.m_state.m_last;
        return this.TryDequeue(out result);
      }
      if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
      {
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        SingleProducerSingleConsumerQueue<T>.Segment& local = @segment;
        // ISSUE: explicit reference operation
        SingleProducerSingleConsumerQueue<T>.Segment segment1 = (^local).m_next;
        // ISSUE: explicit reference operation
        ^local = segment1;
        array = segment.m_array;
        this.m_head = segment;
      }
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_last)
      {
        result = default (T);
        return false;
      }
      result = array[index];
      array[index] = default (T);
      segment.m_state.m_first = index + 1 & segment.m_array.Length - 1;
      segment.m_state.m_lastCopy = segment.m_state.m_last;
      return true;
    }

    public bool TryPeek(out T result)
    {
      SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head;
      T[] array = segment.m_array;
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_lastCopy)
        return this.TryPeekSlow(ref segment, ref array, out result);
      result = array[index];
      return true;
    }

    private bool TryPeekSlow(ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
    {
      if (segment.m_state.m_last != segment.m_state.m_lastCopy)
      {
        segment.m_state.m_lastCopy = segment.m_state.m_last;
        return this.TryPeek(out result);
      }
      if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
      {
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        SingleProducerSingleConsumerQueue<T>.Segment& local = @segment;
        // ISSUE: explicit reference operation
        SingleProducerSingleConsumerQueue<T>.Segment segment1 = (^local).m_next;
        // ISSUE: explicit reference operation
        ^local = segment1;
        array = segment.m_array;
        this.m_head = segment;
      }
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_last)
      {
        result = default (T);
        return false;
      }
      result = array[index];
      return true;
    }

    public bool TryDequeueIf(Predicate<T> predicate, out T result)
    {
      SingleProducerSingleConsumerQueue<T>.Segment segment = this.m_head;
      T[] array = segment.m_array;
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_lastCopy)
        return this.TryDequeueIfSlow(predicate, ref segment, ref array, out result);
      result = array[index];
      if (predicate == null || predicate(result))
      {
        array[index] = default (T);
        segment.m_state.m_first = index + 1 & array.Length - 1;
        return true;
      }
      result = default (T);
      return false;
    }

    private bool TryDequeueIfSlow(Predicate<T> predicate, ref SingleProducerSingleConsumerQueue<T>.Segment segment, ref T[] array, out T result)
    {
      if (segment.m_state.m_last != segment.m_state.m_lastCopy)
      {
        segment.m_state.m_lastCopy = segment.m_state.m_last;
        return this.TryDequeueIf(predicate, out result);
      }
      if (segment.m_next != null && segment.m_state.m_first == segment.m_state.m_last)
      {
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        SingleProducerSingleConsumerQueue<T>.Segment& local = @segment;
        // ISSUE: explicit reference operation
        SingleProducerSingleConsumerQueue<T>.Segment segment1 = (^local).m_next;
        // ISSUE: explicit reference operation
        ^local = segment1;
        array = segment.m_array;
        this.m_head = segment;
      }
      int index = segment.m_state.m_first;
      if (index == segment.m_state.m_last)
      {
        result = default (T);
        return false;
      }
      result = array[index];
      if (predicate == null || predicate(result))
      {
        array[index] = default (T);
        segment.m_state.m_first = index + 1 & segment.m_array.Length - 1;
        segment.m_state.m_lastCopy = segment.m_state.m_last;
        return true;
      }
      result = default (T);
      return false;
    }

    public void Clear()
    {
      T result;
      do
        ;
      while (this.TryDequeue(out result));
    }

    public IEnumerator<T> GetEnumerator()
    {
      SingleProducerSingleConsumerQueue<T>.Segment segment;
      for (segment = this.m_head; segment != null; segment = segment.m_next)
      {
        for (int pt = segment.m_state.m_first; pt != segment.m_state.m_last; pt = pt + 1 & segment.m_array.Length - 1)
          yield return segment.m_array[pt];
      }
      segment = (SingleProducerSingleConsumerQueue<T>.Segment) null;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }

    int IProducerConsumerQueue<T>.GetCountSafe(object syncObj)
    {
      lock (syncObj)
        return this.Count;
    }

    [StructLayout(LayoutKind.Sequential)]
    private sealed class Segment
    {
      internal SingleProducerSingleConsumerQueue<T>.Segment m_next;
      internal readonly T[] m_array;
      internal SingleProducerSingleConsumerQueue<T>.SegmentState m_state;

      internal Segment(int size)
      {
        this.m_array = new T[size];
      }
    }

    private struct SegmentState
    {
      internal PaddingFor32 m_pad0;
      internal volatile int m_first;
      internal int m_lastCopy;
      internal PaddingFor32 m_pad1;
      internal int m_firstCopy;
      internal volatile int m_last;
      internal PaddingFor32 m_pad2;
    }

    private sealed class SingleProducerSingleConsumerQueue_DebugView
    {
      private readonly SingleProducerSingleConsumerQueue<T> m_queue;

      [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
      public T[] Items
      {
        get
        {
          List<T> objList = new List<T>();
          foreach (T m in this.m_queue)
            objList.Add(m);
          return objList.ToArray();
        }
      }

      public SingleProducerSingleConsumerQueue_DebugView(SingleProducerSingleConsumerQueue<T> queue)
      {
        this.m_queue = queue;
      }
    }
  }
}
