using Microsoft.EntityFrameworkCore;

using AlpineHub.Core.Contracts.Lift;
using AlpineHub.Core.ViewModels.LiftType;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;

using static AlpineHub.Common.ErrorMessages;

namespace AlpineHub.Core.Services
{
    public class LiftTypeService(IRepo repo) : BaseService(repo), IManageableLiftTypeService
    {
        public async Task<IEnumerable<DeleteLiftTypeViewModel>?> GetAllLiftTypesAsync()
        {
            IEnumerable<DeleteLiftTypeViewModel> model = await repo.GetAllReadonly<LiftType>()
                .Select(lt => new DeleteLiftTypeViewModel()
                {
                    Id = lt.Id.ToString(),
                    Name = lt.Name
                })
                .ToListAsync();

            return model;
        }
        public async Task AddLiftTypeAsync(AddLiftTypeFormModel model)
        {
            await repo.AddAsync(new LiftType() { Name = model.Name });
            await repo.SaveChangesAsync();
        }
        public async Task<EditLiftTypeFormModel> GetLiftTypeForEditAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", id));
            }
            LiftType liftType = await repo.GetByIdAsync<LiftType>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            return new EditLiftTypeFormModel() { Id = liftType.Id.ToString(), Name = liftType.Name };
        }
        public async Task EditLiftTypeAsync(EditLiftTypeFormModel model)
        {
            if (!IsGuidValid(model.Id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", model.Id));
            }
            LiftType? liftType = await repo.GetByIdAsync<LiftType>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, model.Id));

            liftType.Name = model.Name;
            await repo.SaveChangesAsync();
        }

        public async Task<DeleteLiftTypeViewModel> GetLiftTypeForDeleteAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", id));
            }

            LiftType? liftType = await repo.GetByIdAsync<LiftType>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            DeleteLiftTypeViewModel model = new DeleteLiftTypeViewModel()
            {
                Id = liftType.Id.ToString(),
                Name = liftType.Name
            };
            return model;
        }

        public async Task DeleteLiftTypeAsync(DeleteLiftTypeViewModel model)
        {
            if (!IsGuidValid(model.Id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", model.Id));
            }
            await repo.DeleteByIdAsync<LiftType>(guid);
            await repo.SaveChangesAsync();
        }

    }
}
