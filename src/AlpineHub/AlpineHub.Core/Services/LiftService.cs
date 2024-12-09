
namespace AlpineHub.Core.Services
{
    using System;
    using AlpineHub.Core.Contracts;
    using AlpineHub.Core.DTOs;
    using AlpineHub.Core.ViewModels.Lift;
    using AlpineHub.Core.ViewModels.LiftType;
    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using static AlpineHub.Common.ErrorMessages;
    using static AlpineHub.Common.Formats;
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
                OpeningHours = string.Format(WorkingHoursFormat, lift.OpenningTime.ToShortTimeString(), lift.ClosingTime.ToShortTimeString()),
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
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", id));
            }

            Lift? lift = await repo
                .GetAllReadonly<Lift>()
                .Include(l => l.LiftType)
                .FirstOrDefaultAsync(l => l.Id == guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            EditLiftFormModel model = new EditLiftFormModel()
            {
                Id = lift.Id,
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
            Lift? lift = await repo
                .GetAll<Lift>()
                .Include(l => l.LiftType)
                .FirstOrDefaultAsync(l => l.Id == model.Id)
                ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, model.Id));


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
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", id));
            }

            Lift? lift = await repo.GetByIdAsync<Lift>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            DeleteLiftViewModel model = new DeleteLiftViewModel()
            {
                Id = lift.Id.ToString(),
                Name = lift.Name
            };
            return model;
        }

        public async Task DeleteLiftAsync(DeleteLiftViewModel model)
        {
            if (!IsGuidValid(model.Id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Lift", model.Id));
            }
            await repo.DeleteByIdAsync<Lift>(guid);
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

        public async Task<EditLiftTypeFormModel> GetLiftTypeForEditAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "LiftType", id));
            }
            LiftType liftType = await repo.GetByIdAsync<LiftType>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));

            return new EditLiftTypeFormModel() { Id = liftType.Id.ToString(), Name = liftType.Name };
        }

        public async Task AddLiftTypeAsync(AddLiftTypeFormModel model)
        {
            await repo.AddAsync(new LiftType() { Name = model.Name });
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
    }
}
