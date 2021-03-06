﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.WindowsRuntime.IReadOnlyDictionaryToIMapViewAdapter
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices.WindowsRuntime
{
  [DebuggerDisplay("Size = {Size}")]
  internal sealed class IReadOnlyDictionaryToIMapViewAdapter
  {
    private IReadOnlyDictionaryToIMapViewAdapter()
    {
    }

    [SecurityCritical]
    internal V Lookup<K, V>(K key)
    {
      V v;
      if (!JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>((object) this).TryGetValue(key, out v))
      {
        KeyNotFoundException notFoundException = new KeyNotFoundException(Environment.GetResourceString("Arg_KeyNotFound"));
        int hr = -2147483637;
        notFoundException.SetErrorCode(hr);
        throw notFoundException;
      }
      return v;
    }

    [SecurityCritical]
    internal uint Size<K, V>()
    {
      return (uint) JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>((object) this).Count;
    }

    [SecurityCritical]
    internal bool HasKey<K, V>(K key)
    {
      return JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>((object) this).ContainsKey(key);
    }

    [SecurityCritical]
    internal void Split<K, V>(out IMapView<K, V> first, out IMapView<K, V> second)
    {
      IReadOnlyDictionary<K, V> data = JitHelpers.UnsafeCast<IReadOnlyDictionary<K, V>>((object) this);
      if (data.Count < 2)
      {
        first = (IMapView<K, V>) null;
        second = (IMapView<K, V>) null;
      }
      else
        (data as ConstantSplittableMap<K, V> ?? new ConstantSplittableMap<K, V>(data)).Split(out first, out second);
    }
  }
}
