﻿// Decompiled with JetBrains decompiler
// Type: System.Deployment.Internal.Isolation.STORE_ASSEMBLY
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation
{
  internal struct STORE_ASSEMBLY
  {
    public uint Status;
    public IDefinitionIdentity DefinitionIdentity;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string ManifestPath;
    public ulong AssemblySize;
    public ulong ChangeId;
  }
}
