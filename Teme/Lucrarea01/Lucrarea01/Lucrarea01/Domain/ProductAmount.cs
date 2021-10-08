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
        public int Value { get; }

        private ProductAmount(int value)
        {
            if (value > 0 && value <= 100 )
            {
                Value = value;
            }
            else
            {
                throw new InvalidProductAmount("Insuficient stocks");
            }
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }
    }
}
