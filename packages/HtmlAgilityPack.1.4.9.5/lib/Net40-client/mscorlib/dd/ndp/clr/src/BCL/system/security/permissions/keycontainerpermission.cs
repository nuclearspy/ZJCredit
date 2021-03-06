﻿// Decompiled with JetBrains decompiler
// Type: System.Security.Permissions.KeyContainerPermissionAccessEntry
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace System.Security.Permissions
{
  /// <summary>为特定密钥容器指定访问权限。此类不能被继承。</summary>
  [ComVisible(true)]
  [Serializable]
  public sealed class KeyContainerPermissionAccessEntry
  {
    private string m_keyStore;
    private string m_providerName;
    private int m_providerType;
    private string m_keyContainerName;
    private int m_keySpec;
    private KeyContainerPermissionFlags m_flags;

    /// <summary>获取或设置密钥存储区的名称。</summary>
    /// <returns>密钥存储区的名称。</returns>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public string KeyStore
    {
      get
      {
        return this.m_keyStore;
      }
      set
      {
        if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(value, this.ProviderName, this.ProviderType, this.KeyContainerName, this.KeySpec))
          throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
        if (value == null)
        {
          this.m_keyStore = "*";
        }
        else
        {
          if (value != "User" && value != "Machine" && value != "*")
            throw new ArgumentException(Environment.GetResourceString("Argument_InvalidKeyStore", (object) value), "value");
          this.m_keyStore = value;
        }
      }
    }

    /// <summary>获取或设置提供程序名称。</summary>
    /// <returns>提供程序的名称。</returns>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public string ProviderName
    {
      get
      {
        return this.m_providerName;
      }
      set
      {
        if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, value, this.ProviderType, this.KeyContainerName, this.KeySpec))
          throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
        if (value == null)
          this.m_providerName = "*";
        else
          this.m_providerName = value;
      }
    }

    /// <summary>获取或设置提供程序类型。</summary>
    /// <returns>Wincrypt.h 头文件中定义的 PROV_ 值之一。</returns>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public int ProviderType
    {
      get
      {
        return this.m_providerType;
      }
      set
      {
        if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, value, this.KeyContainerName, this.KeySpec))
          throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
        this.m_providerType = value;
      }
    }

    /// <summary>获取或设置密钥容器名称。</summary>
    /// <returns>密钥容器的名称。</returns>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public string KeyContainerName
    {
      get
      {
        return this.m_keyContainerName;
      }
      set
      {
        if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, this.ProviderType, value, this.KeySpec))
          throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
        if (value == null)
          this.m_keyContainerName = "*";
        else
          this.m_keyContainerName = value;
      }
    }

    /// <summary>获取或设置密钥规范。</summary>
    /// <returns>Wincrypt.h 头文件中定义的 AT_ 值之一。</returns>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public int KeySpec
    {
      get
      {
        return this.m_keySpec;
      }
      set
      {
        if (KeyContainerPermissionAccessEntry.IsUnrestrictedEntry(this.KeyStore, this.ProviderName, this.ProviderType, this.KeyContainerName, value))
          throw new ArgumentException(Environment.GetResourceString("Arg_InvalidAccessEntry"));
        this.m_keySpec = value;
      }
    }

    /// <summary>获取或设置密钥容器权限。</summary>
    /// <returns>
    /// <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> 值的按位组合。默认值为 <see cref="F:System.Security.Permissions.KeyContainerPermissionFlags.NoFlags" />。</returns>
    public KeyContainerPermissionFlags Flags
    {
      get
      {
        return this.m_flags;
      }
      set
      {
        KeyContainerPermission.VerifyFlags(value);
        this.m_flags = value;
      }
    }

    internal KeyContainerPermissionAccessEntry(KeyContainerPermissionAccessEntry accessEntry)
      : this(accessEntry.KeyStore, accessEntry.ProviderName, accessEntry.ProviderType, accessEntry.KeyContainerName, accessEntry.KeySpec, accessEntry.Flags)
    {
    }

    /// <summary>使用指定的密钥容器名称和访问权限初始化 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 类的新实例。</summary>
    /// <param name="keyContainerName">密钥容器的名称。</param>
    /// <param name="flags">
    /// <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> 值的按位组合。</param>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public KeyContainerPermissionAccessEntry(string keyContainerName, KeyContainerPermissionFlags flags)
      : this((string) null, (string) null, -1, keyContainerName, -1, flags)
    {
    }

    /// <summary>使用指定的加密服务提供程序 (CSP) 参数和访问权限初始化 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 类的新实例。</summary>
    /// <param name="parameters">
    /// <see cref="T:System.Security.Cryptography.CspParameters" /> 对象，包含加密服务提供程序 (CSP) 参数。</param>
    /// <param name="flags">
    /// <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> 值的按位组合。</param>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public KeyContainerPermissionAccessEntry(CspParameters parameters, KeyContainerPermissionFlags flags)
      : this((parameters.Flags & CspProviderFlags.UseMachineKeyStore) == CspProviderFlags.UseMachineKeyStore ? "Machine" : "User", parameters.ProviderName, parameters.ProviderType, parameters.KeyContainerName, parameters.KeyNumber, flags)
    {
    }

    /// <summary>使用指定的属性值初始化 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 类的新实例。</summary>
    /// <param name="keyStore">密钥存储区的名称。</param>
    /// <param name="providerName">提供程序的名称。</param>
    /// <param name="providerType">提供程序的类型代码。请参见 <see cref="P:System.Security.Permissions.KeyContainerPermissionAccessEntry.ProviderType" /> 属性获取相关的值。</param>
    /// <param name="keyContainerName">密钥容器的名称。</param>
    /// <param name="keySpec">密钥规范。请参见 <see cref="P:System.Security.Permissions.KeyContainerPermissionAccessEntry.KeySpec" /> 属性获取相关的值。</param>
    /// <param name="flags">
    /// <see cref="T:System.Security.Permissions.KeyContainerPermissionFlags" /> 值的按位组合。</param>
    /// <exception cref="T:System.ArgumentException">对结果项的访问将不受限制。</exception>
    public KeyContainerPermissionAccessEntry(string keyStore, string providerName, int providerType, string keyContainerName, int keySpec, KeyContainerPermissionFlags flags)
    {
      this.m_providerName = providerName == null ? "*" : providerName;
      this.m_providerType = providerType;
      this.m_keyContainerName = keyContainerName == null ? "*" : keyContainerName;
      this.m_keySpec = keySpec;
      this.KeyStore = keyStore;
      this.Flags = flags;
    }

    /// <summary>确定指定的 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 对象是否等于当前实例。</summary>
    /// <returns>如果指定的 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 等于当前的 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 对象，则为 true；否则为 false。</returns>
    /// <param name="o">要与当前实例进行比较的 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 对象。</param>
    public override bool Equals(object o)
    {
      KeyContainerPermissionAccessEntry permissionAccessEntry = o as KeyContainerPermissionAccessEntry;
      return permissionAccessEntry != null && !(permissionAccessEntry.m_keyStore != this.m_keyStore) && (!(permissionAccessEntry.m_providerName != this.m_providerName) && permissionAccessEntry.m_providerType == this.m_providerType) && (!(permissionAccessEntry.m_keyContainerName != this.m_keyContainerName) && permissionAccessEntry.m_keySpec == this.m_keySpec);
    }

    /// <summary>获取适合在哈希算法和类似哈希表的数据结构中使用的当前实例的哈希代码。</summary>
    /// <returns>当前 <see cref="T:System.Security.Permissions.KeyContainerPermissionAccessEntry" /> 对象的哈希代码。</returns>
    public override int GetHashCode()
    {
      return 0 | (this.m_keyStore.GetHashCode() & (int) byte.MaxValue) << 24 | (this.m_providerName.GetHashCode() & (int) byte.MaxValue) << 16 | (this.m_providerType & 15) << 12 | (this.m_keyContainerName.GetHashCode() & (int) byte.MaxValue) << 4 | this.m_keySpec & 15;
    }

    internal bool IsSubsetOf(KeyContainerPermissionAccessEntry target)
    {
      return (!(target.m_keyStore != "*") || !(this.m_keyStore != target.m_keyStore)) && (!(target.m_providerName != "*") || !(this.m_providerName != target.m_providerName)) && ((target.m_providerType == -1 || this.m_providerType == target.m_providerType) && (!(target.m_keyContainerName != "*") || !(this.m_keyContainerName != target.m_keyContainerName))) && (target.m_keySpec == -1 || this.m_keySpec == target.m_keySpec);
    }

    internal static bool IsUnrestrictedEntry(string keyStore, string providerName, int providerType, string keyContainerName, int keySpec)
    {
      return (!(keyStore != "*") || keyStore == null) && (!(providerName != "*") || providerName == null) && (providerType == -1 && (!(keyContainerName != "*") || keyContainerName == null)) && keySpec == -1;
    }
  }
}
