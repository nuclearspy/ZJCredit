﻿// Decompiled with JetBrains decompiler
// Type: System.Configuration.Assemblies.AssemblyHashAlgorithm
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Configuration.Assemblies
{
  /// <summary>指定用于哈希文件和用于生成强名称的所有哈希算法。</summary>
  [ComVisible(true)]
  [Serializable]
  public enum AssemblyHashAlgorithm
  {
    None = 0,
    MD5 = 32771,
    SHA1 = 32772,
    [ComVisible(false)] SHA256 = 32780,
    [ComVisible(false)] SHA384 = 32781,
    [ComVisible(false)] SHA512 = 32782,
  }
}