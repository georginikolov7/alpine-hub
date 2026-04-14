using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.Lift
{
    public class DeleteLiftViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
