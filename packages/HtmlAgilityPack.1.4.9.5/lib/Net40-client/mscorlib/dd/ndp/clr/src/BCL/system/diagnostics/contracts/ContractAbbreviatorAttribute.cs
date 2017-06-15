﻿// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Contracts.ContractAbbreviatorAttribute
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Diagnostics.Contracts
{
  /// <summary>定义您可用于替代完整协定语法的缩写。</summary>
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  [Conditional("CONTRACTS_FULL")]
  [__DynamicallyInvokable]
  public sealed class ContractAbbreviatorAttribute : Attribute
  {
    /// <summary>初始化 <see cref="T:System.Diagnostics.Contracts.ContractAbbreviatorAttribute" /> 类的新实例。</summary>
    [__DynamicallyInvokable]
    public ContractAbbreviatorAttribute()
    {
    }
  }
}
