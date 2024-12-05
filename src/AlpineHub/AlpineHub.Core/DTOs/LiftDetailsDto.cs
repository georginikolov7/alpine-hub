

namespace AlpineHub.Core.DTOs
{

    public class LiftDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Length { get; set; }
        public int Capacity { get; set; }
        public int SeatsCount { get; set; }
        public bool IsOpen { get; set; }
        public string WorkingTime { get; set; } = string.Empty;
    }
}
