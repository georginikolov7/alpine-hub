
namespace AlpineHub.Core.ViewModels.PassAgeGroup
{
    using AlpineHub.Core.Contracts;
    public class DeleteAgeGroupViewModel : IDeleteViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
