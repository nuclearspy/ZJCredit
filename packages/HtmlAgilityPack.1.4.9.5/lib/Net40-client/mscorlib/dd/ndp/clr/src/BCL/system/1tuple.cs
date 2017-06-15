﻿// Decompiled with JetBrains decompiler
// Type: System.Tuple`1
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System
{
  /// <summary>表示 1 元组，即单一实例。</summary>
  /// <typeparam name="T1">元组的唯一一个分量的类型。</typeparam>
  /// <filterpriority>1</filterpriority>
  [__DynamicallyInvokable]
  [Serializable]
  public class Tuple<T1> : IStructuralEquatable, IStructuralComparable, IComparable, ITuple
  {
    private readonly T1 m_Item1;

    /// <summary>获取 <see cref="T:System.Tuple`1" /> 对象的单一分量的值。</summary>
    /// <returns>当前 <see cref="T:System.Tuple`1" /> 对象的单一分量的值。</returns>
    [__DynamicallyInvokable]
    public T1 Item1
    {
      [__DynamicallyInvokable] get
      {
        return this.m_Item1;
      }
    }

    int ITuple.Size
    {
      get
      {
        return 1;
      }
    }

    /// <summary>初始化 <see cref="T:System.Tuple`1" /> 类的新实例。</summary>
    /// <param name="item1">元组的唯一一个分量的值。</param>
    [__DynamicallyInvokable]
    public Tuple(T1 item1)
    {
      this.m_Item1 = item1;
    }

    /// <summary>返回一个值，该值指示当前的 <see cref="T:System.Tuple`1" /> 对象是否与指定对象相等。</summary>
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
      Tuple<T1> tuple = other as Tuple<T1>;
      if (tuple == null)
        return false;
      return comparer.Equals((object) this.m_Item1, (object) tuple.m_Item1);
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
      Tuple<T1> tuple = other as Tuple<T1>;
      if (tuple == null)
        throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleIncorrectType", (object) this.GetType().ToString()), "other");
      return comparer.Compare((object) this.m_Item1, (object) tuple.m_Item1);
    }

    /// <summary>返回当前 <see cref="T:System.Tuple`1" /> 对象的哈希代码。</summary>
    /// <returns>32 位有符号整数哈希代码。</returns>
    [__DynamicallyInvokable]
    public override int GetHashCode()
    {
      return ((IStructuralEquatable) this).GetHashCode((IEqualityComparer) EqualityComparer<object>.Default);
    }

    [__DynamicallyInvokable]
    int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
    {
      return comparer.GetHashCode((object) this.m_Item1);
    }

    int ITuple.GetHashCode(IEqualityComparer comparer)
    {
      return ((IStructuralEquatable) this).GetHashCode(comparer);
    }

    /// <summary>返回一个字符串，该字符串表示此 <see cref="T:System.Tuple`1" /> 实例的值。</summary>
    /// <returns>此 <see cref="T:System.Tuple`1" /> 对象的字符串表示形式。</returns>
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
      sb.Append(")");
      return sb.ToString();
    }
  }
}
