namespace CompanySystem.Data.Common.Constants
{
    public class ValidationConstants
    {
        // User
        public const int FirstNameMaxLength = 50;
        public const int FirstNameMinLength = 2;
        public const string FirstNameMaxLengthErrorMessage = "First name max length cannot exceed 50 characters.";
        public const string FirstNameMinLengthErrorMessage = "First name min length cannot be less than 2 characters.";

        public const int LastNameMaxLength = 50;
        public const int LastNameMinLength = 2;
        public const string LastNameMaxLengthErrorMessage = "Last name max length cannot exceed 50 characters.";
        public const string LastNameMinLengthErrorMessage = "Last name min length cannot be less than 2 characters.";

        public const int UsernameMaxLength = 50;
        public const int UsernameMinLength = 3;
        public const string UsernameMaxLengthErrorMessage = "Username max length cannot exceed 50 characters.";
        public const string UsernameMinLengthErrorMessage = "Username min length cannot be less than 3 characters.";

        public const int EmailMinLength = 3;
        public const string EmailMinLengthErrorMessage = "Email min length cannot be less than 3 characters.";

        public const int EGNLength = 10;
        public const string EGNLengthErrorMessage = "EGN length must be exactly 10 characters.";

        // City
        public const int CityNameMaxLength = 100;
        public const int CityNameMinLength = 2;
        public const string CityNameMaxLengthErrorMessage = "City name max length cannot exceed 100 characters.";
        public const string CityNameMinLengthErrorMessage = "City name min length cannot be less than 2 characters.";

        // Country
        public const int CountryNameMaxLength = 150;
        public const int CountryNameMinLength = 2;
        public const string CountryNameMaxLengthErrorMessage = "Country name max length cannot exceed 150 characters.";
        public const string CountryNameMinLengthErrorMessage = "Country name min length cannot be less than 2 characters.";
    }
}