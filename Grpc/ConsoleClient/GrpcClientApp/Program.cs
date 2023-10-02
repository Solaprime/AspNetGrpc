using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace GrpcClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Create the Channel
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var customerClient = new Customer.CustomerClient(channel);

            var result = await customerClient.GetCustomerInfoAsync(new CustomerFindModel() { UserId = 1 });
            Console.WriteLine($"First Name {result.FirstName} and {result.LastName}");

            var result1 = await customerClient.GetCustomerInfoAsync(new CustomerFindModel() { UserId = 2 });
            Console.WriteLine($"First Name {result1.FirstName} and {result1.LastName}");

            var result8 = await customerClient.GetCustomerInfoAsync(new CustomerFindModel() { UserId = 8 });
            Console.WriteLine($"First Name {result8.FirstName} and {result8.LastName}");

            var allCustomers = customerClient.GetAllCustomers(new AllCustomerFindModel());

            await foreach ( var customer in allCustomers.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine("Using the stream for the MakeShift List");
                Console.WriteLine($"{customer.FirstName} and {customer.LastName}");
            }
        }
    }
}
