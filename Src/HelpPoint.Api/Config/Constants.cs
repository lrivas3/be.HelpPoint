namespace HelpPoint.Api.Config;

public static class Constants
{
    public static ConfiguredAppRoles Admin = new ConfiguredAppRoles
    {
        Name           = "Admin",
        Normalizedname = "ADMIN"
    };
    public static ConfiguredAppRoles AreaManager = new ConfiguredAppRoles
    {
        Name           = "AreaManager",
        Normalizedname = "AREAMANAGER"
    };
    public static ConfiguredAppRoles SupportStaff = new ConfiguredAppRoles
    {
        Name           = "SupportStaff",
        Normalizedname = "SUPPORTSTAFF"
    };
}

public class ConfiguredAppRoles
{
    public required string Name { get; set; }
    public required string Normalizedname { get; set; }
}
