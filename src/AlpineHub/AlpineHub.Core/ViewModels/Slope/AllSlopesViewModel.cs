namespace AlpineHub.Core.ViewModels.Slope
{
    public class AllSlopesViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public string SlopeCondition { get; set; } = null!;
        public bool IsOpen { get; set; }
    }
}