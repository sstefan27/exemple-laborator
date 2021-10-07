using System;
using Lucrarea01.Domain;
using System.Collections.Generic;
using static Lucrarea01.Domain.Cart;

namespace Lucrarea01
{
    class Program
    {

        static void Main(string[] args)
        {
                var listOfProducts = ReadListOfProducts().ToArray();
                var cartDetails = ReadDetails();
                UnvalidatedCart unvalidatedCart = new(listOfProducts, cartDetails);
                ICart result = CheckCart(unvalidatedCart);
                result.Match(
                    whenUnvalidatedCart: unvalidatedCart => unvalidatedCart,
                    whenEmptyCart: invalidResult => invalidResult,
                    whenValidatedCart: validatedCart => PublishedCart(validatedCart, cartDetails,DateTime.Now),
                    whenPublishedCart: PublishedCart => PublishedCart
                );
                Console.WriteLine(listOfProducts);
                Console.WriteLine(result);
        }

        private static List<UnvalidatedProduct> ReadListOfProducts()
        {
            List<UnvalidatedProduct> listOfProducts = new();
            do
            {
                    var ProductRegistrationNumber = ReadValue("ProductRegistrationNumber: ");
                    if (string.IsNullOrEmpty(ProductRegistrationNumber))
                    {
                        break;
                    }

                    var ProductAmount = ReadValue("ProductAmount: ");
                    if (string.IsNullOrEmpty(ProductAmount))
                    {
                        break;
                    }
                    listOfProducts.Add(new(ProductRegistrationNumber, ProductAmount));
            } while (true);
            return listOfProducts;
        }
        private static ICart CheckCart(UnvalidatedCart unvalidatedCart) => ((string.IsNullOrEmpty(unvalidatedCart.CartDetails.PaymentAddress.Value))? new EmptyCart(new List<UnvalidatedProduct>(), "EmptyCart")
                      :( (unvalidatedCart.CartDetails.PaymentState.Value == 0) ? new ValidatedCart(new List<ValidatedProduct>(), unvalidatedCart.CartDetails)
                             :new PublishedCart(new List<ValidatedProduct>(), unvalidatedCart.CartDetails, DateTime.Now)));
        
        private static ICart PublishedCart(ValidatedCart validatedResult, CartDetails cartDetails, DateTime PublishedDate) =>
                new PublishedCart(new List<ValidatedProduct>(), cartDetails, DateTime.Now);

        

        public static CartDetails ReadDetails()
        {
            PaymentState paymentState;
            PaymentAddress paymentAddress;
            CartDetails cartDetails;

            if (true)
            {

                var Address = ReadValue("Address: ");
                if (string.IsNullOrEmpty(Address))
                {
                    paymentAddress = new PaymentAddress("not defined");
                }
                else
                {
                    paymentAddress = new PaymentAddress(Address);
                }
                Console.Write("Press ENTER if you want to pay...");
                if(Console.ReadKey().Key != ConsoleKey.Enter) { paymentState = new PaymentState(0);}
                else
                {
                    paymentState = new PaymentState(1);
                    Console.Write("You did not pay!");
                }
            }
            else
            {
                paymentAddress = new PaymentAddress("not defined");
                paymentState = new PaymentState(0);
            }
            cartDetails = new CartDetails(paymentAddress, paymentState);
            return cartDetails;
         }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
