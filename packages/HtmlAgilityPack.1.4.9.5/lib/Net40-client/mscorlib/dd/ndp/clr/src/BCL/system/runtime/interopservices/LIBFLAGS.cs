﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.LIBFLAGS
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Runtime.InteropServices
{
  /// <summary>请改用 <see cref="T:System.Runtime.InteropServices.ComTypes.LIBFLAGS" />。</summary>
  [Obsolete("Use System.Runtime.InteropServices.ComTypes.LIBFLAGS instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
  [Flags]
  [Serializable]
  public enum LIBFLAGS : short
  {
    LIBFLAG_FRESTRICTED = 1,
    LIBFLAG_FCONTROL = 2,
    LIBFLAG_FHIDDEN = 4,
    LIBFLAG_FHASDISKIMAGE = 8,
  }
}
