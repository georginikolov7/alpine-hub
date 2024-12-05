namespace AlpineHub.Core.DTOs
{
    public class SlopeDetailsDto
    {
        public string Difficulty { get; set; } = string.Empty;
        public int Length { get; set; }
        public string Condition { get; set; } = string.Empty;
        public int TopElevation { get; set; }
        public int BottomElevation { get; set; }
        public bool IsOpen { get; set; }
    }
}
