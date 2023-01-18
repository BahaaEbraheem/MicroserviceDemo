namespace AmlManagement
{
    public static class AmlManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "App";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AmlManagement";
        public const int MaxLength = 1000000000;
    }
}
