namespace AlpineHub.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AlpineHub.Core.Contracts.Pass;
    using AlpineHub.Core.ViewModels.PassPeriod;
    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;

    using static AlpineHub.Common.ErrorMessages;

    public class PassPeriodService(IRepo repo) : BaseService(repo), IManageablePassPeriodService
    {
        public async Task<IEnumerable<PeriodViewModel>> GetAllPeriods()
        {
            IEnumerable<PeriodViewModel> periods = await repo
                .GetAllReadonly<PassPeriod>()
                .Select(p => new PeriodViewModel
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    ValidFromTime = p.ValidFromHour.ToShortTimeString(),
                    ValidToTime = p.ValidToHour.ToShortTimeString(),
                    DaysCount = p.DaysCount
                })
                .ToListAsync();

            return periods;
        }
        public async Task AddPeriodAsync(AddPeriodFormModel model)
        {
            PassPeriod period = new()
            {
                Name = model.Name,
                ValidFromHour = model.ValidFromHour,
                ValidToHour = model.ValidToHour,
                DaysCount = model.DaysCount
            };

            await repo.AddAsync(period);
            await repo.SaveChangesAsync();

        }

        public async Task<EditPeriodFormModel> GetPeriodForEditAsync(string? id)
        {
            PassPeriod period = await GetPeriod(id);


            EditPeriodFormModel model = new()
            {
                Id = period.Id.ToString(),
                Name = period.Name,
                ValidFromHour = period.ValidFromHour,
                ValidToHour = period.ValidToHour,
                DaysCount = period.DaysCount
            };

            return model;
        }
        public async Task EditPeriodAsync(EditPeriodFormModel model)
        {
            PassPeriod period = await GetPeriod(model.Id);

            period.Name = model.Name;
            period.ValidFromHour = model.ValidFromHour;
            period.ValidToHour = model.ValidToHour;
            period.DaysCount = model.DaysCount;

            await repo.SaveChangesAsync();
        }

        public async Task<DeletePeriodViewModel> GetPeriodForDeleteAsync(string? id)
        {
            PassPeriod period = await GetPeriod(id);
            DeletePeriodViewModel model = new()
            {
                Id = period.Id.ToString(),
                Name = period.Name
            };
            return model;

        }
        public async Task DeletePeriodAsync(DeletePeriodViewModel model)
        {
            PassPeriod period = await GetPeriod(model.Id);

            repo.Delete(period);
            await repo.SaveChangesAsync();
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
