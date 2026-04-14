using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.Pass
{
    public class DeletePassViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
