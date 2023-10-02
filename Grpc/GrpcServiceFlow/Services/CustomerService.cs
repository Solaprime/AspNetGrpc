using Grpc.Core;
using GrpcServiceFlow.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceFlow.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }
        public  override Task<CustomerDataModel> GetCustomerInfo(CustomerFindModel request, ServerCallContext context)
        {
            var model = new CustomerDataModel();
            if (request.UserId == 1)
            {
                model.FirstName = "ola";
                model.LastName = "ola";

            }
            else if(request.UserId == 2)
            {
                model.FirstName = "bola";
                model.LastName = "bola";
            }
            else 
            {
                model.FirstName = "cola";
                model.LastName = "cola";
            }
            return Task.FromResult(model);
        }
        public override async  Task GetAllCustomers(AllCustomerFindModel request, IServerStreamWriter<CustomerDataModel> responseStream,
            ServerCallContext context)
        {
            var allCustomers = new List<CustomerDataModel>();
            var c1 = new CustomerDataModel();
            c1.FirstName = "arin";
            c1.LastName = "arin";
            allCustomers.Add(c1);

            var c2 = new CustomerDataModel();
            c2.FirstName = "arin2";
            c2.LastName = "arin2";
            allCustomers.Add(c2);


            var c3 = new CustomerDataModel();
            c3.FirstName = "arin3";
            c3.LastName = "arin3";
            allCustomers.Add(c3);

            var c4 = new CustomerDataModel();
            c4.FirstName = "arin4";
            c4.LastName = "arin4";
            allCustomers.Add(c4);

            foreach (var item in allCustomers)
            {
                await responseStream.WriteAsync(item);
            }
           // return allCustomers;
       //    return Task.FromResult(allCustomers);
        }
    }
}
