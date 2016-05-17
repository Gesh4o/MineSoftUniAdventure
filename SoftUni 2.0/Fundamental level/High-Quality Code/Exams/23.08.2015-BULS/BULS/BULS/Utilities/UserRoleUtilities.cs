namespace UniversityLearningSystem.Utilities
{
    using UniversityLearningSystem.Models;

    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }
    }
}
