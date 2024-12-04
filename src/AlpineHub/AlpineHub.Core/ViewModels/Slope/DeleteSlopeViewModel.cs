using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.Slope
{
    public class DeleteSlopeViewModel : IDeleteViewModel
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
