﻿// Decompiled with JetBrains decompiler
// Type: System.Deployment.Internal.Isolation.Manifest.COMServerEntry
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
  [StructLayout(LayoutKind.Sequential)]
  internal class COMServerEntry
  {
    public Guid Clsid;
    public uint Flags;
    public Guid ConfiguredGuid;
    public Guid ImplementedClsid;
    public Guid TypeLibrary;
    public uint ThreadingModel;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string RuntimeVersion;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string HostFile;
  }
}
