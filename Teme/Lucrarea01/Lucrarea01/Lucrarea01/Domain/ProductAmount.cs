using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
   public record  ProductAmount
    {
        private static readonly Regex ValidPattern = new("/^[0-9]+$/");
        public string Value { get; }

        private ProductAmount(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductAmount("This field requires only numeric char");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
