using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.User
{
    public class DeleteUserViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}