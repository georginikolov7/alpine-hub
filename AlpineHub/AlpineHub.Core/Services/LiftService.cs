
using Microsoft.EntityFrameworkCore;

using AlpineHub.Core.Contracts.Lift;
using AlpineHub.Core.DTOs;
using AlpineHub.Core.ViewModels.Lift;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;

using static AlpineHub.Common.ErrorMessages;
using static AlpineHub.Common.Formats;

namespace AlpineHub.Core.Services
{
    public class LiftService(IRepo repo) : BaseService(repo), ILiftService, IManageableLiftService
    {
        public async Task<IEnumerable<AllLiftsViewModel>> GetAllLiftsDetailsAsync()
        {
            IEnumerable<AllLiftsViewModel> allLifts = await repo.GetAllReadonly<Lift>()
                .Select(l => new AllLiftsViewModel()
                {
                    Id = l.Id.ToString(),
                    Name = l.Name,
                    AscendTime = l.AverageAscendTime,
                    OpeningHours = string.Format(WorkingHoursFormat, l.OpenningTime.ToShortTimeString(), l.ClosingTime.ToShortTimeString()),
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
            Lift lift = await GetLiftAsync(id);

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
                OpeningHours = string.Format(WorkingHoursFormat, lift.OpenningTime.ToShortTimeString(), lift.ClosingTime.ToShortTimeString()),
                IsOpen = lift.IsOpen && IsLiftOpen(lift),
            };
            return model;
        }

        public async Task<bool> LiftExistsByIdAsync(Guid id)
        {
            return await repo.GetAllReadonly<Lift>().AnyAsync(l => l.Id == id);
        }
        public async Task<IEnumerable<LiftDetailsViewModel>> GetAllLiftsAsync()
        {
            IEnumerable<LiftDetailsViewModel> model = await repo.GetAllReadonly<Lift>()
                .Include(l => l.LiftType)
                .Select(l => new LiftDetailsViewModel()
                {
                    Id = l.Id.ToString(),
                    Name = l.Name,
                    Type = l.LiftType.Name,
                    Length = l.Length,
                    VerticalAscend = l.VerticalAscend,
                    CapacityPerHour = l.CapacityPerHour,
                    AverageRideTime = l.AverageAscendTime,
                    IsOpen = l.IsOpen,
                    NumberOfSeats = l.NumberOfSeats,
                    OpeningHours = string.Format(WorkingHoursFormat, l.OpenningTime.ToShortTimeString(), l.ClosingTime.ToShortTimeString())
                })
                .ToListAsync();

            return model;
        }

        public async Task<EditLiftFormModel> GetLiftForEditAsync(string? id)
        {
            Lift lift = await GetLiftAsync(id);

            EditLiftFormModel model = new EditLiftFormModel()
            {
                Id = lift.Id.ToString(),
                Name = lift.Name,
                Length = lift.Length,
                LiftTypeId = lift.LiftTypeId.ToString(),
                VerticalAscend = lift.VerticalAscend,
                Capacity = lift.CapacityPerHour,
                AverageAscendTime = lift.AverageAscendTime,
                SeatsCount = lift.NumberOfSeats,
                OpenningTime = lift.OpenningTime,
                ClosingTime = lift.ClosingTime,
                IsOpen = lift.IsOpen
            };
            return model;

        }

        public async Task EditLiftAsync(EditLiftFormModel model)
        {
            Lift lift = await GetLiftAsync(model.Id);


            string liftTypeId = model.LiftTypeId;
            if (!IsGuidValid(liftTypeId, out Guid liftTypeGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", liftTypeId));
            }

            LiftType? liftType = await repo.GetByIdAsync<LiftType>(liftTypeGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, liftTypeId));

            lift.Name = model.Name;
            lift.LiftType = liftType;
            lift.Length = model.Length;
            lift.VerticalAscend = model.VerticalAscend;
            lift.CapacityPerHour = model.Capacity;
            lift.AverageAscendTime = model.AverageAscendTime;
            lift.NumberOfSeats = model.SeatsCount;
            lift.OpenningTime = model.OpenningTime;
            lift.ClosingTime = model.ClosingTime;
            lift.IsOpen = model.IsOpen;

            await repo.SaveChangesAsync();
        }

        public async Task<DeleteLiftViewModel> GetLiftForDeleteAsync(string? id)
        {
            Lift lift = await GetLiftAsync(id);

            DeleteLiftViewModel model = new DeleteLiftViewModel()
            {
                Id = lift.Id.ToString(),
                Name = lift.Name
            };
            return model;
        }

        public async Task DeleteLiftAsync(DeleteLiftViewModel model)
        {
            Lift lift = await GetLiftAsync(model.Id);
            repo.Delete(lift);
            await repo.SaveChangesAsync();
        }

        public async Task AddLiftAsync(AddLiftFormModel model)
        {
            string liftTypeId = model.LiftTypeId;
            if (!IsGuidValid(liftTypeId, out Guid liftTypeGuid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", liftTypeId));
            }

            LiftType? liftType = await repo.GetByIdAsync<LiftType>(liftTypeGuid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, liftTypeId));

            Lift lift = new()
            {
                Name = model.Name,
                LiftType = liftType,
                IsOpen = model.IsOpen,
                Length = model.Length,
                AverageAscendTime = model.AverageAscendTime,
                CapacityPerHour = model.Capacity,
                NumberOfSeats = model.SeatsCount,
                VerticalAscend = model.VerticalAscend,
                OpenningTime = model.OpenningTime,
                ClosingTime = model.ClosingTime,
            };

            await repo.AddAsync(lift);
            await repo.SaveChangesAsync();
        }

        

        public async Task<IEnumerable<AllLiftsDto>?> GetAllLiftsForMapAsync()
        {
            return await repo.GetAllReadonly<Lift>()
                .Select(l => new AllLiftsDto()
                {
                    Id = l.Id.ToString(),
                    Name = l.Name,
                })
                .ToListAsync();
        }

        public async Task<LiftDetailsDto> GetLiftDetailsForMapByIdAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", id));
            }

            Lift? lift = await repo.GetAllReadonly<Lift>()
                .Include(l => l.LiftType)
                    .FirstOrDefaultAsync(l => l.Id == guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            LiftDetailsDto dto = new LiftDetailsDto()
            {
                Name = lift.Name,
                Type = lift.LiftType.Name,
                Length = lift.Length,
                Capacity = lift.CapacityPerHour,
                SeatsCount = lift.NumberOfSeats,
                IsOpen = lift.IsOpen,
                WorkingTime = string.Format(WorkingHoursFormat, lift.OpenningTime.ToShortTimeString(), lift.ClosingTime.ToShortTimeString())
            };
            return dto;
        }

        

        private static bool IsLiftOpen(Lift lift)
        {
            var currentTime = TimeOnly.FromDateTime(DateTime.Now);
            return currentTime >= lift.OpenningTime && currentTime <= lift.ClosingTime;
        }

        private async Task<Lift> GetLiftAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", id));
            }

            Lift? lift = await repo
                .GetAll<Lift>()
                .Include(l => l.LiftType)
                .FirstOrDefaultAsync(l => l.Id == guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            return lift;
        }
    }
}
