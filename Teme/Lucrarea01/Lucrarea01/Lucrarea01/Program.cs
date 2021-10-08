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
                var paymentAddress = ReadDetails();
                UnvalidatedCart unvalidatedCart = new(listOfProducts, paymentAddress);
                ICart result = CheckCart(unvalidatedCart);
                result.Match(
                    whenUnvalidatedCart: unvalidatedCart => unvalidatedCart,
                    whenEmptyCart: invalidResult => invalidResult,
                    whenInvalidatedCart: invalidResult => invalidResult,
                    whenValidatedCart: validatedCart => PublishedCart(validatedCart, paymentAddress,DateTime.Now),
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
        private static ICart CheckCart(UnvalidatedCart unvalidatedCart) => ((string.IsNullOrEmpty(unvalidatedCart.PaymentAddress.Value))? new EmptyCart()
                      :( (unvalidatedCart.PaymentAddress.Value == null) ? new ValidatedCart(new List<ValidatedProduct>(), unvalidatedCart.PaymentAddress)
                             :new PublishedCart(new List<ValidatedProduct>(), unvalidatedCart.PaymentAddress, DateTime.Now)));
        
        private static ICart PublishedCart(ValidatedCart validatedResult, PaymentAddress paymentAddress, DateTime PublishedDate) =>
                new PublishedCart(new List<ValidatedProduct>(), paymentAddress, DateTime.Now);

        

        public static PaymentAddress ReadDetails()
        {
            PaymentAddress paymentAddress;

            if (true)
            {

                var Address = ReadValue("Address: ");
                // var City = ReadValue("City: ");
                // var Street = ReadValue("Street: ");
                // var PostalCode = ReadValue("PostalCode: ");
                // Address= City + "" + Street + "" + PostalCode;
                if (string.IsNullOrEmpty(Address))
                {
                    paymentAddress = new PaymentAddress("not defined");
                }
                else
                {
                    paymentAddress = new PaymentAddress(Address);
                }
                Console.Write("Press ENTER if you want to pay...");
                if(Console.ReadKey().Key != ConsoleKey.Enter) { 
                    Console.Write("Nu ati platit!!!");
                }
                else
                {
                    Console.Write("Achizitia a avut loc cu succes");
                }
            return paymentAddress;
         }
        }

        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
