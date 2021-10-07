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

        public record UnvalidatedCart(IReadOnlyCollection<UnvalidatedProduct> ProductList, CartDetails CartDetails) : ICart;

        public record EmptyCart(IReadOnlyCollection<UnvalidatedProduct> ProductList, string reason) : ICart;
        
        public record ValidatedCart(IReadOnlyCollection<ValidatedProduct> ProductList, CartDetails CartDetails) : ICart;

        public record PublishedCart(IReadOnlyCollection<ValidatedProduct> ProductList, CartDetails CartDetails, DateTime PublishedDate) : ICart;

    }
}
