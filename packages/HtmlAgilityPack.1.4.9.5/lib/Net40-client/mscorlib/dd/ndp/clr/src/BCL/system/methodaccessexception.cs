﻿// Decompiled with JetBrains decompiler
// Type: System.MethodAccessException
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
  /// <summary>存在想要访问某个方法（如访问部分可信代码中的私有方法）的无效尝试时，所引发的异常。</summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [__DynamicallyInvokable]
  [Serializable]
  public class MethodAccessException : MemberAccessException
  {
    /// <summary>初始化 <see cref="T:System.MethodAccessException" /> 类的新实例，将新实例的 <see cref="P:System.Exception.Message" /> 属性设置为系统提供的描述错误的消息，如“试图访问该方法时失败”。此消息将考虑当前系统区域性。</summary>
    [__DynamicallyInvokable]
    public MethodAccessException()
      : base(Environment.GetResourceString("Arg_MethodAccessException"))
    {
      this.SetErrorCode(-2146233072);
    }

    /// <summary>使用指定的错误信息初始化 <see cref="T:System.MethodAccessException" /> 类的新实例。</summary>
    /// <param name="message">描述该错误的 <see cref="T:System.String" />。</param>
    [__DynamicallyInvokable]
    public MethodAccessException(string message)
      : base(message)
    {
      this.SetErrorCode(-2146233072);
    }

    /// <summary>使用指定错误信息和对作为此异常原因的内部异常的引用来初始化 <see cref="T:System.MethodAccessException" /> 类的新实例。</summary>
    /// <param name="message">解释异常原因的错误信息。</param>
    /// <param name="inner">导致当前异常的异常。如果 <paramref name="inner" /> 参数不是空引用（在 Visual Basic 中为 Nothing），则在处理内部异常的 catch 块中引发当前异常。</param>
    [__DynamicallyInvokable]
    public MethodAccessException(string message, Exception inner)
      : base(message, inner)
    {
      this.SetErrorCode(-2146233072);
    }

    /// <summary>用序列化数据初始化 <see cref="T:System.MethodAccessException" /> 类的新实例。</summary>
    /// <param name="info">承载序列化对象数据的对象。</param>
    /// <param name="context">关于来源和目标的上下文信息</param>
    protected MethodAccessException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
