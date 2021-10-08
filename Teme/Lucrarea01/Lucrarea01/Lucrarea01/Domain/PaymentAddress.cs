using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
    public record PaymentAddress
    {
        public string Value { get; }
        
        // public string City { get; }
        // public string Street { get; }
        // public string PostalCode {get; }

        // public PaymentAddress(string City, string Street, string PostalCode)
        // { 
        //         this.City = city;
        //         this.Street = street;
        //         this.PostalCode = postalCode;
        // }

        // public override string ToString()
        // {
        //     return City+ " " + Street + " " + PostalCode;
        // }
        public PaymentAddress(string value)
        { 
                Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
