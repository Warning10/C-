using System;

namespace Assignment_5
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4
    }

    public static class PermissionsExtensions
    {
        public static bool HasPermission(this Permissions permissions, Permissions permissionToCheck)
        {
            return (permissions & permissionToCheck) == permissionToCheck;
        }
    }
}
