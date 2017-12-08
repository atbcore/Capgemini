//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TB Enterprises">
//     Copyright (c) TB Enterprises. All rights reserved.
// </copyright>
// <author>Tomasz Bednarski</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Capgemini.Service.Message;

namespace Capgemini.Service.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //// Base Address for Capgeminiervice
            var httpBaseAddress = new Uri("http://localhost:4321/Capgemini");

            //// Instantiate ServiceHost
            var capgeminiServiceHost = new ServiceHost(typeof(CustomerService), httpBaseAddress);
            try
            {
                //// Add Endpoint to Host
                capgeminiServiceHost.AddServiceEndpoint(typeof(ICustomerService), new BasicHttpBinding(), "CustomerService");

                //// Metadata Exchange
                var serviceBehavior = new ServiceMetadataBehavior {HttpGetEnabled = true};
                capgeminiServiceHost.Description.Behaviors.Add(serviceBehavior);

                //// Start the service
                capgeminiServiceHost.Open();
                Console.WriteLine("Service is live now at: {0}", httpBaseAddress);
                Console.WriteLine("Press <ENTER> to terminate service.");

                while (true)
                {
                    var result = Console.ReadKey(true);
                    if (result.Key == ConsoleKey.Enter) break;
                }

                // Close the ServiceHostBase to shutdown the service.
                capgeminiServiceHost.Close();
                Console.WriteLine("Service was closed");
            }
            catch (AddressAccessDeniedException)
            {
                Console.WriteLine("Please use command as administrator: netsh http add urlacl url=http://+:4321/Capgemini user=DOMAIN\\user");
                capgeminiServiceHost.Abort();
                Console.WriteLine("Service was aborted.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is an issue with CustomerService: " + ex.Message);
                capgeminiServiceHost.Abort();
                Console.WriteLine("Service was aborted.");
                Console.ReadKey();
            }
        }
    }
}
