﻿// Decompiled with JetBrains decompiler
// Type: System.Runtime.Remoting.Messaging.SmuggledObjRef
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Security;

namespace System.Runtime.Remoting.Messaging
{
  internal class SmuggledObjRef
  {
    [SecurityCritical]
    private ObjRef _objRef;

    public ObjRef ObjRef
    {
      [SecurityCritical] get
      {
        return this._objRef;
      }
    }

    [SecurityCritical]
    public SmuggledObjRef(ObjRef objRef)
    {
      this._objRef = objRef;
    }
  }
}
