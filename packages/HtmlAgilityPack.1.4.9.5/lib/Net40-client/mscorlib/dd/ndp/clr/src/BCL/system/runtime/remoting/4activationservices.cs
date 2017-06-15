﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.Remoting.Activation.ContextLevelActivator
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;

namespace System.Runtime.Remoting.Activation
{
  [Serializable]
  internal class ContextLevelActivator : IActivator
  {
    private IActivator m_NextActivator;

    public virtual IActivator NextActivator
    {
      [SecurityCritical] get
      {
        return this.m_NextActivator;
      }
      [SecurityCritical] set
      {
        this.m_NextActivator = value;
      }
    }

    public virtual ActivatorLevel Level
    {
      [SecurityCritical] get
      {
        return ActivatorLevel.Context;
      }
    }

    internal ContextLevelActivator()
    {
      this.m_NextActivator = (IActivator) null;
    }

    internal ContextLevelActivator(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException("info");
      this.m_NextActivator = (IActivator) info.GetValue("m_NextActivator", typeof (IActivator));
    }

    [SecurityCritical]
    [ComVisible(true)]
    public virtual IConstructionReturnMessage Activate(IConstructionCallMessage ctorMsg)
    {
      IConstructionCallMessage constructionCallMessage = ctorMsg;
      IActivator nextActivator = constructionCallMessage.Activator.NextActivator;
      constructionCallMessage.Activator = nextActivator;
      return ActivationServices.DoCrossContextActivation(ctorMsg);
    }
  }
}
