using AlpineHub.Core.ViewModels.PassAgeGroup;

namespace AlpineHub.Core.Contracts.Pass
{
    public interface IManageablePassAgeService
    {
        Task<IEnumerable<AgeGroupViewModel>> GetAllAgeGroupsAsync();
        Task AddAgeGroupAsync(AddAgeGroupFormModel model);
        Task<EditAgeGroupFormModel> GetAgeGroupForEditAsync(string? id);
        Task EditAgeGroup(EditAgeGroupFormModel model);
        Task<DeleteAgeGroupViewModel> GetAgeGroupForDeleteAsync(string? id);
        Task DeleteAgeGroupAsync(DeleteAgeGroupViewModel model);
    }
}
