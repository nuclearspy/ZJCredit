﻿// Decompiled with JetBrains decompiler
// Type: System.Reflection.Emit.AssemblyBuilderData
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Collections.Generic;
using System.Globalization;
using System.Security;

namespace System.Reflection.Emit
{
  internal class AssemblyBuilderData
  {
    internal List<ModuleBuilder> m_moduleBuilderList;
    internal List<ResWriterData> m_resWriterList;
    internal string m_strAssemblyName;
    internal AssemblyBuilderAccess m_access;
    private InternalAssemblyBuilder m_assembly;
    internal Type[] m_publicComTypeList;
    internal int m_iPublicComTypeCount;
    internal bool m_isSaved;
    internal const int m_iInitialSize = 16;
    internal string m_strDir;
    internal const int m_tkAssembly = 536870913;
    internal PermissionSet m_RequiredPset;
    internal PermissionSet m_OptionalPset;
    internal PermissionSet m_RefusedPset;
    internal CustomAttributeBuilder[] m_CABuilders;
    internal int m_iCABuilder;
    internal byte[][] m_CABytes;
    internal ConstructorInfo[] m_CACons;
    internal int m_iCAs;
    internal PEFileKinds m_peFileKind;
    internal MethodInfo m_entryPointMethod;
    internal Assembly m_ISymWrapperAssembly;
    internal ModuleBuilder m_entryPointModule;
    internal string m_strResourceFileName;
    internal byte[] m_resourceBytes;
    internal NativeVersionInfo m_nativeVersion;
    internal bool m_hasUnmanagedVersionInfo;
    internal bool m_OverrideUnmanagedVersionInfo;

    [SecurityCritical]
    internal AssemblyBuilderData(InternalAssemblyBuilder assembly, string strAssemblyName, AssemblyBuilderAccess access, string dir)
    {
      this.m_assembly = assembly;
      this.m_strAssemblyName = strAssemblyName;
      this.m_access = access;
      this.m_moduleBuilderList = new List<ModuleBuilder>();
      this.m_resWriterList = new List<ResWriterData>();
      this.m_strDir = dir != null || access == AssemblyBuilderAccess.Run ? dir : Environment.CurrentDirectory;
      this.m_peFileKind = PEFileKinds.Dll;
    }

    internal void AddModule(ModuleBuilder dynModule)
    {
      this.m_moduleBuilderList.Add(dynModule);
    }

    internal void AddResWriter(ResWriterData resData)
    {
      this.m_resWriterList.Add(resData);
    }

    internal void AddCustomAttribute(CustomAttributeBuilder customBuilder)
    {
      if (this.m_CABuilders == null)
        this.m_CABuilders = new CustomAttributeBuilder[16];
      if (this.m_iCABuilder == this.m_CABuilders.Length)
      {
        CustomAttributeBuilder[] attributeBuilderArray = new CustomAttributeBuilder[this.m_iCABuilder * 2];
        Array.Copy((Array) this.m_CABuilders, (Array) attributeBuilderArray, this.m_iCABuilder);
        this.m_CABuilders = attributeBuilderArray;
      }
      this.m_CABuilders[this.m_iCABuilder] = customBuilder;
      this.m_iCABuilder = this.m_iCABuilder + 1;
    }

    internal void AddCustomAttribute(ConstructorInfo con, byte[] binaryAttribute)
    {
      if (this.m_CABytes == null)
      {
        this.m_CABytes = new byte[16][];
        this.m_CACons = new ConstructorInfo[16];
      }
      if (this.m_iCAs == this.m_CABytes.Length)
      {
        byte[][] numArray = new byte[this.m_iCAs * 2][];
        ConstructorInfo[] constructorInfoArray = new ConstructorInfo[this.m_iCAs * 2];
        for (int index = 0; index < this.m_iCAs; ++index)
        {
          numArray[index] = this.m_CABytes[index];
          constructorInfoArray[index] = this.m_CACons[index];
        }
        this.m_CABytes = numArray;
        this.m_CACons = constructorInfoArray;
      }
      byte[] numArray1 = new byte[binaryAttribute.Length];
      Array.Copy((Array) binaryAttribute, (Array) numArray1, binaryAttribute.Length);
      this.m_CABytes[this.m_iCAs] = numArray1;
      this.m_CACons[this.m_iCAs] = con;
      this.m_iCAs = this.m_iCAs + 1;
    }

    [SecurityCritical]
    internal void FillUnmanagedVersionInfo()
    {
      CultureInfo locale = this.m_assembly.GetLocale();
      if (locale != null)
        this.m_nativeVersion.m_lcid = locale.LCID;
      for (int index = 0; index < this.m_iCABuilder; ++index)
      {
        Type declaringType = this.m_CABuilders[index].m_con.DeclaringType;
        if (this.m_CABuilders[index].m_constructorArgs.Length != 0 && this.m_CABuilders[index].m_constructorArgs[0] != null)
        {
          if (declaringType.Equals(typeof (AssemblyCopyrightAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strCopyright = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyTrademarkAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strTrademark = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyProductAttribute)))
          {
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strProduct = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyCompanyAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strCompany = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyDescriptionAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            this.m_nativeVersion.m_strDescription = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyTitleAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            this.m_nativeVersion.m_strTitle = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyInformationalVersionAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strProductVersion = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
          else if (declaringType.Equals(typeof (AssemblyCultureAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            this.m_nativeVersion.m_lcid = new CultureInfo(this.m_CABuilders[index].m_constructorArgs[0].ToString()).LCID;
          }
          else if (declaringType.Equals(typeof (AssemblyFileVersionAttribute)))
          {
            if (this.m_CABuilders[index].m_constructorArgs.Length != 1)
              throw new ArgumentException(Environment.GetResourceString("Argument_BadCAForUnmngRSC", (object) this.m_CABuilders[index].m_con.ReflectedType.Name));
            if (!this.m_OverrideUnmanagedVersionInfo)
              this.m_nativeVersion.m_strFileVersion = this.m_CABuilders[index].m_constructorArgs[0].ToString();
          }
        }
      }
    }

    internal void CheckResNameConflict(string strNewResName)
    {
      int count = this.m_resWriterList.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.m_resWriterList[index].m_strName.Equals(strNewResName))
          throw new ArgumentException(Environment.GetResourceString("Argument_DuplicateResourceName"));
      }
    }

    internal void CheckNameConflict(string strNewModuleName)
    {
      int count = this.m_moduleBuilderList.Count;
      for (int index = 0; index < count; ++index)
      {
        if (this.m_moduleBuilderList[index].m_moduleData.m_strModuleName.Equals(strNewModuleName))
          throw new ArgumentException(Environment.GetResourceString("Argument_DuplicateModuleName"));
      }
    }

    internal void CheckTypeNameConflict(string strTypeName, TypeBuilder enclosingType)
    {
      for (int index = 0; index < this.m_moduleBuilderList.Count; ++index)
        this.m_moduleBuilderList[index].CheckTypeNameConflict(strTypeName, (Type) enclosingType);
    }

    internal void CheckFileNameConflict(string strFileName)
    {
      int count1 = this.m_moduleBuilderList.Count;
      for (int index = 0; index < count1; ++index)
      {
        ModuleBuilder moduleBuilder = this.m_moduleBuilderList[index];
        if (moduleBuilder.m_moduleData.m_strFileName != null && string.Compare(moduleBuilder.m_moduleData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
          throw new ArgumentException(Environment.GetResourceString("Argument_DuplicatedFileName"));
      }
      int count2 = this.m_resWriterList.Count;
      for (int index = 0; index < count2; ++index)
      {
        ResWriterData resWriterData = this.m_resWriterList[index];
        if (resWriterData.m_strFileName != null && string.Compare(resWriterData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
          throw new ArgumentException(Environment.GetResourceString("Argument_DuplicatedFileName"));
      }
    }

    internal ModuleBuilder FindModuleWithFileName(string strFileName)
    {
      int count = this.m_moduleBuilderList.Count;
      for (int index = 0; index < count; ++index)
      {
        ModuleBuilder moduleBuilder = this.m_moduleBuilderList[index];
        if (moduleBuilder.m_moduleData.m_strFileName != null && string.Compare(moduleBuilder.m_moduleData.m_strFileName, strFileName, StringComparison.OrdinalIgnoreCase) == 0)
          return moduleBuilder;
      }
      return (ModuleBuilder) null;
    }

    internal ModuleBuilder FindModuleWithName(string strName)
    {
      int count = this.m_moduleBuilderList.Count;
      for (int index = 0; index < count; ++index)
      {
        ModuleBuilder moduleBuilder = this.m_moduleBuilderList[index];
        if (moduleBuilder.m_moduleData.m_strModuleName != null && string.Compare(moduleBuilder.m_moduleData.m_strModuleName, strName, StringComparison.OrdinalIgnoreCase) == 0)
          return moduleBuilder;
      }
      return (ModuleBuilder) null;
    }

    internal void AddPublicComType(Type type)
    {
      if (this.m_isSaved)
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotAlterAssembly"));
      this.EnsurePublicComTypeCapacity();
      this.m_publicComTypeList[this.m_iPublicComTypeCount] = type;
      this.m_iPublicComTypeCount = this.m_iPublicComTypeCount + 1;
    }

    internal void AddPermissionRequests(PermissionSet required, PermissionSet optional, PermissionSet refused)
    {
      if (this.m_isSaved)
        throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_CannotAlterAssembly"));
      this.m_RequiredPset = required;
      this.m_OptionalPset = optional;
      this.m_RefusedPset = refused;
    }

    private void EnsurePublicComTypeCapacity()
    {
      if (this.m_publicComTypeList == null)
        this.m_publicComTypeList = new Type[16];
      if (this.m_iPublicComTypeCount != this.m_publicComTypeList.Length)
        return;
      Type[] typeArray = new Type[this.m_iPublicComTypeCount * 2];
      Array.Copy((Array) this.m_publicComTypeList, (Array) typeArray, this.m_iPublicComTypeCount);
      this.m_publicComTypeList = typeArray;
    }
  }
}
