﻿// Decompiled with JetBrains decompiler
// Type: System.Security.Policy.IUnionSemanticCodeGroup
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Security.Policy
{
  internal interface IUnionSemanticCodeGroup
  {
    PolicyStatement InternalResolve(Evidence evidence);
  }
}
