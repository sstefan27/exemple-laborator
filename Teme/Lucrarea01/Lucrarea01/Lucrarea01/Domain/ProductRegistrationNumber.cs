using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
    public record ProductRegistrationNumber
    {
        private static readonly Regex ValidPattern = new("/^[0-9]+$/");

        public string Value { get; }

        private ProductRegistrationNumber(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductRegistrationNumber("This field requires only numeric char");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
