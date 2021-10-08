using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrarea01.Domain
{
    [AsChoice]
    public static partial class Cart
    {
        public interface ICart
        {   }
        public record UnvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> ProductList, PaymentAddress PaymentAddress) : ICart;

        public record EmptyCart() : ICart;
        
        public record InvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> ProductList, string reason): ICart; 
        
        public record ValidatedCart(IReadOnlyCollection<ValidatedProduct> ProductList, PaymentAddress PaymentAddress) : ICart;

        public record PublishedCart(IReadOnlyCollection<ValidatedProduct> ProductList, PaymentAddress PaymentAddress, DateTime PublishedDate) : ICart;

    }
}
