namespace AlpineHub.Common
{
    public static class ErrorMessages
    {
        public const string InvalidId = "{0} guid {1} invalid";
        public const string EntityWithIdNotFound = "Entity with given id {0} not found.";

        public const string ServiceError = "Service for {0} cannot be obtained";
        public const string CannotCreateRole = "Cannot create role {0}";
        public const string CannotCreateUser = "Cannot create user {0}";
        public const string CannotAddUserToRole = "Cannot add user {0} to role {1}";
        public const string CannotDeleteAdmin = "Cannot delete admin user";
        public const string UnexpectedError = "Unexpected error occurred. Please try again later or contact administrator.";
        public const string UserNotFound = "User with id {0} not found";
        public const string CartNotFound = "Cart for user with id {0} not found";


    }
}
