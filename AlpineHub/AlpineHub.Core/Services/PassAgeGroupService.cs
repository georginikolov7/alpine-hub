using Microsoft.EntityFrameworkCore;

using AlpineHub.Core.Contracts.Pass;
using AlpineHub.Core.ViewModels.PassAgeGroup;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using static AlpineHub.Common.ErrorMessages;

namespace AlpineHub.Core.Services
{
    public class PassAgeGroupService(IRepo repo) : BaseService(repo), IManageablePassAgeService
    {
        public async Task<IEnumerable<AgeGroupViewModel>> GetAllAgeGroupsAsync()
        {
            IEnumerable<AgeGroupViewModel> model = await repo
                .GetAllReadonly<PassAgeGroup>()
                .Select(ag => new AgeGroupViewModel()
                {
                    Id = ag.Id.ToString(),
                    Name = ag.Name,
                    MinAge = ag.MinAge,
                    MaxAge = ag.MaxAge
                })
                .ToListAsync();

            return model;
        }
        public async Task AddAgeGroupAsync(AddAgeGroupFormModel model)
        {
            await repo.AddAsync(new PassAgeGroup
            {
                Name = model.Name,
                MinAge = model.MinAge,
                MaxAge = model.MaxAge
            });
            await repo.SaveChangesAsync();
        }

        public async Task DeleteAgeGroupAsync(DeleteAgeGroupViewModel model)
        {
            PassAgeGroup ageGroup = await GetAgeGroupAsync(model.Id);
            repo.Delete(ageGroup);
            await repo.SaveChangesAsync();
        }

        public async Task EditAgeGroup(EditAgeGroupFormModel model)
        {
            PassAgeGroup ageGroup = await GetAgeGroupAsync(model.Id);
            ageGroup.Name = model.Name;
            ageGroup.MinAge = model.MinAge;
            ageGroup.MaxAge = model.MaxAge;
            await repo.SaveChangesAsync();
        }

        public async Task<DeleteAgeGroupViewModel> GetAgeGroupForDeleteAsync(string? id)
        {
            PassAgeGroup ageGroup = await GetAgeGroupAsync(id);

            DeleteAgeGroupViewModel model = new()
            {
                Id = ageGroup.Id.ToString(),
                Name = ageGroup.Name
            };
            return model;

        }

        public async Task<EditAgeGroupFormModel> GetAgeGroupForEditAsync(string? id)
        {
            PassAgeGroup ageGroup = await GetAgeGroupAsync(id);
            EditAgeGroupFormModel model = new()
            {
                Id = ageGroup.Id.ToString(),
                Name = ageGroup.Name,
                MinAge = ageGroup.MinAge,
                MaxAge = ageGroup.MaxAge
            };
            return model;
        }

        private async Task<PassAgeGroup> GetAgeGroupAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "PassAgeGroup", id));
            }
            PassAgeGroup? ageGroup = await repo.GetByIdAsync<PassAgeGroup>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            return ageGroup;
        }

    }
}
