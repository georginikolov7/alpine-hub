using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.Slope
{
    public class DeleteSlopeViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}