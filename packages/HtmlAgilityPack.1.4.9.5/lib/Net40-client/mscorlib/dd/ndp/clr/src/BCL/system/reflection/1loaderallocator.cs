﻿// Decompiled with JetBrains decompiler
// Type: System.Reflection.LoaderAllocator
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Reflection
{
  internal sealed class LoaderAllocator
  {
    private LoaderAllocatorScout m_scout;
    private object[] m_slots;
    internal CerHashtable<RuntimeMethodInfo, RuntimeMethodInfo> m_methodInstantiations;
    private int m_slotsUsed;

    private LoaderAllocator()
    {
      this.m_slots = new object[5];
      this.m_scout = new LoaderAllocatorScout();
    }
  }
}
