﻿// Decompiled with JetBrains decompiler
// Type: System.Threading.TimeoutHelper
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

namespace System.Threading
{
  internal static class TimeoutHelper
  {
    public static uint GetTime()
    {
      return (uint) Environment.TickCount;
    }

    public static int UpdateTimeOut(uint startTime, int originalWaitMillisecondsTimeout)
    {
      uint num1 = TimeoutHelper.GetTime() - startTime;
      if (num1 > (uint) int.MaxValue)
        return 0;
      int num2 = originalWaitMillisecondsTimeout - (int) num1;
      if (num2 <= 0)
        return 0;
      return num2;
    }
  }
}
