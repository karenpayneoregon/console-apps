#nullable disable
namespace ComputerDetails.Models;

/// <summary>
/// Get-ComputerInfo | ConvertTo-Json
/// </summary>
public class MachineComputerInformation
{
    public string WindowsBuildLabEx { get; set; }
    public string WindowsCurrentVersion { get; set; }
    public string WindowsEditionId { get; set; }
    public string WindowsInstallationType { get; set; }
    public DateTime WindowsInstallDateFromRegistry { get; set; }
    public string WindowsProductId { get; set; }
    public string WindowsProductName { get; set; }
    public string WindowsRegisteredOrganization { get; set; }
    public string WindowsRegisteredOwner { get; set; }
    public string WindowsSystemRoot { get; set; }
    public string WindowsVersion { get; set; }
    public int[] BiosCharacteristics { get; set; }
    public string[] BiosBIOSVersion { get; set; }
    public object BiosBuildNumber { get; set; }
    public string BiosCaption { get; set; }
    public object BiosCodeSet { get; set; }
    public string BiosCurrentLanguage { get; set; }
    public string BiosDescription { get; set; }
    public int BiosEmbeddedControllerMajorVersion { get; set; }
    public int BiosEmbeddedControllerMinorVersion { get; set; }
    public int BiosFirmwareType { get; set; }
    public object BiosIdentificationCode { get; set; }
    public int BiosInstallableLanguages { get; set; }
    public object BiosInstallDate { get; set; }
    public object BiosLanguageEdition { get; set; }
    public string[] BiosListOfLanguages { get; set; }
    public string BiosManufacturer { get; set; }
    public string BiosName { get; set; }
    public object BiosOtherTargetOS { get; set; }
    public bool BiosPrimaryBIOS { get; set; }
    public DateTime BiosReleaseDate { get; set; }
    public string BiosSeralNumber { get; set; }
    public string BiosSMBIOSBIOSVersion { get; set; }
    public int BiosSMBIOSMajorVersion { get; set; }
    public int BiosSMBIOSMinorVersion { get; set; }
    public bool BiosSMBIOSPresent { get; set; }
    public int BiosSoftwareElementState { get; set; }
    public string BiosStatus { get; set; }
    public int BiosSystemBiosMajorVersion { get; set; }
    public int BiosSystemBiosMinorVersion { get; set; }
    public int BiosTargetOperatingSystem { get; set; }
    public string BiosVersion { get; set; }
    public int CsAdminPasswordStatus { get; set; }
    public bool CsAutomaticManagedPagefile { get; set; }
    public bool CsAutomaticResetBootOption { get; set; }
    public bool CsAutomaticResetCapability { get; set; }
    public object CsBootOptionOnLimit { get; set; }
    public object CsBootOptionOnWatchDog { get; set; }
    public bool CsBootROMSupported { get; set; }
    public int[] CsBootStatus { get; set; }
    public string CsBootupState { get; set; }
    public string CsCaption { get; set; }
    public int CsChassisBootupState { get; set; }
    public string CsChassisSKUNumber { get; set; }
    public int CsCurrentTimeZone { get; set; }
    public bool CsDaylightInEffect { get; set; }
    public string CsDescription { get; set; }
    public string CsDNSHostName { get; set; }
    public string CsDomain { get; set; }
    public int CsDomainRole { get; set; }
    public bool CsEnableDaylightSavingsTime { get; set; }
    public int CsFrontPanelResetStatus { get; set; }
    public bool CsHypervisorPresent { get; set; }
    public bool CsInfraredSupported { get; set; }
    public object CsInitialLoadInfo { get; set; }
    public object CsInstallDate { get; set; }
    public int CsKeyboardPasswordStatus { get; set; }
    public object CsLastLoadInfo { get; set; }
    public string CsManufacturer { get; set; }
    public string CsModel { get; set; }
    public string CsName { get; set; }
    public Csnetworkadapter[] CsNetworkAdapters { get; set; }
    public bool CsNetworkServerModeEnabled { get; set; }
    public int CsNumberOfLogicalProcessors { get; set; }
    public int CsNumberOfProcessors { get; set; }
    public Csprocessor[] CsProcessors { get; set; }
    public string[] CsOEMStringArray { get; set; }
    public bool CsPartOfDomain { get; set; }
    public int CsPauseAfterReset { get; set; }
    public int CsPCSystemType { get; set; }
    public int CsPCSystemTypeEx { get; set; }
    public object CsPowerManagementCapabilities { get; set; }
    public object CsPowerManagementSupported { get; set; }
    public int CsPowerOnPasswordStatus { get; set; }
    public int CsPowerState { get; set; }
    public int CsPowerSupplyState { get; set; }
    public object CsPrimaryOwnerContact { get; set; }
    public string CsPrimaryOwnerName { get; set; }
    public int CsResetCapability { get; set; }
    public int CsResetCount { get; set; }
    public int CsResetLimit { get; set; }
    public string[] CsRoles { get; set; }
    public string CsStatus { get; set; }
    public object CsSupportContactDescription { get; set; }
    public string CsSystemFamily { get; set; }
    public string CsSystemSKUNumber { get; set; }
    public string CsSystemType { get; set; }
    public int CsThermalState { get; set; }
    public long CsTotalPhysicalMemory { get; set; }
    public int CsPhyicallyInstalledMemory { get; set; }
    public string CsUserName { get; set; }
    public int CsWakeUpType { get; set; }
    public object CsWorkgroup { get; set; }
    public string OsName { get; set; }
    public int OsType { get; set; }
    public int OsOperatingSystemSKU { get; set; }
    public string OsVersion { get; set; }
    public object OsCSDVersion { get; set; }
    public string OsBuildNumber { get; set; }
    public Oshotfix[] OsHotFixes { get; set; }
    public string OsBootDevice { get; set; }
    public string OsSystemDevice { get; set; }
    public string OsSystemDirectory { get; set; }
    public string OsSystemDrive { get; set; }
    public string OsWindowsDirectory { get; set; }
    public string OsCountryCode { get; set; }
    public int OsCurrentTimeZone { get; set; }
    public string OsLocaleID { get; set; }
    public string OsLocale { get; set; }
    public DateTime OsLocalDateTime { get; set; }
    public DateTime OsLastBootUpTime { get; set; }
    public Osuptime OsUptime { get; set; }
    public string OsBuildType { get; set; }
    public string OsCodeSet { get; set; }
    public bool OsDataExecutionPreventionAvailable { get; set; }
    public bool OsDataExecutionPrevention32BitApplications { get; set; }
    public bool OsDataExecutionPreventionDrivers { get; set; }
    public int OsDataExecutionPreventionSupportPolicy { get; set; }
    public bool OsDebug { get; set; }
    public bool OsDistributed { get; set; }
    public int OsEncryptionLevel { get; set; }
    public int OsForegroundApplicationBoost { get; set; }
    public int OsTotalVisibleMemorySize { get; set; }
    public int OsFreePhysicalMemory { get; set; }
    public int OsTotalVirtualMemorySize { get; set; }
    public int OsFreeVirtualMemory { get; set; }
    public int OsInUseVirtualMemory { get; set; }
    public object OsTotalSwapSpaceSize { get; set; }
    public int OsSizeStoredInPagingFiles { get; set; }
    public int OsFreeSpaceInPagingFiles { get; set; }
    public string[] OsPagingFiles { get; set; }
    public string OsHardwareAbstractionLayer { get; set; }
    public DateTime OsInstallDate { get; set; }
    public string OsManufacturer { get; set; }
    public long OsMaxNumberOfProcesses { get; set; }
    public long OsMaxProcessMemorySize { get; set; }
    public string[] OsMuiLanguages { get; set; }
    public object OsNumberOfLicensedUsers { get; set; }
    public int OsNumberOfProcesses { get; set; }
    public int OsNumberOfUsers { get; set; }
    public string OsOrganization { get; set; }
    public string OsArchitecture { get; set; }
    public string OsLanguage { get; set; }
    public int[] OsProductSuites { get; set; }
    public object OsOtherTypeDescription { get; set; }
    public object OsPAEEnabled { get; set; }
    public bool OsPortableOperatingSystem { get; set; }
    public bool OsPrimary { get; set; }
    public int OsProductType { get; set; }
    public string OsRegisteredUser { get; set; }
    public string OsSerialNumber { get; set; }
    public int OsServicePackMajorVersion { get; set; }
    public int OsServicePackMinorVersion { get; set; }
    public string OsStatus { get; set; }
    public int[] OsSuites { get; set; }
    public object OsServerLevel { get; set; }
    public string KeyboardLayout { get; set; }
    public string TimeZone { get; set; }
    public string LogonServer { get; set; }
    public int PowerPlatformRole { get; set; }
    public bool HyperVisorPresent { get; set; }
    public object HyperVRequirementDataExecutionPreventionAvailable { get; set; }
    public object HyperVRequirementSecondLevelAddressTranslation { get; set; }
    public object HyperVRequirementVirtualizationFirmwareEnabled { get; set; }
    public object HyperVRequirementVMMonitorModeExtensions { get; set; }
    public int DeviceGuardSmartStatus { get; set; }
    public int[] DeviceGuardRequiredSecurityProperties { get; set; }
    public int[] DeviceGuardAvailableSecurityProperties { get; set; }
    public int[] DeviceGuardSecurityServicesConfigured { get; set; }
    public int[] DeviceGuardSecurityServicesRunning { get; set; }
    public object DeviceGuardCodeIntegrityPolicyEnforcementStatus { get; set; }
    public object DeviceGuardUserModeCodeIntegrityPolicyEnforcementStatus { get; set; }

    public override string ToString()
    {
        return $"{WindowsRegisteredOwner}";
    }
}

public class Osuptime
{
    public long Ticks { get; set; }
    public int Days { get; set; }
    public int Hours { get; set; }
    public int Milliseconds { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }
    public float TotalDays { get; set; }
    public float TotalHours { get; set; }
    public float TotalMilliseconds { get; set; }
    public float TotalMinutes { get; set; }
    public float TotalSeconds { get; set; }
    public override string ToString() => $"{Hours} hours {Minutes} minutes {Days} days";

}

public class Csnetworkadapter
{
    public string Description { get; set; }
    public string ConnectionID { get; set; }
    public bool? DHCPEnabled { get; set; }
    public string DHCPServer { get; set; }
    public int ConnectionStatus { get; set; }
    public string IPAddresses { get; set; }
}

public class Csprocessor
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public int Architecture { get; set; }
    public int AddressWidth { get; set; }
    public int DataWidth { get; set; }
    public int MaxClockSpeed { get; set; }
    public int CurrentClockSpeed { get; set; }
    public int NumberOfCores { get; set; }
    public int NumberOfLogicalProcessors { get; set; }
    public string ProcessorID { get; set; }
    public string SocketDesignation { get; set; }
    public int ProcessorType { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
    public int CpuStatus { get; set; }
    public int Availability { get; set; }
}

public class Oshotfix
{
    public string HotFixID { get; set; }
    public string Description { get; set; }
    public DateTime InstalledOn { get; set; }
    public string FixComments { get; set; }
}