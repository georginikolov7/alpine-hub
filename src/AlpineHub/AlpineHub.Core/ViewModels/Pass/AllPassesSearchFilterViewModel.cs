namespace AlpineHub.Core.ViewModels.Pass
{
    public class AllPassesSearchFilterViewModel
    {
        public IEnumerable<AllPassesViewModel>? Passes { get; set; }
        public string? SearchQuery { get; set; }
        public string? AgeFilter { get; set; }
        public string? PeriodFilter { get; set; }
        public int? CurrentPage { get; set; } = 1;
        public int? TotalPasses { get; set; }
        public int PassesPerPage { get; set; } = 4;
        public int? TotalPages { get; set; }
    }
}
