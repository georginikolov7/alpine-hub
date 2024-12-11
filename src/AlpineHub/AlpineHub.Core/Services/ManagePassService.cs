using Microsoft.EntityFrameworkCore;

using AlpineHub.Core.Contracts.Pass;
using AlpineHub.Core.ViewModels.Pass;
using AlpineHub.Core.ViewModels.PassAgeGroup;
using AlpineHub.Core.ViewModels.PassPeriod;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;

using static AlpineHub.Common.ErrorMessages;

namespace AlpineHub.Core.Services
{
    public class ManagePassService(IRepo repo) : BaseService(repo), IManageablePassService
    {
        public async Task<IEnumerable<AllPassesManageViewModel>> GetAllPassesAsync()
        {
            return await repo.GetAllReadonly<Pass>()
                .Include(p => p.PassAgeGroup)
                .Include(p => p.PassPeriod)
                .Select(p => new AllPassesManageViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Description = p.Description,
                    AgeGroup = p.PassAgeGroup.Name,
                    Period = p.PassPeriod.Name,
                    Price = p.Price,
                })
                .ToListAsync();
        }


        public async Task AddPassAsync(AddPassFormModel model)
        {

            PassAgeGroup ageGroup = await GetAgeGroup(model.AgeGroupId);
            PassPeriod period = await GetPeriod(model.PeriodId);

            Pass pass = new()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                PassPeriod = period,
                PassAgeGroup = ageGroup,
                IsDeleted = false
            };

            await repo.AddAsync(pass);
            await repo.SaveChangesAsync();
        }

        public async Task<EditPassFormModel> GetPassForEditAsync(string? id)
        {
            Pass pass = await GetPass(id);
            EditPassFormModel model = new()
            {
                Id = pass.Id.ToString(),
                Name = pass.Name,
                Description = pass.Description,
                PeriodId = pass.PassPeriod.Id.ToString(),
                AgeGroupId = pass.PassAgeGroup.Id.ToString(),
            };
            return model;
        }

        public async Task EditPassAsync(EditPassFormModel model)
        {
            Pass pass = await GetPass(model.Id);
            PassAgeGroup AgeGroup = await GetAgeGroup(model.AgeGroupId);
            PassPeriod Period = await GetPeriod(model.PeriodId);

            pass.Name = model.Name;
            pass.Description = model.Description;
            pass.PassAgeGroup = AgeGroup;
            pass.PassPeriod = Period;
            pass.Price = model.Price;
            await repo.SaveChangesAsync();
        }

        public async Task<DeletePassViewModel> GetPassForDeleteAsync(string? id)
        {
            Pass pass = await GetPass(id);
            DeletePassViewModel model = new()
            {
                Id = pass.Id.ToString(),
                Name = pass.Name
            };
            return model;
        }

        public async Task DeletePassAsync(DeletePassViewModel model)
        {
            Pass pass = await GetPass(model.Id);
            repo.Delete(pass);
            await repo.SaveChangesAsync();
        }


        public async Task<IEnumerable<PeriodListViewModel>> GetAllPeriodsListAsync()
        {
            return await repo.GetAllReadonly<PassPeriod>()
                .Select(p => new PeriodListViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AgeGroupListViewModel>> GetAllAgeGroupsListAsync()
        {
            return await repo.GetAllReadonly<PassAgeGroup>()
                .Select(p => new AgeGroupListViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name
                })
                .ToListAsync();
        }
        private async Task<Pass> GetPass(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Pass", id));
            }

            Pass? pass = await repo
                .GetAll<Pass>()
                .Include(p => p.PassPeriod)
                .Include(p => p.PassAgeGroup)
                .FirstOrDefaultAsync(p => p.Id == guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            return pass;
        }
        private async Task<PassAgeGroup> GetAgeGroup(string? id)
        {
            if (!IsGuidValid(id, out Guid ageGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Age group", id));
            }
            PassAgeGroup? ageGroup = await repo
               .GetByIdAsync<PassAgeGroup>(ageGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            return ageGroup;
        }
        private async Task<PassPeriod> GetPeriod(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "PassPeriod", id));
            }

            PassPeriod? period = await repo.GetByIdAsync<PassPeriod>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            return period;
        }
    }
}
