﻿// Decompiled with JetBrains decompiler
// Type: System.Security.Permissions.FileDialogPermissionAttribute
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Security.Permissions
{
  /// <summary>允许对使用声明安全性应用到代码中的 <see cref="T:System.Security.Permissions.FileDialogPermission" /> 进行安全操作。此类不能被继承。</summary>
  [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
  [ComVisible(true)]
  [Serializable]
  public sealed class FileDialogPermissionAttribute : CodeAccessSecurityAttribute
  {
    private FileDialogPermissionAccess m_access;

    /// <summary>获取或设置一个值，该值指示是否声明了通过文件对话框打开文件的权限。</summary>
    /// <returns>如果声明了通过文件对话框打开文件的权限，则为 true；否则为 false。</returns>
    public bool Open
    {
      get
      {
        return (uint) (this.m_access & FileDialogPermissionAccess.Open) > 0U;
      }
      set
      {
        this.m_access = value ? this.m_access | FileDialogPermissionAccess.Open : this.m_access & ~FileDialogPermissionAccess.Open;
      }
    }

    /// <summary>获取或设置一个值，该值指示是否声明了通过文件对话框保存文件的权限。</summary>
    /// <returns>如果声明了通过文件对话框保存文件的权限，则为 true；否则为 false。</returns>
    public bool Save
    {
      get
      {
        return (uint) (this.m_access & FileDialogPermissionAccess.Save) > 0U;
      }
      set
      {
        this.m_access = value ? this.m_access | FileDialogPermissionAccess.Save : this.m_access & ~FileDialogPermissionAccess.Save;
      }
    }

    /// <summary>用指定的 <see cref="T:System.Security.Permissions.SecurityAction" /> 初始化 <see cref="T:System.Security.Permissions.FileDialogPermissionAttribute" /> 类的新实例。</summary>
    /// <param name="action">
    /// <see cref="T:System.Security.Permissions.SecurityAction" /> 值之一。</param>
    public FileDialogPermissionAttribute(SecurityAction action)
      : base(action)
    {
    }

    /// <summary>创建并返回一个新的 <see cref="T:System.Security.Permissions.FileDialogPermission" />。</summary>
    /// <returns>与此特性对应的 <see cref="T:System.Security.Permissions.FileDialogPermission" />。</returns>
    public override IPermission CreatePermission()
    {
      if (this.m_unrestricted)
        return (IPermission) new FileDialogPermission(PermissionState.Unrestricted);
      return (IPermission) new FileDialogPermission(this.m_access);
    }
  }
}
