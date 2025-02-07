using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.PassPeriod
{
    public class DeletePeriodViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}