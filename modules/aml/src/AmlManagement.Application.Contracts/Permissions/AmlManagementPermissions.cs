using Volo.Abp.Reflection;

namespace AmlManagement.Permissions
{
    public class AmlManagementPermissions
    {
        public const string GroupName = "AmlManagement";
        public static class AmlRemittances
        {
            public const string Default = GroupName + ".AmlRemittance";
            public const string Check = Default + ".Check";

        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AmlManagementPermissions));
        }
    }
}