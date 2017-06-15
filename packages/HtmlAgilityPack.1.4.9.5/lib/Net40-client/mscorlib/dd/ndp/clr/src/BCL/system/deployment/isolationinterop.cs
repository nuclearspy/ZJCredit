﻿// Decompiled with JetBrains decompiler
// Type: System.Deployment.Internal.Isolation.BLOB
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation
{
  internal struct BLOB : IDisposable
  {
    [MarshalAs(UnmanagedType.U4)]
    public uint Size;
    [MarshalAs(UnmanagedType.SysInt)]
    public IntPtr BlobData;

    [SecuritySafeCritical]
    public void Dispose()
    {
      if (!(this.BlobData != IntPtr.Zero))
        return;
      Marshal.FreeCoTaskMem(this.BlobData);
      this.BlobData = IntPtr.Zero;
    }
  }
}
