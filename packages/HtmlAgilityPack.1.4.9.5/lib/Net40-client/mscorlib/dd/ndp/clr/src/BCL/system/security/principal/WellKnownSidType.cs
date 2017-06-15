﻿// Decompiled with JetBrains decompiler
// Type: System.Security.Principal.WellKnownSidType
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;

namespace System.Security.Principal
{
  /// <summary>定义一组常用的安全标识符 (SID)。</summary>
  [ComVisible(false)]
  public enum WellKnownSidType
  {
    NullSid = 0,
    WorldSid = 1,
    LocalSid = 2,
    CreatorOwnerSid = 3,
    CreatorGroupSid = 4,
    CreatorOwnerServerSid = 5,
    CreatorGroupServerSid = 6,
    NTAuthoritySid = 7,
    DialupSid = 8,
    NetworkSid = 9,
    BatchSid = 10,
    InteractiveSid = 11,
    ServiceSid = 12,
    AnonymousSid = 13,
    ProxySid = 14,
    EnterpriseControllersSid = 15,
    SelfSid = 16,
    AuthenticatedUserSid = 17,
    RestrictedCodeSid = 18,
    TerminalServerSid = 19,
    RemoteLogonIdSid = 20,
    LogonIdsSid = 21,
    LocalSystemSid = 22,
    LocalServiceSid = 23,
    NetworkServiceSid = 24,
    BuiltinDomainSid = 25,
    BuiltinAdministratorsSid = 26,
    BuiltinUsersSid = 27,
    BuiltinGuestsSid = 28,
    BuiltinPowerUsersSid = 29,
    BuiltinAccountOperatorsSid = 30,
    BuiltinSystemOperatorsSid = 31,
    BuiltinPrintOperatorsSid = 32,
    BuiltinBackupOperatorsSid = 33,
    BuiltinReplicatorSid = 34,
    BuiltinPreWindows2000CompatibleAccessSid = 35,
    BuiltinRemoteDesktopUsersSid = 36,
    BuiltinNetworkConfigurationOperatorsSid = 37,
    AccountAdministratorSid = 38,
    AccountGuestSid = 39,
    AccountKrbtgtSid = 40,
    AccountDomainAdminsSid = 41,
    AccountDomainUsersSid = 42,
    AccountDomainGuestsSid = 43,
    AccountComputersSid = 44,
    AccountControllersSid = 45,
    AccountCertAdminsSid = 46,
    AccountSchemaAdminsSid = 47,
    AccountEnterpriseAdminsSid = 48,
    AccountPolicyAdminsSid = 49,
    AccountRasAndIasServersSid = 50,
    NtlmAuthenticationSid = 51,
    DigestAuthenticationSid = 52,
    SChannelAuthenticationSid = 53,
    ThisOrganizationSid = 54,
    OtherOrganizationSid = 55,
    BuiltinIncomingForestTrustBuildersSid = 56,
    BuiltinPerformanceMonitoringUsersSid = 57,
    BuiltinPerformanceLoggingUsersSid = 58,
    BuiltinAuthorizationAccessSid = 59,
    MaxDefined = 60,
    WinBuiltinTerminalServerLicenseServersSid = 60,
  }
}
