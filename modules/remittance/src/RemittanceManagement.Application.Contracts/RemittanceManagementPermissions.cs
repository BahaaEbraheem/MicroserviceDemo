using Volo.Abp.Reflection;

namespace RemittanceManagement;

public class RemittanceManagementPermissions
{

    public const string GroupName = "RemittanceManagement";
    public static class Remittances
    {
        public const string Default = GroupName + ".Remittance";
        public const string Delete = Default + ".Delete";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Approved = Default + ".Approved";
        public const string Released = Default + ".Released";
        public const string Ready = Default + ".Ready";
        
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(RemittanceManagementPermissions));
    }
}
