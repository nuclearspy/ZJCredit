﻿// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Tracing.EventSourceSettings
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Diagnostics.Tracing
{
  /// <summary>指定事件源的配置选项。</summary>
  [Flags]
  [__DynamicallyInvokable]
  public enum EventSourceSettings
  {
    [__DynamicallyInvokable] Default = 0,
    [__DynamicallyInvokable] ThrowOnEventWriteErrors = 1,
    [__DynamicallyInvokable] EtwManifestEventFormat = 4,
    [__DynamicallyInvokable] EtwSelfDescribingEventFormat = 8,
  }
}
