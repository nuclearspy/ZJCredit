﻿// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Contracts.ContractRuntimeIgnoredAttribute
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Diagnostics.Contracts
{
  /// <summary>标识没有运行时行为的成员。</summary>
  [Conditional("CONTRACTS_FULL")]
  [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  [__DynamicallyInvokable]
  public sealed class ContractRuntimeIgnoredAttribute : Attribute
  {
    /// <summary>初始化 <see cref="T:System.Diagnostics.Contracts.ContractRuntimeIgnoredAttribute" /> 类的新实例。</summary>
    [__DynamicallyInvokable]
    public ContractRuntimeIgnoredAttribute()
    {
    }
  }
}
