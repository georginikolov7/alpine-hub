namespace AlpineHub.Common
{
    public static class EntityValidationConstraints
    {
        public const string DateTimeFormat = "dd/MM/YYYY";
        //User:
        public const byte UserFirstNameMinLength = 1;
        public const byte UserFirstNameMaxLength = 100;

        public const byte PhoneNumberMinLength = 5;
        public const byte PhoneNumberMaxLength = 15;
        public const string PhoneNumberValidationRegex = $"[0-9]{{5,15}}";

        public const byte UserLastNameMinLength = 1;
        public const byte UserLastNameMaxLength = 100;

        public const byte PasswordMinLength = 8;
        public const byte PasswordMaxLength = 100;

        //Slope:
        public const byte SlopeNameMinLength = 3;
        public const byte SlopeNameMaxLength = 100;

        //Lifts:
        public const byte LiftTypeNameMinLength = 4;
        public const byte LiftTypeNameMaxLength = 20;

        public const byte LiftNameMinLength = 3;
        public const byte LiftNameMaxLength = 64;

        //Pass Period:
        public const byte PassPeriodNameMinLength = 3;
        public const byte PassPeriodNameMaxLength = 20;

        //Pass type:
        public const byte PassTypeNameMinLength = 5;
        public const byte PassTypeNameMaxLength = 32;

        //Pass age group:
        public const byte PassAgeGroupMinLength = 5;
        public const byte PassAgeGroupMaxLength = 30;
    }
}
