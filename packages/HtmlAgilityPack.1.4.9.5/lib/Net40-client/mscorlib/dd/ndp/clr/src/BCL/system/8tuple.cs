﻿// Decompiled with JetBrains decompiler
// Type: System.Tuple`8
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
  /// <summary>表示 n 元组，其中 n 为 8 或更大。</summary>
  /// <typeparam name="T1">此元组的第一个组件的类型。</typeparam>
  /// <typeparam name="T2">此元组的第二个组件的类型。</typeparam>
  /// <typeparam name="T3">此元组的第三个组件的类型。</typeparam>
  /// <typeparam name="T4">此元组的第四个组件的类型。</typeparam>
  /// <typeparam name="T5">元组的第五个分量的类型。</typeparam>
  /// <typeparam name="T6">元组的第六个分量的类型。</typeparam>
  /// <typeparam name="T7">元组的第七个分量的类型。</typeparam>
  /// <typeparam name="TRest">任何常规 Tuple 对象，用于定义元组的剩余分量的类型。</typeparam>
  /// <filterpriority>2</filterpriority>
  [__DynamicallyInvokable]
  [Serializable]
  public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
  {
    private readonly T1 m_Item1;
    private readonly T2 m_Item2;
    private readonly T3 m_Item3;
    private readonly T4 m_Item4;
    private readonly T5 m_Item5;
    private readonly T6 m_Item6;
    private readonly T7 m_Item7;
    private readonly TRest m_Rest;

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第一个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第一个分量的值。</returns>
    [__DynamicallyInvokable]
    public T1 Item1
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item1;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第二个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第二个分量的值。</returns>
    [__DynamicallyInvokable]
    public T2 Item2
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item2;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第三个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第三个分量的值。</returns>
    [__DynamicallyInvokable]
    public T3 Item3
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item3;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第四个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第四个分量的值。</returns>
    [__DynamicallyInvokable]
    public T4 Item4
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item4;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第五个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第五个分量的值。</returns>
    [__DynamicallyInvokable]
    public T5 Item5
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item5;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第六个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第六个分量的值。</returns>
    [__DynamicallyInvokable]
    public T6 Item6
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item6;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的第七个分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的第七个分量的值。</returns>
    [__DynamicallyInvokable]
    public T7 Item7
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item7;
      }
    }

    /// <summary>获取当前 <see cref="T:System.Tuple`8" /> 对象的剩余分量。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`8" /> 对象的剩余分量的值。</returns>
    [__DynamicallyInvokable]
    public TRest Rest
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Rest;
      }
    }

    int ITuple.Size
    {
      get
      {
        return 7 + ((ITuple) (object) this.m_Rest).Size;
      }
    }

    /// <summary>初始化 <see cref="T:System.Tuple`8" /> 类的新实例。</summary>
    /// <param name="item1">此元组的第一个组件的值。</param>
    /// <param name="item2">此元组的第二个组件的值。</param>
    /// <param name="item3">此元组的第三个组件的值。</param>
    /// <param name="item4">此元组的第四个组件的值</param>
    /// <param name="item5">元组的第五个分量的值。</param>
    /// <param name="item6">元组的第六个分量的值。</param>
    /// <param name="item7">元组的第七个分量的值。</param>
    /// <param name="rest">任何常规 Tuple 对象，其中包含元组的剩余分量的值。</param>
    /// <exception cref="T:System.ArgumentException">
    /// <paramref name="rest" /> 不是泛型 Tuple 对象。</exception>
    [__DynamicallyInvokable]
    public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
    {
      if (!((object) rest is ITuple))
        throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleLastArgumentNotATuple"));
      this.m_Item1 = item1;
      this.m_Item2 = item2;
      this.m_Item3 = item3;
      this.m_Item4 = item4;
      this.m_Item5 = item5;
      this.m_Item6 = item6;
      this.m_Item7 = item7;
      this.m_Rest = rest;
    }

    /// <summary>返回一个值，该值指示当前的 <see cref="T:System.Tuple`8" /> 对象是否与指定对象相等。</summary>
    /// <returns>如果当前实例等于指定对象，则为 true；否则为 false。</returns>
    /// <param name="obj">与该实例进行比较的对象。</param>
    [__DynamicallyInvokable]
    public override bool Equals(object obj)
    {
      return ((IStructuralEquatable) this).Equals(obj, (IEqualityComparer) EqualityComparer<object>.Default);
    }

    [__DynamicallyInvokable]
    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
      if (other == null)
        return false;
      Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
      if (tuple == null || !comparer.Equals((object) this.m_Item1, (object) tuple.m_Item1) || (!comparer.Equals((object) this.m_Item2, (object) tuple.m_Item2) || !comparer.Equals((object) this.m_Item3, (object) tuple.m_Item3)) || (!comparer.Equals((object) this.m_Item4, (object) tuple.m_Item4) || !comparer.Equals((object) this.m_Item5, (object) tuple.m_Item5) || (!comparer.Equals((object) this.m_Item6, (object) tuple.m_Item6) || !comparer.Equals((object) this.m_Item7, (object) tuple.m_Item7))))
        return false;
      return comparer.Equals((object) this.m_Rest, (object) tuple.m_Rest);
    }

    [__DynamicallyInvokable]
    int IComparable.CompareTo(object obj)
    {
      return ((IStructuralComparable) this).CompareTo(obj, (IComparer) Comparer<object>.Default);
    }

    [__DynamicallyInvokable]
    int IStructuralComparable.CompareTo(object other, IComparer comparer)
    {
      if (other == null)
        return 1;
      Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
      if (tuple == null)
        throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleIncorrectType", (object) this.GetType().ToString()), "other");
      int num1 = comparer.Compare((object) this.m_Item1, (object) tuple.m_Item1);
      if (num1 != 0)
        return num1;
      int num2 = comparer.Compare((object) this.m_Item2, (object) tuple.m_Item2);
      if (num2 != 0)
        return num2;
      int num3 = comparer.Compare((object) this.m_Item3, (object) tuple.m_Item3);
      if (num3 != 0)
        return num3;
      int num4 = comparer.Compare((object) this.m_Item4, (object) tuple.m_Item4);
      if (num4 != 0)
        return num4;
      int num5 = comparer.Compare((object) this.m_Item5, (object) tuple.m_Item5);
      if (num5 != 0)
        return num5;
      int num6 = comparer.Compare((object) this.m_Item6, (object) tuple.m_Item6);
      if (num6 != 0)
        return num6;
      int num7 = comparer.Compare((object) this.m_Item7, (object) tuple.m_Item7);
      if (num7 != 0)
        return num7;
      return comparer.Compare((object) this.m_Rest, (object) tuple.m_Rest);
    }

    /// <summary>计算当前 <see cref="T:System.Tuple`8" /> 对象的哈希代码。</summary>
    /// <returns>32 位有符号整数哈希代码。</returns>
    [__DynamicallyInvokable]
    public override int GetHashCode()
    {
      return ((IStructuralEquatable) this).GetHashCode((IEqualityComparer) EqualityComparer<object>.Default);
    }

    [__DynamicallyInvokable]
    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      ITuple tuple = (ITuple) (object) this.m_Rest;
      if (tuple.Size >= 8)
        return tuple.GetHashCode(comparer);
      switch (8 - tuple.Size)
      {
        case 1:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 2:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 3:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item5), comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 4:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item4), comparer.GetHashCode((object) this.m_Item5), comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 5:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item3), comparer.GetHashCode((object) this.m_Item4), comparer.GetHashCode((object) this.m_Item5), comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 6:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item2), comparer.GetHashCode((object) this.m_Item3), comparer.GetHashCode((object) this.m_Item4), comparer.GetHashCode((object) this.m_Item5), comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        case 7:
          return Tuple.CombineHashCodes(comparer.GetHashCode((object) this.m_Item1), comparer.GetHashCode((object) this.m_Item2), comparer.GetHashCode((object) this.m_Item3), comparer.GetHashCode((object) this.m_Item4), comparer.GetHashCode((object) this.m_Item5), comparer.GetHashCode((object) this.m_Item6), comparer.GetHashCode((object) this.m_Item7), tuple.GetHashCode(comparer));
        default:
          return -1;
      }
    }

    int ITuple.GetHashCode(IEqualityComparer comparer)
    {
      return ((IStructuralEquatable) this).GetHashCode(comparer);
    }

    /// <summary>返回一个字符串，该字符串表示此 <see cref="T:System.Tuple`8" /> 实例的值。</summary>
    /// <returns>此 <see cref="T:System.Tuple`8" /> 对象的字符串表示形式。</returns>
    [__DynamicallyInvokable]
    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("(");
      return ((ITuple) this).ToString(sb);
    }

    string ITuple.ToString(StringBuilder sb)
    {
      sb.Append((object) this.m_Item1);
      sb.Append(", ");
      sb.Append((object) this.m_Item2);
      sb.Append(", ");
      sb.Append((object) this.m_Item3);
      sb.Append(", ");
      sb.Append((object) this.m_Item4);
      sb.Append(", ");
      sb.Append((object) this.m_Item5);
      sb.Append(", ");
      sb.Append((object) this.m_Item6);
      sb.Append(", ");
      sb.Append((object) this.m_Item7);
      sb.Append(", ");
      return ((ITuple) (object) this.m_Rest).ToString(sb);
    }
  }
}
