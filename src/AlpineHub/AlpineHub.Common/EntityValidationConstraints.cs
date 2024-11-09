using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpineHub.Common
{
    public static class EntityValidationConstraints
    {
        //Slope:
        public const byte SlopeNameMinLength = 3;
        public const byte SlopeNameMaxLength = 100;

        //Lifts:
        public const byte LiftTypeNameMinLength = 4;
        public const byte LiftTypeNameMaxLength = 20;

        public const byte LiftNameMinLength = 3;
        public const byte LiftNameMaxLength = 64;


    }
}
