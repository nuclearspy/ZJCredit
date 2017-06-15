﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.Remoting.Messaging.CRMDictionary
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections;
using System.Runtime.Remoting.Activation;
using System.Security;

namespace System.Runtime.Remoting.Messaging
{
  internal class CRMDictionary : MessageDictionary
  {
    public static string[] CRMkeysFault = new string[5]{ "__Uri", "__MethodName", "__MethodSignature", "__TypeName", "__CallContext" };
    public static string[] CRMkeysNoFault = new string[7]{ "__Uri", "__MethodName", "__MethodSignature", "__TypeName", "__Return", "__OutArgs", "__CallContext" };
    internal IConstructionReturnMessage _crmsg;
    internal bool fault;

    [SecurityCritical]
    public CRMDictionary(IConstructionReturnMessage msg, IDictionary idict)
      : base(msg.Exception != null ? CRMDictionary.CRMkeysFault : CRMDictionary.CRMkeysNoFault, idict)
    {
      this.fault = msg.Exception != null;
      this._crmsg = msg;
    }

    [SecuritySafeCritical]
    internal override object GetMessageValue(int i)
    {
      switch (i)
      {
        case 0:
          return (object) this._crmsg.Uri;
        case 1:
          return (object) this._crmsg.MethodName;
        case 2:
          return this._crmsg.MethodSignature;
        case 3:
          return (object) this._crmsg.TypeName;
        case 4:
          if (!this.fault)
            return this._crmsg.ReturnValue;
          return (object) this.FetchLogicalCallContext();
        case 5:
          return (object) this._crmsg.Args;
        case 6:
          return (object) this.FetchLogicalCallContext();
        default:
          throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
      }
    }

    [SecurityCritical]
    private LogicalCallContext FetchLogicalCallContext()
    {
      ReturnMessage returnMessage = this._crmsg as ReturnMessage;
      if (returnMessage != null)
        return returnMessage.GetLogicalCallContext();
      MethodResponse methodResponse = this._crmsg as MethodResponse;
      if (methodResponse != null)
        return methodResponse.GetLogicalCallContext();
      throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
    }

    [SecurityCritical]
    internal override void SetSpecialKey(int keyNum, object value)
    {
      ReturnMessage returnMessage = this._crmsg as ReturnMessage;
      MethodResponse methodResponse = this._crmsg as MethodResponse;
      if (keyNum != 0)
      {
        if (keyNum != 1)
          throw new RemotingException(Environment.GetResourceString("Remoting_Default"));
        if (returnMessage != null)
        {
          returnMessage.SetLogicalCallContext((LogicalCallContext) value);
        }
        else
        {
          if (methodResponse == null)
            throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
          methodResponse.SetLogicalCallContext((LogicalCallContext) value);
        }
      }
      else if (returnMessage != null)
      {
        returnMessage.Uri = (string) value;
      }
      else
      {
        if (methodResponse == null)
          throw new RemotingException(Environment.GetResourceString("Remoting_Message_BadType"));
        methodResponse.Uri = (string) value;
      }
    }
  }
}
