﻿// Decompiled with JetBrains decompiler
// Type: System.Deployment.Internal.Isolation.Manifest.IAssemblyReferenceEntry
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [Guid("FD47B733-AFBC-45e4-B7C2-BBEB1D9F766C")]
  [ComImport]
  internal interface IAssemblyReferenceEntry
  {
    AssemblyReferenceEntry AllData { [SecurityCritical] get; }

    IReferenceIdentity ReferenceIdentity { [SecurityCritical] get; }

    uint Flags { [SecurityCritical] get; }

    IAssemblyReferenceDependentAssemblyEntry DependentAssembly { [SecurityCritical] get; }
  }
}
