namespace BuhtigIssueTracker.Utilities
{
    public static class Constants
    {
        public const string AlreadyLoggedUserWarning = "There is already a logged in user";

        public const string PasswordDoNotMatchWarning = "The provided passwords do not match";

        public const string UsernameAlreadyExistWarning = "A user with username {0} already exists";

        public const string RegistrationSuccessfulMessage = "User {0} registered successfully";

        public const string UserDoesNotExistWarning = "A user with username {0} does not exist";

        public const string InvalidPasswordWarning = "The password is invalid for user {0}";

        public const string SuccessfulLogInMessage = "User {0} logged in successfully";

        public const string SuccessfulLogOutMessage = "User {0} logged out successfully";

        public const string SuccessfullIssueCreationMessage = "Issue {0} created successfully";

        public const string NoIssueFoundWarning = "There is no issue with ID {0}";

        public const string NotYourIssueWarning = "The issue with ID {0} does not belong to user {1}";

        public const string SuccessfullyRemovedIssueMessage = "Issue {0} removed";

        public const string SuccessfullyAddedComment = "Comment added successfully to issue {0}";

        public const string NoIssuesFoundWarning = "No issues";

        public const string NoCommentsFound = "No comments"; // No comment for this "constants".

        public const string NoTagsWarning = "There are no tags provided";

        public const string NoMatchingTagsWarning = "There are no issues matching the tags provided";

        public const string CurrentlyNoLoggedUser = "There is no currently logged in user";
    }
}
