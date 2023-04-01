namespace AmbiSocial.Domain.Common.Models;

public class ModelConstants
{
    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 32;
        public const int MaxUrlLength = 2048;
        public const int MinDescriptionLength = 5;
        public const int MaxDescriptionLength = 1024;
        public const string AdministratorRoleName = "Administrator";
    }

    public class Identity
    {
        public const int MinEmailLength = 3;
        public const int MaxEmailLength = 64;
        public const int MinPasswordLength = 8;
        public const int MaxPasswordLength = 80;
        public const string DefaultDescription = "Apparently, this user prefers to keep an air of mystery about them";
    }
}