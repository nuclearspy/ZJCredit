﻿// Decompiled with JetBrains decompiler
// Type: System.Reflection.MethodSemanticsAttributes
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Reflection
{
  [Flags]
  [Serializable]
  internal enum MethodSemanticsAttributes
  {
    Setter = 1,
    Getter = 2,
    Other = 4,
    AddOn = 8,
    RemoveOn = 16,
    Fire = 32,
  }
}
