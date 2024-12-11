namespace AlpineHub.Core.ViewModels.PassPeriod
{
    public class PeriodViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ValidFromTime { get; set; } = string.Empty;
        public string ValidToTime { get; set; } = string.Empty;
        public int DaysCount { get; set; }
    }
}
