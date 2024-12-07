namespace AlpineHub.Core.ViewModels.User
{
    public class AssignableRolesViewModel
    {
        public string UserId { get; set; } = null!;
        public IEnumerable<string?> AssignableRoles { get; set; } = new List<string?>();
    }
}
