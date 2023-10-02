using GrpcServiceFlow.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceFlow
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<CustomerService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
//We create our Custom  Proto file called Customers.proto
//u add new item then search for proto click on protobuffer file
//Since we want to simulate An Api call to to customer model we  add cusomers.proto and put in
//some method ther 
//grpc can only have these dataType int32, bool, string, float, double
//Dont forget to add the CustomerProto into ur csproj folder
//not becaouse it is a server app we add server here assume it was to be the apllucatuon consuming thegrpc
//we would replace it with  GrpcServices = "client"
//< ItemGroup >
//    < Protobuf Include = "Protos\customers.proto" GrpcServices = "Server" />

//     </ ItemGroup >

//We create a customerService next
//these class will inherit from Customer.CustomerBase these which is the (customerspluto),
//then we overide the method we define in customerspluto to provide a concrete Implementation
//register customerService in the DI conatiner 
//WE CREATE A client app that will consume thr grpc in 
//my case i use a simple comnsole application and u Installed the necessary sdk
//we create a xonsole app, dot forget to copy paster the customerporoto and other protpo u will be 
//consuming the client App then u put in the correct namespace
//Remeber to include the protos in the csproj and set it to client
//Remember to always save ur Csproj if u should add somthing to it
//Unless u get some funny error
//ensure u save ur protto files after edit orelse u get spome funny error
//rpd can work with List  BY DEFault so we need to work our way around it using Stream