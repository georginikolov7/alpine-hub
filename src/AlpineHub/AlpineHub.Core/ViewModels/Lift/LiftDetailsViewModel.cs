namespace AlpineHub.Core.ViewModels.Lift
{
    public class LiftDetailsViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Length { get; set; }
        public int VerticalAscend { get; set; }
        public int AverageRideTime { get; set; }    //Average time of lift ride eg 15 minutes
        public int NumberOfSeats { get; set; }
        public int CapacityPerHour { get; set; }
        public bool  IsOpen { get; set; }
        public string OpeningHours { get; set; } = string.Empty; // Example: "8:00 - 17:00"

    }
}
