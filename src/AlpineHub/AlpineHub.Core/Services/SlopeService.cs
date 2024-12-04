using AlpineHub.Core.Contracts;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using AlpineHub.Core.ViewModels.Slope;
using Microsoft.EntityFrameworkCore;
using static AlpineHub.Common.ErrorMessages;
using System;
namespace AlpineHub.Core.Services
{
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
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException("Invalid slope id");
            }
            Slope? slope = await repo.GetByIdAsync<Slope>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, guid));

            EditSlopeFormModel model = new EditSlopeFormModel()
            {
                Id = slope.Id,
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
            Slope? slope = await repo.GetByIdAsync<Slope>(model.Id) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, model.Id));

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
            if (!IsGuidValid(id, out Guid guid))
            {
                throw new ArgumentException(string.Format(InvalidId, "Slope"));
            }

            Slope slope = await repo.GetByIdAsync<Slope>(guid) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, guid));
            DeleteSlopeViewModel model = new DeleteSlopeViewModel()
            {
                Id = slope.Id,
                Name = slope.Name,
            };
            return model;
        }

        public async Task DeleteSlopeAsync(DeleteSlopeViewModel model)
        {
            Guid id = model.Id;
            Slope slope = await repo.GetByIdAsync<Slope>(id) ?? throw new ArgumentException(string.Format(EntityWithIdNotFound, id));
            repo.Delete<Slope>(slope);
            await repo.SaveChangesAsync();
        }


    }
}
