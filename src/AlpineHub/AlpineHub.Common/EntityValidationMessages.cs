using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpineHub.Common
{
    public static class EntityValidationMessages
    {
        public const string RequiredField = "The {0} field is required.";
        public const string FieldLengthError = "The {0}  must be between {2} and {1} characters long.";
        public const string LengthOutOfRange = "The {0} must be between {1} and {2} meters.";

        public const string UnexpectedEditError = "Unexpected error occurred  editing {0}. Please try again later or contact administrator.";
        public const string UnexpectedError = "Unexpected error occurred. Please try again later or contact administrator.";
    }
}
