
namespace AlpineHub.Data.Configurations
{
    using AlpineHub.Data.Models;
    using AlpineHub.Common.Enums;
#nullable disable
    internal class SeedingData
    {
        public SeedingData()
        {
            SeedLiftTypes();
            SeedLifts();
            SeedSlopes();
        }
        public Slope FirstSlope { get; set; }
        public Slope SecondSlope { get; set; }
        public Slope ThirdSlope { get; set; }

        public LiftType GondolaLiftType { get; set; }
        public LiftType ChairliftType { get; set; }
        public LiftType Drag { get; set; }
        public Lift GondolaLift { get; set; }
        public Lift ChairLift { get; set; }
        public Lift SecondChairLift { get; set; }

        private void SeedLiftTypes()
        {
            GondolaLiftType = new()
            {
                Id = Guid.Parse("bcfe0a51-7088-451a-a02d-0c46c9a9ed6b"),
                Name = "Gondola"
            };

            ChairliftType = new()
            {
                Id = Guid.Parse("dde8a2c0-a446-48b1-9da9-f3cb095b1662"),
                Name = "Chairlift"
            };

            Drag = new()
            {
                Id = Guid.Parse("4e238011-8bdb-41a3-b600-c79ca5398077"),
                Name = "Drag"
            };
        }
        private void SeedLifts()
        {
            GondolaLift = new()
            {
                Id = Guid.NewGuid(),
                Name = "Mountain Gondola",
                LiftTypeId = GondolaLiftType.Id,
                Length = 2500,
                VerticalAscend = 400,
                CapacityPerHour = 2000,
                OpenningHour = new TimeOnly(8, 30),
                ClosingHour = new TimeOnly(16, 30),
                AverageAscendTime = 25,
                IsOpen = true,
                NumberOfSeats = 8,
            };

            ChairLift = new()
            {
                Id = Guid.NewGuid(),
                Name = "Spring rider",
                LiftTypeId = ChairliftType.Id,
                Length = 1300,
                VerticalAscend = 300,
                CapacityPerHour = 1300,
                OpenningHour = new TimeOnly(8, 30),
                ClosingHour = new TimeOnly(16, 30),
                AverageAscendTime = 10,
                NumberOfSeats = 6,
                IsOpen = true,
            };

            SecondChairLift = new()
            {
                Id = Guid.NewGuid(),
                Name = "Lakavator",
                LiftTypeId = ChairliftType.Id,
                Length = 1500,
                VerticalAscend = 400,
                CapacityPerHour = 1200,
                OpenningHour = new TimeOnly(8, 45),
                ClosingHour = new TimeOnly(16, 00),
                AverageAscendTime = 12,
                NumberOfSeats = 8,
                IsOpen = false,
            };
        }
        private void SeedSlopes()
        {
            FirstSlope = new()
            {
                Id = Guid.NewGuid(),
                Name = "Wolf ride",
                Difficulty = SlopeDifficulty.Expert,
                Length = 2000,
                UpperPointAltitude = 2200,
                LowerPointAltitude = 1300,
                IsOpen = true,
                SlopeCondition = SlopeCondition.Groomed
            };

            SecondSlope = new()
            {
                Id = Guid.NewGuid(),
                Name = "Rabbit's hole",
                Difficulty = SlopeDifficulty.Intermediate,
                Length = 800,
                UpperPointAltitude = 2000,
                LowerPointAltitude = 1800,
                IsOpen = true,
                SlopeCondition = SlopeCondition.Groomed
            };

            ThirdSlope = new()
            {
                Id = Guid.NewGuid(),
                Name = "Lerner's paradise",
                Difficulty = SlopeDifficulty.Beginner,
                Length = 300,
                UpperPointAltitude = 1450,
                LowerPointAltitude = 1350,
                IsOpen = true,
                SlopeCondition = SlopeCondition.NotGroomed
            };
        }
    }
}
