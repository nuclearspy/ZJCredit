﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.SetWin32ContextInIDispatchAttribute
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Runtime.InteropServices
{
  /// <summary>此特性已弃用。</summary>
  [Obsolete("This attribute has been deprecated.  Application Domains no longer respect Activation Context boundaries in IDispatch calls.", false)]
  [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
  [ComVisible(true)]
  public sealed class SetWin32ContextInIDispatchAttribute : Attribute
  {
  }
}
