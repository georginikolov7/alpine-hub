namespace AlpineHub.Core.ViewModels.Slope
{
    public class SlopeDetailsViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Difficulty { get; set; } = string.Empty;
        public string SlopeCondition { get; set; } = null!;
        public bool IsOpen { get; set; }
        public int Length { get; set; }
        public int UpperPointAltitude { get; set; }
        public int LowerPointAltitude { get; set; }
    }
}