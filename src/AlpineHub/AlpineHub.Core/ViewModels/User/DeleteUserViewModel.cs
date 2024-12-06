using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.User
{
    public class DeleteUserViewModel : IDeleteViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
