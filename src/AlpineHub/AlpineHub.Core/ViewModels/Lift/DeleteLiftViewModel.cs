using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.Lift
{
    public class DeleteLiftViewModel : IDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
