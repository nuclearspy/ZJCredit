﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.Remoting.Messaging.ConstructorCallMessage
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Proxies;
using System.Security;
using System.Threading;

namespace System.Runtime.Remoting.Messaging
{
  internal class ConstructorCallMessage : IConstructionCallMessage, IMethodCallMessage, IMethodMessage, IMessage
  {
    private object[] _callSiteActivationAttributes;
    private object[] _womGlobalAttributes;
    private object[] _typeAttributes;
    [NonSerialized]
    private RuntimeType _activationType;
    private string _activationTypeName;
    private IList _contextProperties;
    private int _iFlags;
    private Message _message;
    private object _properties;
    private ArgMapper _argMapper;
    private IActivator _activator;
    private const int CCM_ACTIVATEINCONTEXT = 1;

    public object[] CallSiteActivationAttributes
    {
      [SecurityCritical] get
      {
        return this._callSiteActivationAttributes;
      }
    }

    public Type ActivationType
    {
      [SecurityCritical] get
      {
        if (this._activationType == (RuntimeType) null && this._activationTypeName != null)
          this._activationType = RemotingServices.InternalGetTypeFromQualifiedTypeName(this._activationTypeName, false);
        return (Type) this._activationType;
      }
    }

    public string ActivationTypeName
    {
      [SecurityCritical] get
      {
        return this._activationTypeName;
      }
    }

    public IList ContextProperties
    {
      [SecurityCritical] get
      {
        if (this._contextProperties == null)
          this._contextProperties = (IList) new ArrayList();
        return this._contextProperties;
      }
    }

    public string Uri
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.Uri;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
      set
      {
        if (this._message == null)
          throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
        this._message.Uri = value;
      }
    }

    public string MethodName
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.MethodName;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public string TypeName
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.TypeName;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public object MethodSignature
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.MethodSignature;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public MethodBase MethodBase
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.MethodBase;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public int InArgCount
    {
      [SecurityCritical] get
      {
        if (this._argMapper == null)
          this._argMapper = new ArgMapper((IMethodMessage) this, false);
        return this._argMapper.ArgCount;
      }
    }

    public object[] InArgs
    {
      [SecurityCritical] get
      {
        if (this._argMapper == null)
          this._argMapper = new ArgMapper((IMethodMessage) this, false);
        return this._argMapper.Args;
      }
    }

    public int ArgCount
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.ArgCount;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public bool HasVarArgs
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.HasVarArgs;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public object[] Args
    {
      [SecurityCritical] get
      {
        if (this._message != null)
          return this._message.Args;
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
      }
    }

    public IDictionary Properties
    {
      [SecurityCritical] get
      {
        if (this._properties == null)
          Interlocked.CompareExchange(ref this._properties, (object) new CCMDictionary((IConstructionCallMessage) this, (IDictionary) new Hashtable()), (object) null);
        return (IDictionary) this._properties;
      }
    }

    public IActivator Activator
    {
      [SecurityCritical] get
      {
        return this._activator;
      }
      [SecurityCritical] set
      {
        this._activator = value;
      }
    }

    public LogicalCallContext LogicalCallContext
    {
      [SecurityCritical] get
      {
        return this.GetLogicalCallContext();
      }
    }

    internal bool ActivateInContext
    {
      get
      {
        return (uint) (this._iFlags & 1) > 0U;
      }
      set
      {
        this._iFlags = value ? this._iFlags | 1 : this._iFlags & -2;
      }
    }

    private ConstructorCallMessage()
    {
    }

    [SecurityCritical]
    internal ConstructorCallMessage(object[] callSiteActivationAttributes, object[] womAttr, object[] typeAttr, RuntimeType serverType)
    {
      this._activationType = serverType;
      this._activationTypeName = RemotingServices.GetDefaultQualifiedTypeName(this._activationType);
      this._callSiteActivationAttributes = callSiteActivationAttributes;
      this._womGlobalAttributes = womAttr;
      this._typeAttributes = typeAttr;
    }

    [SecurityCritical]
    public object GetThisPtr()
    {
      if (this._message != null)
        return this._message.GetThisPtr();
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
    }

    internal object[] GetWOMAttributes()
    {
      return this._womGlobalAttributes;
    }

    internal object[] GetTypeAttributes()
    {
      return this._typeAttributes;
    }

    [SecurityCritical]
    public object GetInArg(int argNum)
    {
      if (this._argMapper == null)
        this._argMapper = new ArgMapper((IMethodMessage) this, false);
      return this._argMapper.GetArg(argNum);
    }

    [SecurityCritical]
    public string GetInArgName(int index)
    {
      if (this._argMapper == null)
        this._argMapper = new ArgMapper((IMethodMessage) this, false);
      return this._argMapper.GetArgName(index);
    }

    [SecurityCritical]
    public object GetArg(int argNum)
    {
      if (this._message != null)
        return this._message.GetArg(argNum);
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
    }

    [SecurityCritical]
    public string GetArgName(int index)
    {
      if (this._message != null)
        return this._message.GetArgName(index);
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
    }

    [SecurityCritical]
    internal void SetFrame(MessageData msgData)
    {
      this._message = new Message();
      this._message.InitFields(msgData);
    }

    [SecurityCritical]
    internal LogicalCallContext GetLogicalCallContext()
    {
      if (this._message != null)
        return this._message.GetLogicalCallContext();
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
    }

    [SecurityCritical]
    internal LogicalCallContext SetLogicalCallContext(LogicalCallContext ctx)
    {
      if (this._message != null)
        return this._message.SetLogicalCallContext(ctx);
      throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_InternalState"));
    }

    internal Message GetMessage()
    {
      return this._message;
    }
  }
}
