﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.Serialization.SurrogateKey
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Runtime.Serialization
{
  [Serializable]
  internal class SurrogateKey
  {
    internal Type m_type;
    internal StreamingContext m_context;

    internal SurrogateKey(Type type, StreamingContext context)
    {
      this.m_type = type;
      this.m_context = context;
    }

    public override int GetHashCode()
    {
      return this.m_type.GetHashCode();
    }
  }
}
