using AlpineHub.Core.Contracts;
using AlpineHub.Core.ViewModels.Pass;
using AlpineHub.Data.Contracts;
using AlpineHub.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlpineHub.Core.Services
{
    public class PassService(IRepo repo) : BaseService(repo), IPassService
    {
        public async Task<IEnumerable<string>> GetAllAgeGroupsAsync()
        {
            IEnumerable<string> ageGroups = await repo
                .GetAllReadonly<PassAgeGroup>()
                .Select(ag => ag.Name)
                .ToListAsync();

            return ageGroups;
        }

        public async Task<IEnumerable<string>> GetAllPeriodsAsync()
        {
            IEnumerable<string> periods = await repo
                .GetAllReadonly<PassPeriod>()
                .Select(p => p.Name)
                .ToListAsync();
            return periods;
        }

        public async Task<AllPassesSearchFilterViewModel> GetAllPasses(AllPassesSearchFilterViewModel inputModel)
        {
            IQueryable<Pass> passesQuery = repo.GetAllReadonly<Pass>()
                .Include(p => p.PassAgeGroup)
                .Include(p => p.PassPeriod);

            if (!string.IsNullOrWhiteSpace(inputModel.SearchQuery))
            {
                passesQuery = passesQuery.Where(p => p.Name.ToLower().Contains(inputModel.SearchQuery.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(inputModel.AgeFilter))
            {
                passesQuery = passesQuery.Where(p => p.PassAgeGroup.Name.ToLower() == inputModel.AgeFilter.ToLower());
            }

            if (!string.IsNullOrWhiteSpace(inputModel.PeriodFilter))
            {
                passesQuery = passesQuery.Where(p => p.PassPeriod.Name.ToLower() == inputModel.PeriodFilter.ToLower());
            }


            IEnumerable<AllPassesViewModel> passes = await passesQuery
            .Select(p => new AllPassesViewModel()
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                AgeGroup = p.PassAgeGroup.Name,
                Period = p.PassPeriod.Name,
                Price = p.Price,
                Quantity = 1
            })
            .ToListAsync();

            int totalPassCount = passes.Count();

            if (inputModel.CurrentPage.HasValue)
            {
                passes = passes
                    .Skip((inputModel.CurrentPage.Value - 1) * inputModel.PassesPerPage)
                    .Take(inputModel.PassesPerPage);
            }

            int totalPages = (int)Math.Ceiling((double)totalPassCount / inputModel.PassesPerPage);
            AllPassesSearchFilterViewModel result = new AllPassesSearchFilterViewModel()
            {
                Passes = passes,
                SearchQuery = inputModel.SearchQuery,
                AgeFilter = inputModel.AgeFilter,
                PeriodFilter = inputModel.PeriodFilter,
                CurrentPage = inputModel.CurrentPage,
                TotalPasses = totalPassCount,
                PassesPerPage = inputModel.PassesPerPage,
                TotalPages = totalPages
            };
            return result;

        }

        public Task AddToCart(string? passId, string? userId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
