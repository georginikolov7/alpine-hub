
namespace AlpineHub.Core.Services
{
    using Microsoft.EntityFrameworkCore;

    using AlpineHub.Data.Contracts;
    using AlpineHub.Data.Models;
    using AlpineHub.Core.ViewModels.Slope;
    using AlpineHub.Core.DTOs;
    using AlpineHub.Core.Contracts.Slope;

    using static AlpineHub.Common.ErrorMessages;

    public class SlopeService(IRepo repo) : BaseService(repo), ISlopeService, IManageableSlopeService
    {
        public async Task<IEnumerable<AllSlopesViewModel>> GetAllSlopesAsync()
        {
            IEnumerable<AllSlopesViewModel> slopes = await repo.GetAllReadonly<Slope>()
                .Select(s => new AllSlopesViewModel()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Difficulty = s.Difficulty.ToString(),
                    SlopeCondition = s.SlopeCondition.ToString(),
                    IsOpen = s.IsOpen,
                }).ToListAsync();

            return slopes;
        }
        public async Task<int> GetNumberOfOpenSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync(s => s.IsOpen);
        }

        public async Task<int> GetTotalNumberOfSlopesAsync()
        {
            return await repo.GetAllReadonly<Slope>().CountAsync();
        }
        public async Task<bool> SlopeExistsByIdAsync(Guid slopeId)
        {
            return await repo.GetAllReadonly<Slope>().AnyAsync(s => s.Id == slopeId);
        }
        public async Task<SlopeDetailsViewModel?> GetSlopeByIdAsync(string? slopeId)
        {
            if (!IsGuidValid(slopeId, out Guid guid))
            {
                return null;
            }

            var slope = await repo.GetByIdAsync<Slope>(guid);
            if (slope == null)
            {
                return null;
            }

            SlopeDetailsViewModel model = new SlopeDetailsViewModel()
            {
                Id = slope.Id.ToString(),
                Name = slope.Name,
                Difficulty = slope.Difficulty.ToString(),
                SlopeCondition = slope.SlopeCondition.ToString(),
                IsOpen = slope.IsOpen,
                Length = slope.Length,
                UpperPointAltitude = slope.UpperPointAltitude,
                LowerPointAltitude = slope.LowerPointAltitude,
            };

            return model; //evala goshe
        }

        //Manager:
        public async Task AddSlopeAsync(AddSlopeFormModel model)
        {
            Slope slope = new Slope()
            {
                Name = model.Name,
                Difficulty = model.Difficulty,
                SlopeCondition = model.SlopeCondition,
                IsOpen = model.IsOpen,
                Length = model.Length,
                UpperPointAltitude = model.UpperPointAltitude,
                LowerPointAltitude = model.LowerPointAltitude,
            };
            await repo.AddAsync<Slope>(slope);
            await repo.SaveChangesAsync();
        }
        public async Task<IEnumerable<SlopeDetailsViewModel>> GetAllManagerSlopesAsync()
        {
            IEnumerable<SlopeDetailsViewModel> slopes = await repo
                .GetAllReadonly<Slope>()
                .Select(s =>
                new SlopeDetailsViewModel()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Length = s.Length,
                    Difficulty = s.Difficulty.ToString(),
                    SlopeCondition = s.SlopeCondition.ToString(),
                    IsOpen = s.IsOpen,
                    UpperPointAltitude = s.UpperPointAltitude,
                    LowerPointAltitude = s.LowerPointAltitude,
                })
                .ToListAsync();

            return slopes;
        }

        public async Task<EditSlopeFormModel> GetSlopeForEditAsync(string? id)
        {

            Slope slope = await GetSlopeAsync(id);

            EditSlopeFormModel model = new EditSlopeFormModel()
            {
                Id = slope.Id.ToString(),
                Name = slope.Name,
                Difficulty = slope.Difficulty,
                SlopeCondition = slope.SlopeCondition,
                IsOpen = slope.IsOpen,
                Length = slope.Length,
                UpperPointAltitude = slope.UpperPointAltitude,
                LowerPointAltitude = slope.LowerPointAltitude,
            };
            return model;

        }

        public async Task EditSlopeAsync(EditSlopeFormModel model)
        {
            Slope slope = await GetSlopeAsync(model.Id);

            slope.Name = model.Name;
            slope.Difficulty = model.Difficulty;
            slope.SlopeCondition = model.SlopeCondition;
            slope.IsOpen = model.IsOpen;
            slope.Length = model.Length;
            slope.UpperPointAltitude = model.UpperPointAltitude;
            slope.LowerPointAltitude = model.LowerPointAltitude;

            await repo.SaveChangesAsync();
        }

        public async Task<DeleteSlopeViewModel> GetSlopeForDeleteAsync(string? id)
        {
            Slope slope = await GetSlopeAsync(id);

            DeleteSlopeViewModel model = new DeleteSlopeViewModel()
            {
                Id = slope.Id.ToString(),
                Name = slope.Name,
            };
            return model;
        }

        public async Task DeleteSlopeAsync(DeleteSlopeViewModel model)
        {
            Slope slope = await GetSlopeAsync(model.Id);

            repo.Delete<Slope>(slope);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllSlopesDto>?> GetAllSlopesForMapAsync()
        {
            IEnumerable<AllSlopesDto> allSlopes = await repo.GetAllReadonly<Slope>()
                .Select(s => new AllSlopesDto()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    Difficulty = s.Difficulty.ToString(),

                }).ToListAsync();

            return allSlopes;
        }

        public async Task<SlopeDetailsDto> GetSlopeDetailsForMapAsync(string? id)
        {
            Slope slope = await GetSlopeAsync(id);

            SlopeDetailsDto model = new SlopeDetailsDto()
            {

                Difficulty = slope.Difficulty.ToString(),
                Condition = slope.SlopeCondition.ToString(),
                IsOpen = slope.IsOpen,
                Length = slope.Length,
                TopElevation = slope.UpperPointAltitude,
                BottomElevation = slope.LowerPointAltitude,
            };
            return model;
        }
        private async Task<Slope> GetSlopeAsync(string? id)
        {
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Slope", id));
            }
            Slope? slope = await repo.GetByIdAsync<Slope>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, guid));
            return slope;
        }
    }
}
