
namespace AlpineHub.Core.Services
{
    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.ViewModels.Lift;
    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Reflection.Metadata.Ecma335;
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
                    OpeningHours = string.Format(OpenningHoursFormat, l.OpenningTime.ToShortTimeString(), l.ClosingTime.ToShortTimeString()),
                    IsOpen = l.IsOpen && IsLiftOpen(l),
                    Type = l.LiftType.Name
                })
                .ToListAsync();

            return allLifts;
        }
        public async Task<int> GetNumberOfOpenLiftsAsync()
        {
            return (await repo.GetAllReadonly<Lift>().ToListAsync()).Count(l => l.IsOpen && IsLiftOpen(l));
        }

        public async Task<int> GetTotalNumberOfLiftsAsync()
        {
            return await repo.GetAllReadonly<Lift>().CountAsync();
        }
        public async Task<LiftDetailsViewModel?> GetLiftByIdAsync(string id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                return null;
            }

            Lift? lift = await repo.GetAllReadonly<Lift>()
                .Include(l => l.LiftType)
                .FirstOrDefaultAsync(l => l.Id == guid);

            if (lift is null)
            {
                return null;
            }

            LiftDetailsViewModel model = new LiftDetailsViewModel()
            {
                Id = lift.Id.ToString(),
                Name = lift.Name,
                Type = lift.LiftType.Name,
                CapacityPerHour = lift.CapacityPerHour,
                Length = lift.Length,
                NumberOfSeats = lift.NumberOfSeats,
                VerticalAscend = lift.VerticalAscend,
                AverageRideTime = lift.AverageAscendTime,
                OpeningHours = string.Format(OpenningHoursFormat, lift.OpenningTime.ToShortTimeString(), lift.ClosingTime.ToShortTimeString()),
                IsOpen = lift.IsOpen && IsLiftOpen(lift),
            };
            return model;
        }

        public async Task<bool> LiftExistsByIdAsync(Guid id)
        {
            return await repo.GetAllReadonly<Lift>().AnyAsync(l => l.Id == id);
        }
        private static bool IsLiftOpen(Lift lift)
        {
            var currentTime = TimeOnly.FromDateTime(DateTime.Now);
            return currentTime >= lift.OpenningTime && currentTime <= lift.ClosingTime;
        }

    }
}
