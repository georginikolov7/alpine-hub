using AlpineHub.Core.Contracts;

namespace AlpineHub.Core.ViewModels.LiftType
{
    public class DeleteLiftTypeViewModel : IDeleteViewModel 
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
