using AlpineHub.Data.Models;
using AlpineHub.Common.Enums;
using Microsoft.AspNetCore.Identity;

namespace AlpineHub.Data.Configurations
{
#nullable disable
    internal class SeedingData
    {
        public SeedingData()
        {
            SeedLiftTypes();
            SeedLifts();
            SeedSlopes();
            SeedPassAges();
            SeedPassPeriods();
            SeedPasses();
            SeedUsers();
        }



        public Slope FirstSlope { get; set; }
        public Slope SecondSlope { get; set; }
        public Slope ThirdSlope { get; set; }
        public Slope FourthSlope { get; set; }
        public Slope FifthSlope { get; set; }
        public LiftType GondolaLiftType { get; set; }
        public LiftType ChairliftType { get; set; }
        public LiftType Drag { get; set; }
        public Lift GondolaLift { get; set; }
        public Lift ChairLift { get; set; }
        public Lift SecondChairLift { get; set; }

        public PassAgeGroup AdultGroup { get; set; }
        public PassAgeGroup ChildGroup { get; set; }
        public PassAgeGroup StudentGroup { get; set; }

        public PassPeriod Morning { get; set; }
        public PassPeriod Afternoon { get; set; }
        public PassPeriod AllDay { get; set; }

        public Pass AllDayAdultPass { get; set; }
        public Pass AllDayStudentPass { get; set; }
        public Pass AllDayChildPass { get; set; }
        public Pass MorningStudentPass { get; set; }
        public Pass MorningAdultPass { get; set; }
        public Pass MorningChildPass { get; set; }
        public Pass AfternoonAdultPass { get; set; }
        public Pass AfternoonStudentPass { get; set; }
        public Pass AfternoonChildPass { get; set; }
        public ApplicationUser NormalUser { get; set; }
        public ApplicationUser ManagerUser { get; set; }
        public ResortManager ResortManager { get; set; }
        private void SeedPasses()
        {
            AllDayAdultPass = new Pass
            {
                Id = Guid.NewGuid(),
                Name = "All day adult pass",
                Price = 50,
                PassPeriodId = AllDay.Id,
                PassAgeGroupId = AdultGroup.Id,
                IsDeleted = false

            };

            AllDayStudentPass = new Pass
            {
                Id = Guid.NewGuid(),
                Name = "All day student pass",
                Price = 40,
                PassPeriodId = AllDay.Id,
                PassAgeGroupId = StudentGroup.Id,
                IsDeleted = false

            };
            AllDayChildPass = new Pass
            {
                Id = Guid.NewGuid(),
                Name = "All day child pass",
                Price = 30,
                PassPeriodId = AllDay.Id,
                PassAgeGroupId = ChildGroup.Id,
                IsDeleted = false

            };

            MorningAdultPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Morning adult pass",
                Price = 30,
                PassPeriodId = Morning.Id,
                PassAgeGroupId = AdultGroup.Id,
                IsDeleted = false
            };

            MorningStudentPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Morning student pass",
                Price = 25,
                PassPeriodId = Morning.Id,
                PassAgeGroupId = StudentGroup.Id,
                IsDeleted = false
            };

            MorningChildPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Morning child pass",
                Price = 20,
                PassPeriodId = Morning.Id,
                PassAgeGroupId = ChildGroup.Id,
                IsDeleted = false

            };

            AfternoonAdultPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Afternoon adult pass",
                Price = 30,
                PassPeriodId = Afternoon.Id,
                PassAgeGroupId = AdultGroup.Id,
                IsDeleted = false

            };

            AfternoonStudentPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Afternoon student pass",
                Price = 25,
                PassPeriodId = Afternoon.Id,
                PassAgeGroupId = StudentGroup.Id,
                IsDeleted = false

            };

            AfternoonChildPass = new Pass()
            {
                Id = Guid.NewGuid(),
                Name = "Afternoon child pass",
                Price = 20,
                PassPeriodId = Afternoon.Id,
                PassAgeGroupId = ChildGroup.Id,
                IsDeleted = false

            };
        }

        private void SeedPassPeriods()
        {
            Morning = new PassPeriod
            {
                Id = Guid.Parse("235024B0-64B9-4E2E-A0EE-48D0A2750953\r\n"),
                Name = "Morning",
                ValidFromHour = new TimeOnly(8, 30),
                ValidToHour = new TimeOnly(12, 30),
                DaysCount = 1
            };
            Afternoon = new PassPeriod
            {
                Id = Guid.Parse("727C219A-0E3A-4EEB-9215-8602CBD62372"),
                Name = "Afternoon",
                ValidFromHour = new TimeOnly(12, 30),
                ValidToHour = new TimeOnly(16, 30),
                DaysCount = 1
            };
            AllDay = new PassPeriod
            {
                Id = Guid.Parse("A91D8261-2DD1-4631-A379-CE4CFF155371"),
                Name = "All day",
                ValidFromHour = new TimeOnly(8, 30),
                ValidToHour = new TimeOnly(16, 30),
                DaysCount = 1
            };
        }

        private void SeedPassAges()
        {
            AdultGroup = new()
            {
                Id = Guid.Parse("A1371258-86D8-4EC2-9FBF-9B03A31CD548"),
                Name = "Adult",
                MinAge = 18,
                MaxAge = 64
            };
            StudentGroup = new()
            {
                Id = Guid.Parse("CAE47722-1B8A-4578-B1C8-1F8B0412D7F1"),
                Name = "Student",
                MinAge = 12,
                MaxAge = 26
            };
            ChildGroup = new()
            {
                Id = Guid.Parse("3D8819CA-F1CF-48CD-C851-08DD19791FAA"),
                Name = "Child",
                MinAge = 6,
                MaxAge = 12
            };
        }
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
                OpenningTime = new TimeOnly(8, 30),
                ClosingTime = new TimeOnly(16, 30),
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
                OpenningTime = new TimeOnly(8, 30),
                ClosingTime = new TimeOnly(16, 30),
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
                OpenningTime = new TimeOnly(8, 45),
                ClosingTime = new TimeOnly(16, 00),
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
                Difficulty = SlopeDifficulty.Easy,
                Length = 300,
                UpperPointAltitude = 1450,
                LowerPointAltitude = 1350,
                IsOpen = true,
                SlopeCondition = SlopeCondition.NotGroomed
            };
            FourthSlope = new()
            {
                Id = Guid.NewGuid(),
                Name = "The wall",
                Difficulty = SlopeDifficulty.Hard,
                Length = 500,
                UpperPointAltitude = 2000,
                LowerPointAltitude = 1700,
                IsOpen = true,
                SlopeCondition = SlopeCondition.Mogul
            };
            FifthSlope = new()
            {
                Id = Guid.NewGuid(),
                Name = "Stone slope",
                Difficulty = SlopeDifficulty.Intermediate,
                SlopeCondition = SlopeCondition.NotGroomed,
                Length = 1000,
                UpperPointAltitude = 1800,
                LowerPointAltitude = 1300,
                IsOpen = true
            };
        }
        private void SeedUsers()
        {
            PasswordHasher<ApplicationUser> hasher = new();
            NormalUser = new()
            {
                Id = Guid.NewGuid(),
                UserName = "Skier",
                NormalizedUserName = "SKIER",
                Email = "user@test.com",
                NormalizedEmail = "USER@TEST.COM",
                FirstName = "John",
                LastName = "Doe",
                Birthdate = new DateTime(1990, 1, 1),
                AccessFailedCount = 0,
                SecurityStamp = "9C2F65AE-5259-410A-96C3-F4667516F42C"
            };
            NormalUser.PasswordHash = hasher.HashPassword(NormalUser, "1q2w3e4r");
            ManagerUser = new()
            {
                Id = Guid.Parse("9C2A65AE-5259-410A-96C3-F4667516F42C"),
                UserName = "Manager",
                Email = "dimitrichko@test.com",
                FirstName = "Dimitrichko",
                LastName = "Chorbadjiski",
                Birthdate = new DateTime(2000, 2, 29),
                AccessFailedCount = 0,
                SecurityStamp = "9C2A65AE-5259-410A-96C3-F4667516F42A"
            };
            ManagerUser.PasswordHash = hasher.HashPassword(ManagerUser, "1q2w3e4r");

            ResortManager = new()
            {
                Id = Guid.Parse("29A945EC-9C3B-41AC-8065-EDFB32974AA6"),
                ApplicationUserId = ManagerUser.Id,
            };
        }
    }
}