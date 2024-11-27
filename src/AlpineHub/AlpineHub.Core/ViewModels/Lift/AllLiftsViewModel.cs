namespace AlpineHub.Core.ViewModels.Lift
{
    public class AllLiftsViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;// Example: Chairlift, Gondola, etc.
        public bool IsOpen { get; set; }
        public int AscendTime { get; set; } // Time in minutes
        public string OpeningHours { get; set; } = string.Empty; // Example: "8:00 AM - 5:00 PM"
    }
}
