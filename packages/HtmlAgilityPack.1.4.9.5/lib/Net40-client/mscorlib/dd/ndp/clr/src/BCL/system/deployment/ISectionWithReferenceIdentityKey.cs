﻿// Decompiled with JetBrains decompiler
// Type: System.Deployment.Internal.Isolation.ISectionWithReferenceIdentityKey
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("285a8876-c84a-11d7-850f-005cd062464f")]
  [ComImport]
  internal interface ISectionWithReferenceIdentityKey
  {
    void Lookup(IReferenceIdentity ReferenceIdentityKey, [MarshalAs(UnmanagedType.Interface)] out object ppUnknown);
  }
}
