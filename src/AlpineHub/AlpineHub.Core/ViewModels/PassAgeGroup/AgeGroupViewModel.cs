namespace AlpineHub.Core.ViewModels.PassAgeGroup
{
    public class AgeGroupViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}
