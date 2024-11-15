using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpineHub.Common
{
    public static class EntityValidationConstraints
    {
        //User:
        public const byte UserFirstNameMinLength = 5;
        public const byte UserFirstNameMaxLength = 50;

        public const byte UserLastNameMinLength = 5;
        public const byte UserLastNameMaxLength = 50;


        //Slope:
        public const byte SlopeNameMinLength = 3;
        public const byte SlopeNameMaxLength = 100;

        //Lifts:
        public const byte LiftTypeNameMinLength = 4;
        public const byte LiftTypeNameMaxLength = 20;

        public const byte LiftNameMinLength = 3;
        public const byte LiftNameMaxLength = 64;

        //Pass Period:
        public const byte PassPeriodNameMinLength = 3;
        public const byte PassPeriodNameMaxLength = 20;

        //Pass type:
        public const byte PassTypeNameMinLength = 5;
        public const byte PassTypeNameMaxLength = 32;

        //Pass age group:
        public const byte PassAgeGroupMinLength = 5;
        public const byte PassAgeGroupMaxLength = 30;
    }
}
