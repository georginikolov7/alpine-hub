
namespace AlpineHub.Core.Services
{
    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.ViewModels.Lift;
    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static AlpineHub.Common.Formats;
    public class LiftService(IRepo repo) : BaseService(repo), ILiftService
    {
        public async Task<IEnumerable<AllLiftsViewModel>> GetAllLifts()
        {
            IEnumerable<AllLiftsViewModel> allLifts = await repo.GetAllReadonly<Lift>()
                .Select(l => new AllLiftsViewModel()
                {
                    Id = l.Id.ToString(),
                    Name = l.Name,
                    AscendTime = l.AverageAscendTime,
                    OpeningHours = string.Format(OpenningHoursFormat, l.OpenningHour.ToShortTimeString(), l.ClosingHour.ToShortTimeString()),
                    IsOpen = l.IsOpen,
                    Type = l.LiftType.Name
                })
                .ToListAsync();

            return allLifts;
        }

        public async Task<int> GetNumberOfOpenLifts()
        {
            return await repo.GetAllReadonly<Lift>().CountAsync(l => l.IsOpen);
        }

        public async Task<int> GetTotalNumberOfLifts()
        {
            return await repo.GetAllReadonly<Lift>().CountAsync();
        }
    }
}
