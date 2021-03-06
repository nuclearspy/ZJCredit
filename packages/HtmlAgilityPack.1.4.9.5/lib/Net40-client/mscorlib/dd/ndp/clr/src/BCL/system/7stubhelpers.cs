﻿// Decompiled with JetBrains decompiler
// Type: System.StubHelpers.HStringMarshaler
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security;

namespace System.StubHelpers
{
  [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
  internal static class HStringMarshaler
  {
    [SecurityCritical]
    internal static unsafe IntPtr ConvertToNative(string managed)
    {
      if (!Environment.IsWinRTSupported)
        throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
      if (managed == null)
        throw new ArgumentNullException();
      string sourceString = managed;
      int length = sourceString.Length;
      IntPtr num1;
      IntPtr num2 = (IntPtr) &num1;
      Marshal.ThrowExceptionForHR(UnsafeNativeMethods.WindowsCreateString(sourceString, length, (IntPtr*) num2), new IntPtr(-1));
      return num1;
    }

    [SecurityCritical]
    internal static unsafe IntPtr ConvertToNativeReference(string managed, [Out] HSTRING_HEADER* hstringHeader)
    {
      if (!Environment.IsWinRTSupported)
        throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
      if (managed == null)
        throw new ArgumentNullException();
      string str = managed;
      char* sourceString = (char*) str;
      if ((IntPtr) sourceString != IntPtr.Zero)
        sourceString += RuntimeHelpers.OffsetToStringData;
      IntPtr num;
      Marshal.ThrowExceptionForHR(UnsafeNativeMethods.WindowsCreateStringReference(sourceString, managed.Length, hstringHeader, &num), new IntPtr(-1));
      return num;
    }

    [SecurityCritical]
    internal static string ConvertToManaged(IntPtr hstring)
    {
      if (!Environment.IsWinRTSupported)
        throw new PlatformNotSupportedException(Environment.GetResourceString("PlatformNotSupported_WinRT"));
      return WindowsRuntimeMarshal.HStringToString(hstring);
    }

    [SecurityCritical]
    internal static void ClearNative(IntPtr hstring)
    {
      if (!(hstring != IntPtr.Zero))
        return;
      UnsafeNativeMethods.WindowsDeleteString(hstring);
    }
  }
}
