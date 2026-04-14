namespace AlpineHub.Core.ViewModels.Pass
{
    public class AllPassesManageViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string AgeGroup { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
